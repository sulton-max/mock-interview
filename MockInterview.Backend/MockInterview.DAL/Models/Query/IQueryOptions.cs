namespace MockInterview.DAL.Models.Query;

/// <summary>
/// Query options to query a set of entities
/// </summary>
/// <typeparam name="TSource">Query source type</typeparam>
public interface IQueryOptions<TSource> where TSource : class
{
    /// <summary>
    /// Applied filters for a query
    /// </summary>
    FilterOptions<TSource>? FilterOptions { get; set; }

    /// <summary>
    /// Result Sort options 
    /// </summary>
    SortOptions? SortOptions { get; set; }

    /// <summary>
    /// Calculated pagination options
    /// </summary>
    PaginationOptions PaginationOptions { get; set; }
}