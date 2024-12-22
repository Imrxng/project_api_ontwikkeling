using Ghaddoura_Imran_Project.Data;
using Ghaddoura_Imran_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghaddoura_Imran_Project.Services;

public class StudentsServiceDb(DataContext context) : IStudentsService
{
    public async Task<List<Student>> GetAllStudents()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> GetSingleStudentDetails(Guid id)
    {
        return await context.Students.Include(x => x.University).Include(x => x.Results).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Student> AddStudent(Student student)
    {
        student.Id = new Guid();
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> UpdateStudent(Student item)
    {
        var student = await context.Students.FirstOrDefaultAsync(x => x.Id == item.Id);
        if (student is not null)
        {
            student.FirstName = item.FirstName;
            student.LastName = item.LastName;
            student.Results = item.Results;
            student.UniversityId = item.UniversityId;
            await context.SaveChangesAsync();
        }

        return await Task.FromResult(student);
    }

    public async Task DeleteStudent(Guid id)
    {
        var student = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }
}
