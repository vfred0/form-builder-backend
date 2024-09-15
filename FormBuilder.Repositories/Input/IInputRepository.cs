using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;

namespace FormBuilder.Repositories.Input;

public interface IInputRepository : IRepository<InputEntity>
{
    public Task<List<InputEntity>> GetAsync();
}