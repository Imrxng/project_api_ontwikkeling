using Ghaddoura_Imran_Project.Models;

namespace Ghaddoura_Imran_Project.Services
{
    public interface IUniversityService
    {
        Task AddUniversity(University university);
        Task<List<University>> GetAllUniversities();
        Task<University?> GetOneUniversity(Guid id);
        Task<List<University>> GetUniversitiesFromLocation(string location);
        Task<University> UpdateUniversity(University item);
        Task DeleteUniversity(Guid id);
    }
}