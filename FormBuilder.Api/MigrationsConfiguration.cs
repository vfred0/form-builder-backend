using FormBuilder.Entities;
using FormBuilder.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Api;

public static class MigrationsConfiguration
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();

        if (!context.Set<FormStructureEntity>().Any()) SeedData(context);
    }

    private static void SeedData(ApplicationDbContext context)
    {
        var inputName = new InputEntity
        {
            Name = "Nombres",
            DataType = "string",
            Required = true
        };

        var inputEmail = new InputEntity
        {
            Name = "Correo",
            DataType = "string",
            Required = true
        };

        var formStructurePersonal = new FormStructureEntity
        {
            Name = "Información Personal",
            Description = "Formulario de información personal",
            Inputs = new List<InputEntity>
            {
                inputName,
                inputEmail
            }
        };

        var formStructurePets = new FormStructureEntity
        {
            Name = "Información de mascotas",
            Description = "Formulario de información de mascotas",
            Inputs = new List<InputEntity>
            {
                inputName
            }
        };

        context.Set<FormStructureEntity>().AddRange(formStructurePersonal, formStructurePets);

        context.SaveChanges();
    }
}