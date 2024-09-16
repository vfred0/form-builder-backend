using FormBuilder.Entities;

namespace FormBuilder.Repositories.Repository;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity?> GetAsync(string id);
    Task UpdateAsync();
    Task DeleteAsync(string id);
}