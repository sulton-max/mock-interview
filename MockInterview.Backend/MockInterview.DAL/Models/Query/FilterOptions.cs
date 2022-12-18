﻿namespace MockInterview.DAL.Models.Query;

public class FilterOptions<TSource> where TSource : class
{
    public FilterOptions()
    {
        Filters = new List<QueryFilter>();
    }

    public IEnumerable<QueryFilter> Filters { get; set; }

    public QueryFilter? this[string key]
    {
        get { return Filters.FirstOrDefault(x => x.Key == key); }
    }
}