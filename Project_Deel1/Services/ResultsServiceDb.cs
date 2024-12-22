using Ghaddoura_Imran_Project.Data;
using Ghaddoura_Imran_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghaddoura_Imran_Project.Services
{
    public class ResultsServiceDb(DataContext context) : IResultsService
    {
        public async Task<List<Result>> GetAllResults()
        {
            return await context.Results.ToListAsync();
        }

        public async Task<Result?> GetSingleResultDetails(Guid id)
        {
            return await context.Results.Include(x => x.Student).ThenInclude(x => x.University).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddResult(Result result)
        {
            result.Id = new Guid();
            await context.Results.AddAsync(result);
            await context.SaveChangesAsync();
        }

        public async Task<Result> UpdateResult(Result item)
        {
            var result = await context.Results.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result is not null)
            {
                result.Student = item.Student;
                result.CourseName = item.CourseName;
                result.Points = item.Points;
                await context.SaveChangesAsync();
            }

            return await Task.FromResult(result);
        }

        public async Task DeleteResult(Guid id)
        {
            var result = await context.Results.FirstOrDefaultAsync(x => x.Id == id);
            context.Results.Remove(result);
            await context.SaveChangesAsync();
        }
    }
}
