using DirectoryService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("departmentpositions");

        builder.HasKey(dl => dl.Id).HasName("pk_departmentpositions");

        builder.Property(dl => dl.DepartmentId).IsRequired().HasColumnName("department_id");

        builder.Property(dl => dl.PositionId).IsRequired().HasColumnName("position_id");

        builder
            .HasOne<Department>()
            .WithMany(d => d.Positions)
            .HasForeignKey(d => d.DepartmentId)
            .IsRequired();

        builder
            .HasOne<Position>()
            .WithMany(p => p.Departments)
            .HasForeignKey(d => d.PositionId)
            .IsRequired();
    }
}
