using Presentation.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Data;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\VentixeBackend\VenueService\Presentation\Data\VenueDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        return new DataContext(optionsBuilder.Options);
    }
}