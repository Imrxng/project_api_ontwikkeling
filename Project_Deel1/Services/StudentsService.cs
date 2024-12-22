using Ghaddoura_Imran_Project.Data;
using Ghaddoura_Imran_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghaddoura_Imran_Project.Services;

public class StudentsService(InMemoryContext context) : IStudentsService
{
    public Task<List<Student>> GetAllStudents()
    {
        var students = context.Students.ToList();

        foreach (var student in students)
        {
            student.University = context.Universities.FirstOrDefault(x => x.Id == student.UniversityId);
        }

        return Task.FromResult(students);
    }

    public Task<Student?> GetSingleStudentDetails(Guid id)
    {
        var student = context.Students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            student.University = context.Universities.FirstOrDefault(x => x.Id == student.UniversityId);
            student.Results = context.Results.Where(x => x.StudentId == student.Id).ToList();
        }

        return Task.FromResult(student);
    }

    public Task<Student> AddStudent(Student student)
    {
        context.Students.Add(student);
        return Task.FromResult(student);
    }

    public Task<Student> UpdateStudent(Student item)
    {
        var student = context.Students.FirstOrDefault(x => x.Id == item.Id);
        if (student != null)
        {
            student.FirstName = item.FirstName;
            student.LastName = item.LastName;
            student.Results = item.Results;
            student.UniversityId = item.UniversityId;
        }
        return Task.FromResult(student);
    }

    public Task DeleteStudent(Guid id)
    {
        var student = context.Students.FirstOrDefault(x => x.Id == id);
        context.Students.Remove(student);
        return Task.CompletedTask;
    }
}
