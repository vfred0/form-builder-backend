using FormBuilder.Dtos.Request;
using FormBuilder.Entities;
using FormBuilder.Persistence;
using FormBuilder.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.FormStructure;

public class FormStructureRepository(ApplicationDbContext dbContext)
    : Repository<FormStructureEntity>(dbContext), IFormStructureRepository
{
    public Task AddInput(string formStructureId, string inputId)
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

    public Task<string> AddAsync(FormStructureEntity formStructure)
    {
        var inputs = dbContext.Set<InputEntity>()
            .Where(x => formStructure.Inputs.Select(y => y.Id).Contains(x.Id))
            .ToList();
        formStructure.Inputs = inputs;
        dbContext.Set<FormStructureEntity>().Add(formStructure);
        dbContext.SaveChanges();
        return Task.FromResult(formStructure.Id);
    }
    
    public Task UpdateAsync(string id, FormStructureEntity formStructure)
    {
        dbContext.Set<FormStructureEntity>().Update(formStructure);
        dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}