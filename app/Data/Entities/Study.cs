namespace ConsentApp.Data.Entities;

public class Study
{
    public int Id { get; set; }
    public List<Study> Studies { get; set; } = new();
}