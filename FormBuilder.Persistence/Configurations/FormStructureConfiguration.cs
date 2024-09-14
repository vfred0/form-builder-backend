using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Persistence.Configurations;

public class FormStructureConfiguration : IEntityTypeConfiguration<FormStructureEntity>
{
    private static EntityTypeBuilder<FormStructureEntity> _builder = default!;

    public void Configure(EntityTypeBuilder<FormStructureEntity> builder)
    {
        _builder = builder;
        _builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        _builder.Property(x => x.Description)
            .HasMaxLength(200);
        _builder.HasMany(x => x.Inputs)
            .WithOne(x => x.FormStructureEntity)
            .HasForeignKey(x => x.FormStructureEntity.Id)
            .OnDelete(DeleteBehavior.Cascade);
        _builder.ToTable($"{nameof(FormStructureEntity)}s", "FormBuilder");
    }

    public static void AddFormStructure(FormStructureEntity formStructureEntityDataPersonal)
    {
        _builder.HasData(formStructureEntityDataPersonal);
    }
}