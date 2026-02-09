using DirectoryService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public sealed class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(p => p.Id).HasName("pk_positions");

        builder.Property(p => p.Name).IsRequired().HasMaxLength(Entities.ValueObjects.Name.MAXLENGTH).HasColumnName("name")
            .HasConversion(n => n.Value, name => new Entities.ValueObjects.Name(name));

        builder.Property(p => p.Description).IsRequired(false).HasMaxLength(Entities.ValueObjects.Description.MAXLENGTH).HasColumnName("description")
            .HasConversion(d => d.Value, description => new Entities.ValueObjects.Description(description));

        builder.Property(d => d.IsActive).IsRequired().HasColumnName("is_active");

        builder.Property(d => d.CreatedAt).IsRequired().HasColumnName("created_at");

        builder.Property(d => d.UpdatedAt).IsRequired().HasColumnName("updated_at");
    }
}
