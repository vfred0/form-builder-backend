using FormBuilder.Dtos.Request;
using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;

namespace FormBuilder.Repositories.Input;

public interface IInputRepository : IRepository<InputEntity>
{
    public Task<List<InputEntity>> GetAsync();
    public Task<InputEntity> GetAsync(string id);
    Task<string> AddAsync(InputEntity map);
    Task UpdateAsync(string id, InputRequestDto inputRequestDto);
    Task DeleteAsync(string id);
}