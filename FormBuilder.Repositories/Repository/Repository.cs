using System.Linq.Expressions;
using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.Repository;

public abstract class Repository<TEntity>(DbContext dbContext) : IRepository<TEntity>
    where TEntity : EntityBase
{
    // public async Task<ICollection<TEntity>> GetAsync()
    // {
    //     return await dbContext.Set<TEntity>()
    //         .AsNoTracking()
    //         .IgnoreQueryFilters()
    //         .ToListAsync();
    // }

    public virtual async Task<TEntity?> GetAsync(string id)
    {
        return await dbContext.Set<TEntity>()
            .FindAsync(id);
    }
    //
    // public async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    // {
    //     return await dbContext.Set<TEntity>()
    //         .Where(predicate)
    //         .AsNoTracking()
    //         .ToListAsync();
    // }

    public async Task<ICollection<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TKey>> orderBy)
    {
        return await dbContext.Set<TEntity>()
            .Where(predicate)
            .OrderBy(orderBy)
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task<Guid> AddAsync(TEntity entity)
    {
        await dbContext.Set<TEntity>()
            .AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(string id)
    {
        var item = await GetAsync(id);

        if (item is not null) await UpdateAsync();
    }

    public virtual async Task UpdateAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}