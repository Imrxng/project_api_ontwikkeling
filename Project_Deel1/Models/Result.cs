using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ghaddoura_Imran_Project.Models;

public class Result
{
    [Key]
    public Guid Id { get; set; }

    [Column("CourseName")]
    [Required(ErrorMessage = "Course name is required.")]
    [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
    public string CourseName { get; set; } = string.Empty;

    [Column("Points")]
    [Required(ErrorMessage = "Points are required.")]
    [Range(0, 100, ErrorMessage = "Points must be between 0 and 100.")]
    public int Points { get; set; }

    public Guid StudentId { get; set; }

    public Student? Student { get; set; }
}
