using System.Linq.Expressions;
using MockInterview.Core.Models.Common;
using MockInterview.DAL.Contexts;

namespace MockInterview.DAL.Repositories.interfaces;

/// <summary>
/// Defines common behaviors for entity generic repository base
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public interface IRepositoryBase<TEntity> 
    where TEntity : class, IEntity
{
    /// <summary>
    /// Database context to access to Database 
    /// </summary>
    ApplicationDbContext Context { get; }

    /// <summary>
    /// Gets entities matching the predicate
    /// </summary>
    /// <param name="expression"></param>
    /// <returns>Entities query</returns>
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Creates entity on context scope
    /// </summary>
    /// <param name="entity"> Entity to create</param>
    void Create(TEntity entity);

    /// <summary>
    /// Updates entity on context scope
    /// </summary>
    /// <param name="entity">Entity to update</param>
    void Update(TEntity entity);

    /// <summary>
    /// Deletes entity on context scope
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Sends context changes to the Database
    /// </summary>
    /// <returns>Result of whether any columns affected</returns>
    bool SaveChanges();

    /// <summary>
    /// Sends context changes to the Database
    /// </summary>
    /// <returns>Result of whether any columns affected</returns>
    Task<bool> SaveChangesAsync();

    /// <summary>
    /// Disables entity change tracking 
    /// </summary>
    /// <param name="entity">Entity to detach</param>
    void Detach(TEntity entity);

}
