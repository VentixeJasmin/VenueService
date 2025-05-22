using Microsoft.EntityFrameworkCore;
using Presentation.Models; 

namespace Presentation.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<VenueEntity> Venues { get; set; }
}