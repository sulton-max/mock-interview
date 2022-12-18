using MockInterview.Core.Models.Common;
using MockInterview.DAL.Models.Query;

namespace MockInterview.BLL.Services.EntityServices.Interfaces;

/// <summary>
/// Defines common business logic to manipulate entities
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public interface IEntityServiceBase<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Gets a set of entities by filter
    /// </summary>
    /// <param name="queryOptions">Complex query options</param>
    /// <returns>Set of entities after query</returns>
    Task<IEnumerable<TEntity>> GetByFilterAsync(IEntityQueryOptions<TEntity> queryOptions);

    /// <summary>
    /// Gets the entity that has the required id
    /// </summary>
    /// <param name="id">Id of the entity being queried</param>
    /// <returns>Entity if found, or null</returns>
    Task<TEntity?> GetByIdAsync(long id);

    /// <summary>
    /// Gets entities that matches given array of ids
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Array of entities or empty array</returns>
    Task<IEnumerable<TEntity>> GetByIdsAsync(ICollection<long> ids);

    /// <summary>
    /// Creates entry on context scope or on database
    /// </summary>
    /// <param name="entity">Entity to create</param>
    /// <param name="saveChanges">Determines whether to commit changes to Database</param>
    /// <returns>Result of entity creation</returns>
    Task<TEntity?> CreateAsync(TEntity entity, bool saveChanges = true);

    /// <summary>
    /// Updates entity on context scope or on database
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="saveChanges">Determines whether to commit changes to Database</param>
    /// <returns>Result of entity update</returns>
    Task<bool> UpdateAsync(long id, TEntity entity, bool saveChanges = true);

    /// <summary>
    /// Deletes entity on context scope or on database with its Id
    /// </summary>
    /// <param name="id">Id of Entity to delete</param>
    /// <param name="saveChanges">Determines whether to commit changes to Database</param>
    /// <returns>Result of entity deletion</returns>
    Task<bool> DeleteByIdAsync(long id, bool saveChanges = true);

    /// <summary>
    /// Deletes entity on context scope or on database
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="saveChanges">Determines whether to commit changes to Database</param>
    /// <returns>Result of entity deletion</returns>
    Task<bool> DeleteAsync(TEntity entity, bool saveChanges = true);
}
