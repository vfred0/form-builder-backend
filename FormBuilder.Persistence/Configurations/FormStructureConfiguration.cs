using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Persistence.Configurations;

public class FormStructureConfiguration : IEntityTypeConfiguration<FormStructureEntity>
{
    public void Configure(EntityTypeBuilder<FormStructureEntity> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(200);

        builder.HasMany(x => x.Inputs)
            .WithMany(x => x.FormStructures)
            .UsingEntity<FormStructureInputEntity>();
    }
}