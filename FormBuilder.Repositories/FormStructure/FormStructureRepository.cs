using FormBuilder.Dtos.Request;
using FormBuilder.Entities;
using FormBuilder.Persistence;
using FormBuilder.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.FormStructure;

public class FormStructureRepository(ApplicationDbContext dbContext)
    : Repository<FormStructureEntity>(dbContext), IFormStructureRepository
{
    public Task<List<FormStructureEntity>> GetAsync()
    {
        return dbContext.Set<FormStructureEntity>()
            .Include(x => x.Inputs)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<FormStructureEntity> GetAsync(string id)
    {
        return dbContext.Set<FormStructureEntity>().FindAsync(id).AsTask()!;
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

    public Task UpdateAsync(string id, FormStructureRequestDto formStructure)
    {
        var formStructureEntity = GetAsync(id).Result;
        formStructureEntity.Name = formStructure.Name;
        formStructureEntity.Description = formStructure.Description;
        var formStructureInputs = dbContext.Set<FormStructureInputEntity>()
            .Where(x => x.FormStructureId == id);
        dbContext.Set<FormStructureInputEntity>().RemoveRange(formStructureInputs);
        var newInputs = dbContext.Set<InputEntity>()
            .Where(x => formStructure.Inputs.Select(y => y.Id).Contains(x.Id))
            .ToList();
        var newFormStructureInputs = newInputs.Select(input => new FormStructureInputEntity
        {
            FormStructureId = id,
            InputId = input.Id
        });
        dbContext.Set<FormStructureInputEntity>().AddRange(newFormStructureInputs);
        formStructureEntity.Inputs = newInputs;
        dbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id)
    {
        dbContext.Set<FormStructureEntity>().Remove(GetAsync(id).Result);
        dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}