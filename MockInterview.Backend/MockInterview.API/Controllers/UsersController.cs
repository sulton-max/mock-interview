using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Models.Query;

namespace MockInterview.API.Controllers;

public class UsersController : CustomControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IMapper mapper, IUserService userService) : base(mapper)
    {
        _userService = userService;
    }
    
    /// <summary>
    /// Gets specific user by Id
    /// </summary>
    /// <param name="id">Id of the user being queried</param>
    /// <returns>User being queried</returns>
    /// <response code="200">If any user found </response>
    /// <response code="404">If no user found</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var data = await _userService.GetByIdAsync(id);
        return data != null ? Ok(Mapper.Map<UserDto>(data)) : NotFound();
    }
    
    /// <summary>
    /// Gets a set of users by filter
    /// </summary>
    /// <param name="filter">Filter for query</param>
    /// <returns>Set of users being queried</returns>
    /// <response code="200">If any users found </response>
    /// <response code="404">If no users found</response>
    [HttpPost("by-filter")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByFilter([FromBody] EntityQueryOptions<User> filter)
    {
        var data = await _userService.GetByFilterAsync(filter);
        return data.Any() ? Ok(Mapper.Map<IEnumerable<UserDto>>(data)) : NotFound();
    }

    /// <summary>
    /// Creates a user
    /// </summary>
    /// <param name="model">User being created</param>
    /// <returns>User being created</returns>
    /// <response code="201">If user creation succeeded</response>
    /// <response code="400">If User creation failed</response>
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] UserDto model)
    {
        var data = await _userService.CreateAsync(Mapper.Map<User>(model));
        return data != null ? CreatedAtAction(nameof(Create), Mapper.Map<UserDto>(data)) : BadRequest();
    }

    /// <summary>
    /// Updates specific user
    /// </summary>
    /// <param name="id">Id of the user being updated</param>
    /// <param name="model">User being updated</param>
    /// <response code="204">If User update succeeded</response>
    /// <response code="400">If User update failed</response>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UserDto model)
    {
        return await _userService.UpdateAsync(id, Mapper.Map<User>(model)) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Deletes specific user by Id
    /// </summary>
    /// <param name="id">Id of the User being deleted</param>
    /// <returns>OK result if succeeds, else BadRequest</returns>
    /// <response code="200">If User deletion succeeded</response>
    /// <response code="400">If User deletion failed</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteById([FromRoute] long id)
    {
        var result = await _userService.DeleteByIdAsync(id);
        return result ? Ok() : BadRequest();
    }
}