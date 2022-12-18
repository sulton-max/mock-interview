using MockInterview.BLL.Models.Common;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents one time interview
/// </summary>
public class InterviewDto : IEntityDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// Interview record created date
    /// </summary>
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// Interview record updated date
    /// </summary>
    public DateTime UpdatedDate { get; set; }
    
    /// <summary>
    /// Decided time
    /// </summary>
    public DateTime InterviewTime { get; set; }

    /// <summary>
    /// Current status
    /// </summary>
    public string Status { get; set; } = null!;
    
    /// <summary>
    /// Related interviewer projection
    /// </summary>
    public InterviewerDto Interviewer { get; set; } = null!;

    /// <summary>
    /// Related interviewee projection
    /// </summary>
    public IntervieweeDto Interviewee { get; set; } = null!;
}