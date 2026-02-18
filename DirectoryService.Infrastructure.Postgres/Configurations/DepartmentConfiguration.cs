using DirectoryService.Entities.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .ToTable("departments");

        builder
            .Property(d => d.Id)
            .HasColumnName("id");

        builder
            .HasKey(d => d.Id)
            .HasName("pk_departments");

        builder
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(Entities.ValueObjects.Name.MAXLENGTH)
            .HasColumnName("name")
            .HasConversion(n => n.Value, name => new Entities.ValueObjects.Name(name));

        builder
            .Property(d => d.Identifier)
            .IsRequired()
            .HasMaxLength(Entities.ValueObjects.Identifier.MAXLENGTH)
            .HasColumnName("identifier")
            .HasConversion(i => i.Value, identifier => new Entities.ValueObjects.Identifier(identifier));

        builder
            .Property(d => d.ParentId)
            .IsRequired(false)
            .HasColumnName("parent_id");

        builder
            .Property(d => d.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder
            .Property(d => d.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");

        builder
            .Property(d => d.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder
            .Property(d => d.Depth)
            .HasConversion(
                d => d.Value,
                json => JsonSerializer.Deserialize<Entities.ValueObjects.Depth>(json, JsonSerializerOptions.Default)!)
            .HasColumnType("jsonb")
            .HasColumnName("depth");

        builder
            .Property(d => d.Path)
            .HasConversion(
                p => p.Value,
                json => JsonSerializer.Deserialize<Entities.ValueObjects.Path>(json, JsonSerializerOptions.Default)!)
            .HasColumnType("jsonb")
            .HasColumnName("path");

        builder
            .HasOne<Department>()
            .WithMany(d => d.Childs)
            .HasForeignKey(dl => dl.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
