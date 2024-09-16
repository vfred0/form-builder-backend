using FormBuilder.Dtos.Request;
using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;

namespace FormBuilder.Repositories.FormStructure;

public interface IFormStructureRepository : IRepository<FormStructureEntity>
{
    Task AddInput(string formStructureId, string inputId);

    Task<List<FormStructureEntity>> GetAsync();
    Task<string> AddAsync(FormStructureEntity formStructure);
    Task UpdateAsync(string id, FormStructureEntity formStructureEntity);
}