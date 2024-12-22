using Ghaddoura_Imran_Project.Models;

namespace Ghaddoura_Imran_Project.Data;

public class InMemoryContext
{
    public List<University> Universities { get; } = new();
    public List<Student> Students { get; } = new();
    public List<Result> Results { get; } = new();

    public InMemoryContext()
    {
        SeedData();
    }

    private void SeedData()
    {
        var university1Id = Guid.NewGuid();
        var university2Id = Guid.NewGuid();

        Universities.AddRange(new[]
        {
            new University
            {
                Id = university1Id,
                Name = "University of Amsterdam memory",
                Location = "Amsterdam"
            },
            new University
            {
                Id = university2Id,
                Name = "Delft University of Technology",
                Location = "Delft"
            }
        });

        var student1Id = Guid.NewGuid();
        var student2Id = Guid.NewGuid();

        Students.AddRange(new[]
        {
            new Student
            {
                Id = student1Id,
                FirstName = "Imran memory",
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
        });

        Results.AddRange(new[]
        {
            new Result
            {
                Id = Guid.NewGuid(),
                CourseName = "Computer Science memory",
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
        });
    }
}
