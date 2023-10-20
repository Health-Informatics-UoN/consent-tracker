namespace ConsentApp.Models;

public class Study
{
    public string StudyId { get; set; }
    public List<Patient> Patients { get; set; }
}