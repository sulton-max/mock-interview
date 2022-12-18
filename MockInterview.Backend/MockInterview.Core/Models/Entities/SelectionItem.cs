using MockInterview.Core.Models.Common;

namespace MockInterview.Core.Models.Entities;

/// <summary>
/// Represents option or selection item entity
/// </summary>
public class SelectionItem : IEntity
{
    public long Id { get; set; }

    /// <summary>
    /// Selection item type
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Item value
    /// </summary>
    public string Value { get; set; } = null!;

    /// <summary>
    /// Item display value
    /// </summary>
    public string DisplayValue { get; set; } = null!;
}