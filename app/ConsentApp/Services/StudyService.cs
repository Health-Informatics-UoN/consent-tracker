using System.Globalization;
using System.Text.RegularExpressions;
using ConsentApp.Data;
using ConsentApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsentApp.Services;

public class StudyService
{
    private readonly ApplicationDbContext _db;

    public StudyService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Models.Study>> List()
    {
        var list = await _db.Studies
            .Include(x => x.Patients)
            .ToListAsync();

        var result = list.Select(x => new Models.Study
        {
            StudyId = x.StudyId,
            Patients = x.Patients.Select(y => new Models.Patient
            {
                PatientId = y.PatientId,
                IdType = y.IdType,
                Name = y.Name,
                DoB = y.DoB
            }).ToList(),
        });
        return result;
    }

    public async Task Create(string studyId)
    {
        bool isStudyIdValid = Regex.IsMatch(studyId, @"^\d{2}[A-Z]{2}\d{3}$");
        
        if (!isStudyIdValid)
        {
            throw new ArgumentException("Invalid study ID format.");
        }

        var existingStudy = await _db.Studies.FirstOrDefaultAsync(x => x.StudyId == studyId);
        
        if (existingStudy != null)
        {
            throw new InvalidOperationException("Study with the same ID already exists.");
        }

        var entity = new Study
        {
            StudyId = studyId
        };
        
        _db.Studies.Add(entity);
        await _db.SaveChangesAsync();
    }
    
    public async Task RegisterPatient(Models.RegisterPatient patient)
    {
        var idType = (nhsNumber: "NHS number", kNumber: "Knumber");
        var patientId = patient.PatientId.Trim().Replace(" ", "");

        // TODO: Add validation for Knumber when format has been confirmed
        if (patientId.Length == 10 && long.TryParse(patientId, out _))
        {
            patient.IdType = idType.nhsNumber;
        } else
        {
            throw new ArgumentException("Invalid patient ID format.");
        }

        var study = await _db.Studies.Include(x => x.Patients).FirstOrDefaultAsync(x => x.StudyId == patient.StudyId) ??
                    throw new NullReferenceException($"No study with the study ID: \"{patient.StudyId}\" was found.");

        var existingPatient = await _db.Patients.FirstOrDefaultAsync(x => x.PatientId.Trim().Replace(" ", "") == patientId);

        if (existingPatient != null)
        {
            var registeredToStudy = study.Patients.Find(x => x.PatientId.Trim().Replace(" ", "") == existingPatient.PatientId);
            if (registeredToStudy != null)
            {
                throw new InvalidOperationException("Patient already registered to the study");
            }
            study.Patients.Add(existingPatient);
            await _db.SaveChangesAsync();
        }
        else
        {
            var entity = new Patient
            {
                PatientId = patientId,
                IdType = patient.IdType,
                Name = patient.Name,
                DoB = DateTimeOffset.ParseExact(patient.DoB, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal),
            };
            
            _db.Patients.Add(entity);
            study.Patients.Add(entity);
        
            await _db.SaveChangesAsync();
        }
    }
}