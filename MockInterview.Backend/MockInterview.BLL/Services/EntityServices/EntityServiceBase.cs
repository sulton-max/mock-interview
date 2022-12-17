using Microsoft.EntityFrameworkCore;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Exceptions;
using MockInterview.Core.Models.Common;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides common business logic for manipulating entities
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TRepository"></typeparam>
public class EntityServiceBase<TEntity, TRepository> : IEntityServiceBase<TEntity> where TEntity : class, IEntity where TRepository : IRepositoryBase<TEntity>
{
    protected readonly TRepository EntityRepository;

    public EntityServiceBase(TRepository entityRepository)
    {
        EntityRepository = entityRepository;
    }

    public virtual async Task<TEntity?> GetByIdAsync(long id)
    {
        if (id <= 0)
            throw new ArgumentException();

        return await Task.Run(() => EntityRepository.Get(x => x.Id == id).AsNoTracking().FirstOrDefault());
    }

    public virtual async Task<IEnumerable<TEntity>> GetByIdsAsync(ICollection<long> ids)
    {
        if (ids.Any())
            throw new ArgumentException();

        return await Task.Run(() => EntityRepository.Get(x => ids.Contains(x.Id)).ToList());
    }

    public virtual async Task<TEntity?> CreateAsync(TEntity entity, bool saveChanges = true)
    {
        if (entity == null)
            throw new ArgumentException();

        return await Task.Run(async () =>
        {
            entity.Id = 0;
            EntityRepository.Create(entity);
            return saveChanges ? await EntityRepository.SaveChangesAsync() ? entity : throw new InvalidOperationException() : entity;
        });
    }

    public virtual async Task<bool> UpdateAsync(long id, TEntity entity, bool saveChanges = true)
    {
        if (id <= 0 || entity == null || id != entity.Id)
            throw new ArgumentException();

        return await Task.Run(async () =>
        {
            var foundEntity = await GetByIdAsync(id) ?? throw new EntryNotFoundException(typeof(TEntity).FullName);
            EntityRepository.Update(entity);
            return !saveChanges || await EntityRepository.SaveChangesAsync();
        });
    }

    public virtual async Task<bool> DeleteByIdAsync(long id, bool saveChanges = true)
    {
        if (id <= 0)
            throw new ArgumentException($"Couldn't delete {nameof(TEntity)} due to invalid id");

        return await Task.Run(async () =>
        {
            var entity = EntityRepository.Get(x => x.Id == id).FirstOrDefault() ?? throw new EntryNotFoundException(typeof(TEntity).FullName);
            return await DeleteAsync(entity, saveChanges);
        });
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity, bool saveChanges = true)
    {
        if (entity == null)
            throw new ArgumentException($"Couldn't delete {nameof(TEntity)} due to invalid model");

        return await Task.Run(async () =>
        {
            EntityRepository.Delete(entity);
            return !saveChanges || await EntityRepository.SaveChangesAsync();
        });
    }
}