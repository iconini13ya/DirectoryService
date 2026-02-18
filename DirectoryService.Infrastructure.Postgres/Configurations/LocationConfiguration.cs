using DirectoryService.Entities;
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
            .HasColumnName("name")
            .HasConversion(n => n.Value, name => new Entities.ValueObjects.Name(name));

        builder
            .Property(l => l.Address)
            .IsRequired()
            .HasColumnName("address")
            .HasConversion(
                a => $"{a.City},{a.Street},{a.Building}",
                address => new Entities.ValueObjects.Address(address));

        builder
            .Property(l => l.TimeZone)
            .IsRequired()
            .HasColumnName("time_zone")
            .HasConversion(
                tz => tz.Value,
                timezone => new Entities.ValueObjects.TimeZone(timezone));

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
