﻿using MockInterview.Core.Models.Common;

namespace MockInterview.DAL.Models.Query;

/// <summary>
/// Represents queryable entities source query options
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class EntityQueryOptions<TEntity> : IEntityQueryOptions<TEntity> where TEntity : class, IEntity
{
    public SearchOptions<TEntity>? SearchOptions { get; set; }
    
    public FilterOptions<TEntity>? FilterOptions { get; set; }
    
    public IncludeOptions<TEntity>? IncludeOptions { get; set; }
    
    public SortOptions? SortOptions { get; set; }
    
    public PaginationOptions PaginationOptions { get; set; } = null!;
}