using cse325_team4_project.Data;
using cse325_team4_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cse325_team4_project.Services;

public class DestinationService
{
    private readonly AppDbContext _db;

    public DestinationService(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddDestinationAsync(Destination destination)
    {
        _db.Destinations.Add(destination);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Destination>> GetAllDestinationsAsync()
    {
        return await _db.Destinations
            .AsNoTracking()
            .OrderBy(destination => destination.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Destination>> SearchDestinationsAsync(string searchTerm)
    {
        searchTerm = searchTerm.Trim();

        return await _db.Destinations
            .AsNoTracking()
            .Where(destination =>
                destination.Name.Contains(searchTerm) ||
                destination.Description.Contains(searchTerm) ||
                destination.Activities.Contains(searchTerm))
            .OrderBy(destination => destination.Name)
            .ToListAsync();
    }

    public async Task<Destination?> GetDestinationByIdAsync(int id)
    {
        return await _db.Destinations
            .AsNoTracking()
            .FirstOrDefaultAsync(destination => destination.Id == id);
    }
}
