using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShiftsLoggerAPI.Models;

[Index(nameof(Name), IsUnique = true)]

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Shift> Shifts { get; set; }
}


