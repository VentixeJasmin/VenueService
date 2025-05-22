using Microsoft.EntityFrameworkCore;
using Presentation.Models; 

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<VenueEntity> Events { get; set; }
}