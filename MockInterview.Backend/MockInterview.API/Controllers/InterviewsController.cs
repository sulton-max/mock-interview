using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Models.Query;

namespace MockInterview.API.Controllers;

public class InterviewsController : CustomControllerBase
{
    private readonly IInterviewService _interviewService;

    public InterviewsController(IMapper mapper, IInterviewService interviewService) : base(mapper)
    {
        _interviewService = interviewService;
    }
    
     /// <summary>
    /// Gets specific Interview by Id
    /// </summary>
    /// <param name="id">Id of the Interview being queried</param>
    /// <returns>Interview being queried</returns>
    /// <response code="200">If any Interview found </response>
    /// <response code="404">If no Interview found</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(InterviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var data = await _interviewService.GetByIdAsync(id);
        return data != null ? Ok(Mapper.Map<InterviewDto>(data)) : NotFound();
    }
     
     /// <summary>
     /// Gets a set of interviews by filter
     /// </summary>
     /// <param name="filter">Filter for query</param>
     /// <returns>Set of interviews being queried</returns>
     /// <response code="200">If any interviews found </response>
     /// <response code="404">If no interviews found</response>
     [HttpPost("by-filter")]
     [ProducesResponseType(typeof(InterviewDto), StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     public async Task<IActionResult> GetByFilter([FromBody] EntityQueryOptions<Interview> filter)
     {
         var data = await _interviewService.GetByFilterAsync(filter);
         return data.Any() ? Ok(Mapper.Map<IEnumerable<InterviewDto>>(data)) : NotFound();
     }

    /// <summary>
    /// Creates a Interview
    /// </summary>
    /// <param name="model">Interview being created</param>
    /// <returns>Interview being created</returns>
    /// <response code="201">If Interview creation succeeded</response>
    /// <response code="400">If Interview creation failed</response>
    [HttpPost]
    [ProducesResponseType(typeof(InterviewDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] InterviewDto model)
    {
        var data = await _interviewService.CreateAsync(Mapper.Map<Interview>(model));
        return data != null ? CreatedAtAction(nameof(Create), Mapper.Map<InterviewDto>(data)) : BadRequest();
    }

    /// <summary>
    /// Updates specific Interview
    /// </summary>
    /// <param name="id">Id of the Interview being updated</param>
    /// <param name="model">Interview being updated</param>
    /// <response code="204">If Interview update succeeded</response>
    /// <response code="400">If Interview update failed</response>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] InterviewDto model)
    {
        return await _interviewService.UpdateAsync(id, Mapper.Map<Interview>(model)) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Deletes specific Interview by Id
    /// </summary>
    /// <param name="id">Id of the Interview being deleted</param>
    /// <returns>OK result if succeeds, else BadRequest</returns>
    /// <response code="200">If Interview deletion succeeded</response>
    /// <response code="400">If Interview deletion failed</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteById([FromRoute] long id)
    {
        var result = await _interviewService.DeleteByIdAsync(id);
        return result ? Ok() : BadRequest();
    }
}