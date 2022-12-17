namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents interviewer details
/// </summary>
public class InterviewerDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// User projection
    /// </summary>
    public UserDto User { get; set; } = null!;
}