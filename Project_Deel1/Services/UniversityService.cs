using Ghaddoura_Imran_Project.Data;
using Ghaddoura_Imran_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghaddoura_Imran_Project.Services;

public class UniversityService(InMemoryContext context) : IUniversityService
{
    public async Task<List<University>> GetAllUniversities()
    {
        return [.. context.Universities];
    }

    public Task<University?> GetOneUniversity(Guid id)
    {
        var university = context.Universities.FirstOrDefault(x => x.Id == id);

        if (university != null)
        {
            university.Students = context.Students.Where(x => x.UniversityId == university.Id).ToList();
        }

        return Task.FromResult(university);
    }

    public Task<List<University>> GetUniversitiesFromLocation(string location)
    {
        var universities = context.Universities
            .Where(x => x.Location.ToLower() == location.ToLower())
            .ToList();

        foreach (var university in universities)
        {
            university.Students = context.Students.Where(x => x.UniversityId == university.Id).ToList();
        }

        return Task.FromResult(universities);
    }

    public Task AddUniversity(University university)
    {
        context.Universities.Add(university);
        return Task.CompletedTask;
    }

    public Task<University> UpdateUniversity(University item)
    {
        var university = context.Universities.FirstOrDefault(x => x.Id == item.Id);
        if (university != null)
        {
            university.Name = item.Name;
            university.Location = item.Location;
            university.Students = item.Students;
        }
        return Task.FromResult(university);
    }

    public Task DeleteUniversity(Guid id)
    {
        var university = context.Universities.FirstOrDefault(x => x.Id == id);
        context.Universities.Remove(university);
        return Task.CompletedTask;
    }
}
