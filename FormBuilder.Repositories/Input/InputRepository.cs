using FormBuilder.Entities;
using FormBuilder.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.Input;

public class InputRepository(DbContext dbContext) : Repository<InputEntity>(dbContext), IInputRepository
{
}