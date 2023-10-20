namespace ConsentApp.Models;

public class Patient
{
    public int Id { get; set; }
    public string IdType { get; set; }
    public List<Study> Studies { get; set; }
}