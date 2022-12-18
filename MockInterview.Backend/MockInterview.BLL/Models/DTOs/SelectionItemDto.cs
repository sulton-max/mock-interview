using MockInterview.BLL.Models.Common;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents selection item entity dto
/// </summary>
public class SelectionItemDto : IEntityDto
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