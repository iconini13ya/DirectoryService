using DirectoryService.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .ToTable("locations");

        builder
            .HasKey(l => l.Id)
            .HasName("pk_locations");

        builder
            .Property(l => l.Id)
            .HasColumnName("id");

        builder
            .Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(Entities.ValueObjects.Name.MAXLENGTH)
            .HasColumnName("name");

        builder
            .Property(l => l.Address)
            .IsRequired()
            .HasColumnName("address");

        builder
            .Property(l => l.TimeZone)
            .IsRequired()
            .HasColumnName("time_zone");

        builder
            .Property(l => l.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder
            .Property(l => l.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder
            .Property(l => l.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
    }
}
