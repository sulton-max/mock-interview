using MockInterview.BLL.Models.Common;

namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents interviewer details
/// </summary>
public class InterviewerDto : IEntityDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// User projection
    /// </summary>
    public UserDto User { get; set; } = null!;
}