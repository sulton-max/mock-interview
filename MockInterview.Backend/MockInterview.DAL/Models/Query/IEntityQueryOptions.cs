using MockInterview.Core.Models.Common;

namespace MockInterview.DAL.Models.Query;

public interface IEntityQueryOptions<TEntity> : IQueryOptions<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Requested include model options
    /// </summary>
    IncludeOptions<TEntity>? IncludeOptions { get; set; }
}