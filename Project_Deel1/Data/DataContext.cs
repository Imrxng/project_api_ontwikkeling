using Ghaddoura_Imran_Project.Models;
using Microsoft.EntityFrameworkCore;


namespace Ghaddoura_Imran_Project.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<University> Universities => Set<University>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Result> Results => Set<Result>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var university1Id = Guid.NewGuid();
        var university2Id = Guid.NewGuid();

        modelBuilder.Entity<University>().HasData(
            new University
            {
                Id = university1Id,
                Name = "University of Amsterdam",
                Location = "Amsterdam"
            },
            new University
            {
                Id = university2Id,
                Name = "Delft University of Technology",
                Location = "Delft"
            }
        );

        var student1Id = Guid.NewGuid();
        var student2Id = Guid.NewGuid();

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = student1Id,
                FirstName = "Imran",
                LastName = "Ghaddoura",
                UniversityId = university1Id
            },
            new Student
            {
                Id = student2Id,
                FirstName = "Sara",
                LastName = "De Vries",
                UniversityId = university2Id
            }
        );

        modelBuilder.Entity<Result>().HasData(
            new Result
            {
                Id = Guid.NewGuid(),
                CourseName = "Computer Science",
                Points = 60,
                StudentId = student1Id
            },
            new Result
            {
                Id = Guid.NewGuid(),
                CourseName = "Mechanical Engineering",
                Points = 45,
                StudentId = student2Id
            }
        );
    }
}