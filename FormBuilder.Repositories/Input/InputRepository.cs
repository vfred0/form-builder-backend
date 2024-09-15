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
}