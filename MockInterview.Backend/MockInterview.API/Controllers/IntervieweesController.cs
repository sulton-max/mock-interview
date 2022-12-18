using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices;
using MockInterview.Core.Models.Entities;

namespace MockInterview.API.Controllers;

public class IntervieweesController : CustomControllerBase
{
    private readonly IntervieweeService _intervieweeService;

    public IntervieweesController(IMapper mapper, IntervieweeService intervieweeService) : base(mapper)
    {
        _intervieweeService = intervieweeService;
    }

    /// <summary>
    /// Gets specific Interviewee by Id
    /// </summary>
    /// <param name="id">Id of the Interviewee being queried</param>
    /// <returns>Interviewee being queried</returns>
    /// <response code="200">If any Interviewee found </response>
    /// <response code="404">If no Interviewee found</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(IntervieweeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var data = await _intervieweeService.GetByIdAsync(id);
        return data != null ? Ok(Mapper.Map<IntervieweeDto>(data)) : NotFound();
    }

    /// <summary>
    /// Creates a Interviewee
    /// </summary>
    /// <param name="model">Interviewee being created</param>
    /// <returns>Interviewee being created</returns>
    /// <response code="201">If Interviewee creation succeeded</response>
    /// <response code="400">If Interviewee creation failed</response>
    [HttpPost]
    [ProducesResponseType(typeof(IntervieweeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] IntervieweeDto model)
    {
        var data = await _intervieweeService.CreateAsync(Mapper.Map<Interviewee>(model));
        return data != null ? CreatedAtAction(nameof(Create), Mapper.Map<IntervieweeDto>(data)) : BadRequest();
    }

    /// <summary>
    /// Updates specific Interviewee
    /// </summary>
    /// <param name="id">Id of the Interviewee being updated</param>
    /// <param name="model">Interviewee being updated</param>
    /// <response code="204">If Interviewee update succeeded</response>
    /// <response code="400">If Interviewee update failed</response>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] IntervieweeDto model)
    {
        return await _intervieweeService.UpdateAsync(id, Mapper.Map<Interviewee>(model)) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Deletes specific Interviewee by Id
    /// </summary>
    /// <param name="id">Id of the Interviewee being deleted</param>
    /// <returns>OK result if succeeds, else BadRequest</returns>
    /// <response code="200">If Interviewee deletion succeeded</response>
    /// <response code="400">If Interviewee deletion failed</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteById([FromRoute] long id)
    {
        var result = await _intervieweeService.DeleteByIdAsync(id);
        return result ? Ok() : BadRequest();
    }
}