using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;

namespace MockInterview.API.Controllers;

public class InterviewersController : CustomControllerBase
{
    private readonly IInterviewerService _interviewerService;

    public InterviewersController(IMapper mapper, IInterviewerService interviewerService) : base(mapper)
    {
        _interviewerService = interviewerService;
    }
    
     /// <summary>
    /// Gets specific Interviewer by Id
    /// </summary>
    /// <param name="id">Id of the Interviewer being queried</param>
    /// <returns>Interviewer being queried</returns>
    /// <response code="200">If any Interviewer found </response>
    /// <response code="404">If no Interviewer found</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(InterviewerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var data = await _interviewerService.GetByIdAsync(id);
        return data != null ? Ok(Mapper.Map<InterviewerDto>(data)) : NotFound();
    }

    /// <summary>
    /// Creates a Interviewer
    /// </summary>
    /// <param name="model">Interviewer being created</param>
    /// <returns>Interviewer being created</returns>
    /// <response code="201">If Interviewer creation succeeded</response>
    /// <response code="400">If Interviewer creation failed</response>
    [HttpPost]
    [ProducesResponseType(typeof(InterviewerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] InterviewerDto model)
    {
        var data = await _interviewerService.CreateAsync(Mapper.Map<Interviewer>(model));
        return data != null ? CreatedAtAction(nameof(Create), Mapper.Map<InterviewerDto>(data)) : BadRequest();
    }

    /// <summary>
    /// Updates specific Interviewer
    /// </summary>
    /// <param name="id">Id of the Interviewer being updated</param>
    /// <param name="model">Interviewer being updated</param>
    /// <response code="204">If Interviewer update succeeded</response>
    /// <response code="400">If Interviewer update failed</response>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] InterviewerDto model)
    {
        return await _interviewerService.UpdateAsync(id, Mapper.Map<Interviewer>(model)) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Deletes specific Interviewer by Id
    /// </summary>
    /// <param name="id">Id of the Interviewer being deleted</param>
    /// <returns>OK result if succeeds, else BadRequest</returns>
    /// <response code="200">If Interviewer deletion succeeded</response>
    /// <response code="400">If Interviewer deletion failed</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteById([FromRoute] long id)
    {
        var result = await _interviewerService.DeleteByIdAsync(id);
        return result ? Ok() : BadRequest();
    }
}