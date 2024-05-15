using ErrorNpgsql.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorNpgsql.Datas;

public class CustomDbContext : DbContext
{
#pragma warning restore CS8618

    public CustomDbContext(
        DbContextOptions<CustomDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");
        modelBuilder
            .ApplyConfiguration(new ZoneDbConfiguration())
            .ApplyConfiguration(new GroupDbConfiguration());

        base.OnModelCreating(modelBuilder);
    }

   

    #region dbSets

    public DbSet<Group> Groups { get; set; }

    #endregion dbSets
}