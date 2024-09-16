using FormBuilder.Dtos.Request;
using FormBuilder.Entities;
using FormBuilder.Persistence;
using FormBuilder.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.Input;

public class InputRepository(ApplicationDbContext dbContext) : Repository<InputEntity>(dbContext), IInputRepository
{
    public Task<List<InputEntity>> GetAsync()
    {
        return dbContext.Set<InputEntity>().AsNoTracking().ToListAsync();
    }

    public Task<InputEntity> GetAsync(string id)
    {
        return dbContext.Set<InputEntity>().FindAsync(id).AsTask()!;
    }

    public Task<string> AddAsync(InputEntity map)
    {
        dbContext.Set<InputEntity>().Add(map);
        dbContext.SaveChanges();
        return Task.FromResult(map.Id);
    }

    public Task UpdateAsync(string id, InputRequestDto inputRequestDto)
    {
        var inputEntity = dbContext.Set<InputEntity>().Find(id);
        if (inputEntity == null) return Task.CompletedTask;
        inputEntity.Name = inputRequestDto.Name;
        inputEntity.DataType = inputRequestDto.DataType;
        inputEntity.Required = inputRequestDto.Required;
        dbContext.Set<InputEntity>().Update(inputEntity);
        dbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id)
    {
        var inputEntity = dbContext.Set<InputEntity>().Find(id);
        if (inputEntity == null) return Task.CompletedTask;
        dbContext.Set<InputEntity>().Remove(inputEntity);
        dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}