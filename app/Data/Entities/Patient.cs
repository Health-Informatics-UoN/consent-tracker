namespace ConsentApp.Data.Entities;

public class Patient
{
    public int Id { get; set; }
    public string IdType { get; set; } = string.Empty;
    public List<Patient> Patients { get; set; } = new();
}