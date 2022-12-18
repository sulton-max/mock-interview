using MockInterview.BLL.Models.Common;

namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents interviewee details
/// </summary>
public class IntervieweeDto : IEntityDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// User projection
    /// </summary>
    public UserDto User { get; set; } = null!;
}