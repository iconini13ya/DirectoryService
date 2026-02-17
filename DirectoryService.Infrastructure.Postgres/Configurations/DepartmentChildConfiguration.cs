using DirectoryService.Entities.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations
{
    internal class DepartmentChildConfiguration : IEntityTypeConfiguration<DepartmentChild>
    {
        public void Configure(EntityTypeBuilder<DepartmentChild> builder)
        {
            builder
                .ToTable("department_childs");

            builder
                .Property(dc => dc.Id)
                .HasColumnName("id");

            builder
                .HasKey(dc => dc.Id)
                .HasName("pk_department_childs");

            builder
                .Property(dc => dc.ParentId)
                .IsRequired()
                .HasColumnName("parent_id");

            builder
                .Property(dc => dc.ChildId)
                .IsRequired()
                .HasColumnName("child_id");

            builder
                .HasOne<Department>()
                .WithMany(d => d.Childs)
                .HasForeignKey(d => d.ParentId)
                .IsRequired();
        }
    }
}
