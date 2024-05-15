using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ErrorNpgsql.Datas;

public class CustomDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CustomDbContext>
{
    public CustomDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CustomDbContext>();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        
        builder.UseNpgsql(connectionString,
            o =>
            {
                o.UseNetTopologySuite();
            });

        return new CustomDbContext(builder.Options);
    }
}