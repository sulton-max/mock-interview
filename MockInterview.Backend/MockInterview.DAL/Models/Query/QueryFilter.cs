namespace MockInterview.DAL.Models.Query;

/// <summary>
/// Represents queryable source query options
/// </summary>
public class QueryFilter
{
    /// <summary>
    /// Field key name
    /// </summary>
    public string Key { get; set; } = null!;

    /// <summary>
    /// Filtering value
    /// </summary>
    public string Value { get; set; } = null!;
}