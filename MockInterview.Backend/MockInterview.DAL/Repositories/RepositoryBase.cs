using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MockInterview.Core.Models.Common;
using MockInterview.DAL.Contexts;
using MockInterview.DAL.Repositories.Interfaces;

namespace MockInterview.DAL.Repositories;

/// <summary>
/// Provides methods for generic entity repository base to manipulate data
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
{ 
    public ApplicationDbContext Context { get; private set; }

    public RepositoryBase(ApplicationDbContext context)
    {
        Context = context;
    }

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
    {
        return Context.Set<TEntity>().Where(expression);
    }

    public void Create(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }    
    
    public bool SaveChanges()
    {
        return Context.SaveChanges() > 0;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await Task.Run(async () => await Context.SaveChangesAsync() > 0);
    }

    public void Detach(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Detached;
    }
}
