using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormBuilder.Persistence.Configurations;

public class InputConfiguration : IEntityTypeConfiguration<InputEntity>
{
    public void Configure(EntityTypeBuilder<InputEntity> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.DataType)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Required)
            .IsRequired();
        builder.ToTable($"{nameof(FormStructureEntity)}s", "FormBuilder");
        SaveData(builder);
    }

    private static void SaveData(EntityTypeBuilder<InputEntity> builder)
    {
        var formStructureDataPersonal = new FormStructureEntity
        {
            Name = "Datos personales",
            Description = "Formulario de datos personales"
        };
        var formStructurePets = new FormStructureEntity
        {
            Name = "Mascotas",
            Description = "Formulario de mascotas"
        };

        FormStructureConfiguration.AddFormStructure(formStructureDataPersonal);
        FormStructureConfiguration.AddFormStructure(formStructurePets);

        builder.HasData(
            new InputEntity
            {
                Name = "Nombre",
                DataType = "string",
                FormStructureId = formStructureDataPersonal.Id
            },
            new InputEntity
            {
                Name = "Apellido",
                DataType = "string",
                Required = true,
                FormStructureId = formStructureDataPersonal.Id
            },
            new InputEntity
            {
                Name = "Edad",
                DataType = "int",
                Required = true,
                FormStructureId = formStructureDataPersonal.Id
            },
            new InputEntity
            {
                Name = "Nombre de la mascota",
                DataType = "string",
                Required = true,
                FormStructureId = formStructurePets.Id
            },
            new InputEntity
            {
                Name = "Edad de la mascota",
                DataType = "int",
                Required = true,
                FormStructureId = formStructurePets.Id
            }
        );
    }
}