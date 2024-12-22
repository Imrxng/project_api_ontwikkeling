using Ghaddoura_Imran_Project.Models;

namespace Ghaddoura_Imran_Project.Services
{
    public interface IResultsService
    {
        Task<List<Result>> GetAllResults();
        Task<Result?> GetSingleResultDetails(Guid id);
        Task AddResult(Result result);
        Task<Result> UpdateResult(Result result);
        Task DeleteResult(Guid id);
    }
}