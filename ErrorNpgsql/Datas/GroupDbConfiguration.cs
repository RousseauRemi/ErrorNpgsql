using ErrorNpgsql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorNpgsql.Datas;

internal class GroupDbConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).HasMaxLength(50);
        
        builder.HasMany(g => g.Zones)
            .WithOne()
            .HasForeignKey(g => g.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(e => e.Position)
            .HasColumnType("geometry(Point)");
    }
}