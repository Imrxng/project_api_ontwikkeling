using Ghaddoura_Imran_Project.Models;

namespace Ghaddoura_Imran_Project.Services
{
    public interface IStudentsService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetSingleStudentDetails(Guid id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student item);
        Task DeleteStudent(Guid id);
    }
}