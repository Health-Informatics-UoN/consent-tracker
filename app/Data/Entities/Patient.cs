using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsentApp.Data.Entities;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string PatientId { get; set; }
    public string IdType { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset DoB { get; set; } = DateTimeOffset.UtcNow;
    public List<Study> Studies { get; set; } = new();
}