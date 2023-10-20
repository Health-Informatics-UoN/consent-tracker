using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsentApp.Data.Entities;

public class Study
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string StudyId { get; set; } = string.Empty;
    public List<Patient> Patients { get; set; } = new();
}