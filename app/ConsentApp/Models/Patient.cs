namespace ConsentApp.Models;

public class Patient
{
    public string PatientId { get; set; }
    public string IdType { get; set; }
    public string Name { get; set; }
    public DateTimeOffset DoB{ get; set; }
}