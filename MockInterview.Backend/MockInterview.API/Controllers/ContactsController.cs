using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;

namespace MockInterview.API.Controllers;

public class ContactsController : CustomControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IMapper mapper, IContactService contactService) : base(mapper)
    {
        _contactService = contactService;
    }
    
    /// <summary>
    /// Gets specific Contact by Id
    /// </summary>
    /// <param name="id">Id of the Contact being queried</param>
    /// <returns>Contact being queried</returns>
    /// <response code="200">If any Contact found </response>
    /// <response code="404">If no Contact found</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(ContactDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Contact>> GetById([FromRoute] long id)
    {
        var data = await _contactService.GetByIdAsync(id);
        return data != null ? Ok(Mapper.Map<ContactDto>(data)) : NotFound();
    }

    /// <summary>
    /// Creates a Contact
    /// </summary>
    /// <param name="model">Contact being created</param>
    /// <returns>Contact being created</returns>
    /// <response code="201">If Contact creation succeeded</response>
    /// <response code="400">If Contact creation failed</response>
    [HttpPost]
    [ProducesResponseType(typeof(ContactDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Create([FromBody] ContactDto model)
    {
        var data = await _contactService.CreateAsync(Mapper.Map<Contact>(model));
        return data != null ? CreatedAtAction(nameof(Create), Mapper.Map<ContactDto>(data)) : BadRequest();
    }

    /// <summary>
    /// Updates specific Contact
    /// </summary>
    /// <param name="id">Id of the Contact being updated</param>
    /// <param name="model">Contact being updated</param>
    /// <response code="204">If Contact update succeeded</response>
    /// <response code="400">If Contact update failed</response>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update([FromRoute] long id, [FromBody] ContactDto model)
    {
        return await _contactService.UpdateAsync(id, Mapper.Map<Contact>(model)) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Deletes specific Contact by Id
    /// </summary>
    /// <param name="id">Id of the Contact being deleted</param>
    /// <returns>OK result if succeeds, else BadRequest</returns>
    /// <response code="200">If Contact deletion succeeded</response>
    /// <response code="400">If Contact deletion failed</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteById([FromRoute] long id)
    {
        var result = await _contactService.DeleteByIdAsync(id);
        return result ? Ok() : BadRequest();
    }


}