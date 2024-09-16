using FormBuilder.Entities;

namespace FormBuilder.Repositories.Repository;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity?> GetAsync(string id);
    Task<string> AddAsync(TEntity entity);
    Task UpdateAsync();
    Task DeleteAsync(string id);
}