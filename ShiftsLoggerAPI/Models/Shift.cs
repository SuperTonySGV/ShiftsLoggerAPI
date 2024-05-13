using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShiftsLoggerAPI.Models;

[Index(nameof(Id), IsUnique = true)]

public class Shift
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public int EmployeeId {  get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; }
}

