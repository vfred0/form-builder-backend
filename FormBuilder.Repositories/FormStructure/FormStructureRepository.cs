using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.FormStructure;

public class FormStructureRepository(DbContext dbContext)
    : Repository<FormStructureEntity>(dbContext), IFormStructureRepository
{
}