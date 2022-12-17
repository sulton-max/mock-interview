namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents interviewee details
/// </summary>
public class IntervieweeDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// User projection
    /// </summary>
    public UserDto User { get; set; } = null!;
}