using Ghaddoura_Imran_Project.Data;
using Ghaddoura_Imran_Project.Models;

namespace Ghaddoura_Imran_Project.Services;

public class ResultsService(InMemoryContext context) : IResultsService
{
    public Task<List<Result>> GetAllResults()
    {
        var results = context.Results.ToList();

        foreach (var result in results)
        {
            result.Student = context.Students.SingleOrDefault(x => x.Id == result.StudentId);
            if (result.Student != null)
            {
                result.Student.University = context.Universities.SingleOrDefault(x => x.Id == result.Student.UniversityId);
            }
        }
        return Task.FromResult(results);
    }

    public Task<Result?> GetSingleResultDetails(Guid id)
    {
        var result = context.Results.SingleOrDefault(x => x.Id == id);

        if (result != null)
        {
            result.Student = context.Students.SingleOrDefault(s => s.Id == result.StudentId);
            if (result.Student != null)
            {
                result.Student.University = context.Universities.SingleOrDefault(u => u.Id == result.Student.UniversityId);
            }
        }
        return Task.FromResult(result);
    }

    public Task AddResult(Result result)
    {
        context.Results.Add(result);
        return Task.CompletedTask;
    }

    public Task<Result> UpdateResult(Result item)
    {
        var result = context.Results.FirstOrDefault(x => x.Id == item.Id);
        if (result != null)
        {
            result.StudentId = item.StudentId;
            result.CourseName = item.CourseName;
            result.Points = item.Points;
        }
        return Task.FromResult(result);
    }

    public Task DeleteResult(Guid id)
    {
        var result = context.Results.FirstOrDefault(x => x.Id == id);
        context.Results.Remove(result);
        return Task.CompletedTask;
    }
}
