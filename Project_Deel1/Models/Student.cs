using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ghaddoura_Imran_Project.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; }

    [Column("Firstname")]
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Column("LastName")]
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
    public string LastName { get; set; } = string.Empty;

    public Guid UniversityId { get; set; }

    [JsonIgnore] 
    public University? University { get; set; } = null!;

    [JsonIgnore] 
    public List<Result> Results { get; set; } = [];
}
