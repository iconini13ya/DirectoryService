using DirectoryService.Entities;
using DirectoryService.Entities.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder
            .ToTable("department_locations");

        builder
            .Property(dl => dl.Id)
            .HasColumnName("id");

        builder
            .HasKey(dl => dl.Id)
            .HasName("pk_department_locations");

        builder
            .Property(dl => dl.DepartmentId)
            .IsRequired()
            .HasColumnName("department_id");

        builder
            .Property(dl => dl.LocationId)
            .IsRequired()
            .HasColumnName("location_id");

        builder
            .HasOne<Department>()
            .WithMany(d => d.Locations)
            .HasForeignKey(dl => dl.DepartmentId)
            .IsRequired();

        builder
            .HasOne<Location>()
            .WithMany(d => d.Departments)
            .HasForeignKey(dl => dl.LocationId)
            .IsRequired();
    }
}
