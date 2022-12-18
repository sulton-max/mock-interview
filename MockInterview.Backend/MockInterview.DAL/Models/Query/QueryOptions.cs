namespace MockInterview.DAL.Models.Query;

public class QueryOptions<TSource> : IQueryOptions<TSource> where TSource : class
{
    public FilterOptions<TSource>? FilterOptions { get; set; }
    
    public SortOptions? SortOptions { get; set; }

    public PaginationOptions PaginationOptions { get; set; } = null!;
}