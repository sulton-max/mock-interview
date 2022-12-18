using MockInterview.Core.Models.Entities;
using MockInterview.Core.Models.Enums;

namespace MockInterview.BLL.Services.EntityServices.Interfaces;

/// <summary>
/// Defines methods for selectable item resource business Logic
/// </summary>
public interface ISelectionItemService : IEntityServiceBase<SelectionItem>
{
    /// <summary>
    /// Gets the collection of SelectionItems with type
    /// </summary>
    /// <param name="types">type of the SelectionItem entity being queried.</param>
    /// <returns>A collection of SelectionItems</returns>
    Task<IEnumerable<SelectionItem>> GetByCategoryAsync(SelectionItemTypes types);
}
