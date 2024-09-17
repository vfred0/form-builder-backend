using FormBuilder.Dtos.Request;
using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;

namespace FormBuilder.Repositories.Input;

public interface IInputRepository : IRepository<InputEntity>
{
    public Task<List<InputEntity>> GetAsync();
    Task<string> AddAsync(InputEntity map);
    Task UpdateAsync(string id, InputDto inputDto);
    Task DeleteAsync(string id);
}