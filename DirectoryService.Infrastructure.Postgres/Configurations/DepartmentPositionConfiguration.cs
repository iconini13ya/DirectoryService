using DirectoryService.Entities.Department;
using DirectoryService.Entities.Position;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder
            .ToTable("department_positions");

        builder
            .Property(dp => dp.Id)
            .HasColumnName("id");

        builder
            .HasKey(dp => dp.Id)
            .HasName("pk_department_positions");

        builder
            .Property(dp => dp.DepartmentId)
            .IsRequired()
            .HasColumnName("department_id");

        builder
            .Property(dp => dp.PositionId)
            .IsRequired()
            .HasColumnName("position_id");

        builder
            .HasOne<Department>()
            .WithMany(d => d.Positions)
            .HasForeignKey(d => d.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<Position>()
            .WithMany(p => p.Departments)
            .HasForeignKey(d => d.PositionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
