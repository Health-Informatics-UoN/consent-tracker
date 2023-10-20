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
                Id = y.Id,
                IdType = y.IdType
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

        var existingStudy = _db.Studies.FirstOrDefaultAsync(x => x.StudyId == studyId);
        
        if (existingStudy != null)
        {
            throw new InvalidOperationException("Study with the same ID already exists.");
        }

        var entity = new Study
        {
            StudyId = studyId
        };
        
        await _db.Studies.AddAsync(entity);
        await _db.SaveChangesAsync();
    }
}