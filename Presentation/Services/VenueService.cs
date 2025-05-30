using Presentation.Data; 
using Presentation.Models;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Services; 

public class VenueService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<VenueEntity?> CreateVenue(VenueDto dto)
    {
        try
        {
            if (dto == null)
            {
                Console.WriteLine("Form is not filled out.");
                return null;
            }

            VenueEntity venue = new()
            {
                Title = dto.Title,
                VenueType = dto.VenueType ?? "",
                Description = dto.Description ?? "",
                Capacity = dto.Capacity,
                StreetAddress = dto.StreetAddress ?? "Not specified",
                PostCode = dto.PostCode ?? "Not specified",
                City = dto.City,
                MapUrl = dto.MapUrl ?? "Not specified"
            }; 

            await _context.Venues.AddAsync(venue);
            await _context.SaveChangesAsync();
            return venue;  
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Something went wrong: " + ex);
            return null; 
        }
    }

    public async Task<List<VenueEntity>> GetAllVenues()
    {
        try
        {
            var venues = await _context.Venues.ToListAsync();
            if (!venues.Any())
            {
                Console.WriteLine("No venues available");
                return []; 
            }

            return venues;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return [];
        }
    }

    public async Task<VenueEntity?> GetVenueById(int id)
    {
        try
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id); 
            if (venue == null) 
            {
                Console.WriteLine("Couldn't find venue.");
                return null;
            }

            return venue;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return null;
        }
    }

    public async Task<VenueEntity?> UpdateVenue(int id, VenueDto updatedVenue)
    {
        try
        {
            var existingVenue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);
            if (existingVenue == null)
            {
                Console.WriteLine("Couldn't find venue.");
                return null;
            }

            existingVenue.Title = updatedVenue.Title;
            existingVenue.VenueType = updatedVenue.VenueType ?? "";
            existingVenue.Description = updatedVenue.Description ?? "";
            existingVenue.Capacity = updatedVenue.Capacity;
            existingVenue.StreetAddress = updatedVenue.StreetAddress ?? "Not specified";
            existingVenue.PostCode = updatedVenue.PostCode ?? "Not specified";
            existingVenue.City = updatedVenue.City;
            existingVenue.MapUrl = updatedVenue.MapUrl ?? "Not specified";

            await _context.SaveChangesAsync();

            return existingVenue;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return null;
        }
    }

    public async Task<bool> DeleteVenue(int id)
    {
        try
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);
            if (venue == null)
            {
                Console.WriteLine("Couldn't find venue.");
                return false;
            }

            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex);
            return false;
        }
    }
}
