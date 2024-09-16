using FormBuilder.Entities;
using FormBuilder.Persistence;
using FormBuilder.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.FormStructure;

public class FormStructureRepository(ApplicationDbContext dbContext)
    : Repository<FormStructureEntity>(dbContext), IFormStructureRepository
{
    public Task AddInput(Guid formStructureId, Guid inputId)
    {
        var formStructure = dbContext.Set<FormStructureEntity>().Find(formStructureId);
        var input = dbContext.Set<InputEntity>().Find(inputId);
        if (input != null) formStructure?.Inputs.Add(input);
        dbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<List<FormStructureEntity>> GetAsync()
    {
        return dbContext.Set<FormStructureEntity>()
            .Include(x => x.Inputs)
            .AsNoTracking()
            .ToListAsync();
    }
}