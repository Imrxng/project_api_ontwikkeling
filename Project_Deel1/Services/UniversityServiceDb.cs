using Ghaddoura_Imran_Project.Data;
using Ghaddoura_Imran_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ghaddoura_Imran_Project.Services;

public class UniversityServiceDb(DataContext context) : IUniversityService
{
    public async Task<List<University>> GetAllUniversities()
    {
        var universities = await context.Universities.ToListAsync();
        return await Task.FromResult(universities);
    }

    public async Task<University?> GetOneUniversity(Guid id)
    {
        var university = await context.Universities.Include(x => x.Students).FirstOrDefaultAsync(x => x.Id == id);
        return await Task.FromResult(university);
    }

    public async Task<List<University>> GetUniversitiesFromLocation(string location)
    {
        var universities = await context.Universities.Include(x => x.Students).Where(x => x.Location.ToLower() == location.ToLower()).ToListAsync();
        return await Task.FromResult(universities);
    }

    public async Task AddUniversity(University university)
    {
        university.Id = new Guid();
        await context.Universities.AddAsync(university);
        await context.SaveChangesAsync();
    }

    public async Task<University> UpdateUniversity(University item)
    {
        var university = await context.Universities.FirstOrDefaultAsync(x => x.Id == item.Id);
        if (university is not null)
        {
            university.Name = item.Name;
            university.Location = item.Location;
            university.Students = item.Students;
            await context.SaveChangesAsync();
        }

        return await Task.FromResult(university);
    }

    public async Task DeleteUniversity(Guid id)
    {
        var university = await context.Universities.FirstOrDefaultAsync(x => x.Id == id);
        context.Universities.Remove(university);
        await context.SaveChangesAsync();
    }
}
