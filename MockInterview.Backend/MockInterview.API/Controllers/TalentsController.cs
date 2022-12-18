using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;

namespace MockInterview.API.Controllers;

public class TalentsController : CustomControllerBase
{
    private readonly ITalentService _talentService;

    public TalentsController(IMapper mapper, ITalentService talentService) : base(mapper)
    {
        _talentService = talentService;
    }

    /// <summary>
    /// Gets specific Talent by Id
    /// </summary>
    /// <param name="id">Id of the Talent being queried</param>
    /// <returns>Talent being queried</returns>
    /// <response code="200">If any Talent found </response>
    /// <response code="404">If no Talent found</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(TalentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Talent>> GetById([FromRoute] long id)
    {
        var data = await _talentService.GetByIdAsync(id);
        return data != null ? Ok(Mapper.Map<TalentDto>(data)) : NotFound();
    }

    /// <summary>
    /// Creates a Talent
    /// </summary>
    /// <param name="model">Talent being created</param>
    /// <returns>Talent being created</returns>
    /// <response code="201">If Talent creation succeeded</response>
    /// <response code="400">If Talent creation failed</response>
    [HttpPost]
    [ProducesResponseType(typeof(TalentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Talent>> Create([FromBody] TalentDto model)
    {
        var data = await _talentService.CreateAsync(Mapper.Map<Talent>(model));
        return data != null ? CreatedAtAction(nameof(Create), Mapper.Map<TalentDto>(data)) : BadRequest();
    }

    /// <summary>
    /// Updates specific Talent
    /// </summary>
    /// <param name="id">Id of the Talent being updated</param>
    /// <param name="model">Talent being updated</param>
    /// <response code="204">If Talent update succeeded</response>
    /// <response code="400">If Talent update failed</response>
    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update([FromRoute] long id, [FromBody] TalentDto model)
    {
        return await _talentService.UpdateAsync(id, Mapper.Map<Talent>(model)) ? NoContent() : BadRequest();
    }

    /// <summary>
    /// Deletes specific Talent by Id
    /// </summary>
    /// <param name="id">Id of the Talent being deleted</param>
    /// <returns>OK result if succeeds, else BadRequest</returns>
    /// <response code="200">If Talent deletion succeeded</response>
    /// <response code="400">If Talent deletion failed</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteById([FromRoute] long id)
    {
        var result = await _talentService.DeleteByIdAsync(id);
        return result ? Ok() : BadRequest();
    }
}