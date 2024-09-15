using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;

namespace FormBuilder.Repositories.FormStructure;

public interface IFormStructureRepository : IRepository<FormStructureEntity>
{
    Task AddInput(Guid formStructureId, Guid inputId);
    
    Task<List<FormStructureEntity>> GetAsync();
    
}