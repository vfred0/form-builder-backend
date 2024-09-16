using FormBuilder.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repositories.Repository;

public abstract class Repository<TEntity>(DbContext dbContext) : IRepository<TEntity>
    where TEntity : EntityBase;