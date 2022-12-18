using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Extensions;
using MockInterview.Core.Models.Enums;

namespace MockInterview.API.Controllers;

public class SelectionItemsController : CustomControllerBase
{
    private readonly ISelectionItemService _selectionItemService;

    
    public SelectionItemsController(IMapper mapper, ISelectionItemService selectionItemService) : base(mapper)
    {
        _selectionItemService = selectionItemService;
    }
    
    /// <summary>
    /// Gets a set of selection items by type
    /// </summary>
    /// <param name="type">Type of the selection item being queried</param>
    /// <returns>List collection of selection items</returns>
    /// <response code="200">If any selection items found</response>
    /// <response code="404">If no selection items found</response>
    [HttpGet]
    [ProducesResponseType(typeof(SelectionItemDto[]),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByType([FromQuery] string type)
    {
        var data = await _selectionItemService.GetByCategoryAsync(type.ToEnum<SelectionItemTypes>());
        return data.Any() ? Ok(Mapper.Map<IEnumerable<SelectionItemDto>>(data)) : NotFound();
    }
}