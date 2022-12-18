using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MockInterview.Core.Models.Common;
using MockInterview.DAL.Models.Query;

namespace MockInterview.DAL.Extensions;

/// <summary>
/// Provides extension methods to create complex queries
/// </summary>
public static class QueryExtensions
{
    #region Querying

    /// <summary>
    /// Applies given query options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="queryOptions">Query options</param>
    /// <typeparam name="TEntity">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IQueryable<TEntity> ApplyQuery<TEntity>(this IQueryable<TEntity> source, IEntityQueryOptions<TEntity> queryOptions) where TEntity : class, IEntity
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(queryOptions);

        var result = source;

        if (queryOptions.FilterOptions != null)
            result = result.ApplyFiltering(queryOptions.FilterOptions);

        if (queryOptions.IncludeOptions != null)
            result = result.ApplyIncluding(queryOptions.IncludeOptions);

        if (queryOptions.SortOptions != null)
            result = result.ApplySorting(queryOptions.SortOptions);

        result = result.ApplyPagination(queryOptions.PaginationOptions);

        return result;
    }

    /// <summary>
    /// Applies given query options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="queryOptions">Query options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IQueryable<TSource> ApplyQuery<TSource>(this IQueryable<TSource> source, IQueryOptions<TSource> queryOptions) where TSource : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(queryOptions);

        var result = source;

        if (queryOptions.FilterOptions != null)
            result = result.ApplyFiltering(queryOptions.FilterOptions);

        if (queryOptions.SortOptions != null)
            result = result.ApplySorting(queryOptions.SortOptions);

        result = result.ApplyPagination(queryOptions.PaginationOptions);

        return result;
    }

    /// <summary>
    /// Applies given query options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="queryOptions">Query options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IEnumerable<TSource> ApplyQuery<TSource>(this IEnumerable<TSource> source, IQueryOptions<TSource> queryOptions) where TSource : class 
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(queryOptions);
        
        var result = source;

        if (queryOptions.FilterOptions != null)
            result = result.ApplyFiltering(queryOptions.FilterOptions);

        if(queryOptions.SortOptions != null)
            result = result.ApplySorting(queryOptions.SortOptions);

        result = result.ApplyPagination(queryOptions.PaginationOptions);

        return result;
    }

    #endregion

    #region Filtering

    /// <summary>
    /// Creates expression from filter options
    /// </summary>
    /// <param name="filterOptions">Filters</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static Expression<Func<TSource, bool>> GetFilterExpression<TSource>(this FilterOptions<TSource> filterOptions) where TSource : class
    {
        ArgumentNullException.ThrowIfNull(filterOptions);

        // Get the properties type  of entity
        var parameter = Expression.Parameter(typeof(TSource));
        var properties = typeof(TSource).GetProperties();

        // Convert filters to predicate expressions
        var predicates = filterOptions.Filters.Where(x => properties.Any(y => y.Name == x.Key))
            .Select(x =>
            {
                // Create predicate expression
                var property = properties.First(y => y.Name == x.Key);
                var member = Expression.PropertyOrField(parameter, x.Key);

                // Create specific expression based on type
                var compareMethod = property.PropertyType.GetCompareMethod();
                var argument = Expression.Convert(Expression.Constant(x.GetValue(property.PropertyType)), property.PropertyType);
                var methodCaller = Expression.Call(member, compareMethod, argument);
                return Expression.Lambda<Func<TSource, bool>>(methodCaller, parameter);
            })
            .ToList();

        // Join predicate expressions\
        var finalExpression = PredicateBuilder<TSource>.True;
        predicates.ForEach(x => finalExpression = PredicateBuilder<TSource>.And(finalExpression, x));

        return finalExpression;
    }

    /// <summary>
    /// Applies given filter options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="filterOptions">Filter options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IQueryable<TSource> ApplyFiltering<TSource>(this IQueryable<TSource> source, FilterOptions<TSource> filterOptions) where TSource : class =>
        source.Where(filterOptions.GetFilterExpression());

    /// <summary>
    /// Applies given filter options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="filterOptions">Filter options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IEnumerable<TSource> ApplyFiltering<TSource>(this IEnumerable<TSource> source, FilterOptions<TSource> filterOptions) where TSource : class =>
        source.Where(filterOptions.GetFilterExpression().Compile());

    #endregion

    #region Including

    /// <summary>
    /// Applies given include models options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="includeOptions">Include models options</param>
    /// <typeparam name="TEntity">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IQueryable<TEntity> ApplyIncluding<TEntity>(this IQueryable<TEntity> source, IncludeOptions<TEntity> includeOptions) where TEntity : class, IEntity
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(includeOptions);

        // Get the properties type  of entity
        var parameter = Expression.Parameter(typeof(TEntity));
        var properties = typeof(TEntity).GetProperties();

        // Include models
        var includeProperties = typeof(TEntity).GetProperties().Where(x => x.PropertyType.IsClass && includeOptions.IncludeModels.Contains(x.Name)).ToList();
        includeProperties.ForEach(x => { source.Include(x.Name); });

        return source;
    }

    #endregion

    #region Sorting

    /// <summary>
    /// Applies given sorting options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="sortOptions">Sort options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IQueryable<TSource> ApplySorting<TSource>(this IQueryable<TSource> source, SortOptions sortOptions) where TSource : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(sortOptions);

        // Get the properties type  of entity
        var parameter = Expression.Parameter(typeof(TSource));
        var properties = typeof(TSource).GetProperties();

        // Apply sorting
        var matchingProperty = properties.FirstOrDefault(x => x.Name == sortOptions.SortField) ?? throw new InvalidOperationException();
        var memExp = Expression.Convert(Expression.PropertyOrField(parameter, matchingProperty.Name), typeof(object));
        var keySelector = Expression.Lambda<Func<TSource, dynamic>>(memExp, true, parameter);
        return sortOptions.SortAscending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
    }

    /// <summary>
    /// Applies given sorting options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="sortOptions">Sort options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IEnumerable<TSource> ApplySorting<TSource>(this IEnumerable<TSource> source, SortOptions sortOptions) where TSource : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(sortOptions);

        // Get the properties type  of entity
        var parameter = Expression.Parameter(typeof(TSource));
        var properties = typeof(TSource).GetProperties();

        // Apply sorting
        var matchingProperty = properties.FirstOrDefault(x => x.Name == sortOptions.SortField) ?? throw new InvalidOperationException();
        var memExp = Expression.PropertyOrField(parameter, matchingProperty.Name);
        var keySelector = Expression.Lambda<Func<TSource, object>>(memExp, true, parameter).Compile();

        return sortOptions.SortAscending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
    }

    #endregion

    #region Pagination

    /// <summary>
    /// Applies given sorting options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="paginationOptions">Sort options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, PaginationOptions paginationOptions)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(paginationOptions);

        return source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
    }

    /// <summary>
    /// Applies given sorting options to query source
    /// </summary>
    /// <param name="source">Query source</param>
    /// <param name="paginationOptions">Sort options</param>
    /// <typeparam name="TSource">Query source type</typeparam>
    /// <returns>Queryable source</returns>
    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, PaginationOptions paginationOptions)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(paginationOptions);

        return source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
    }

    #endregion
}