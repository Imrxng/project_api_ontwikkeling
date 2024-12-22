using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ghaddoura_Imran_Project.Models;

public class University
{
    [Key]
    public Guid Id { get; set; }

    [Column("Name")]
    [Required(ErrorMessage = "University name is required.")]
    [StringLength(100, ErrorMessage = "University name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Column("Location")]
    [Required(ErrorMessage = "Location is required.")]
    [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
    public string Location { get; set; } = string.Empty;

    public List<Student> Students { get; set; } = [];
}