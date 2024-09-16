using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.Repository;

public abstract class Repository<TEntity>(DbContext dbContext) : IRepository<TEntity>
    where TEntity : EntityBase
{
    public virtual async Task<TEntity?> GetAsync(string id)
    {
        return await dbContext.Set<TEntity>()
            .FindAsync(id);
    }
    
    public async Task DeleteAsync(string id)
    {
        var item = await GetAsync(id);

        if (item != null)
        {
            dbContext.Set<TEntity>().Remove(item);
            await dbContext.SaveChangesAsync();
        }
    }
    
    public virtual async Task UpdateAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}