using MockInterview.Core.Models.Common;

namespace MockInterview.Core.Models.Entities;

/// <summary>
/// Represents one time interview
/// </summary>
public class Interview : IEntity
{
    public long Id { get; set; }

    /// <summary>
    /// Interviewer user Id
    /// </summary>
    public long InterviewerId { get; set; }
    
    /// <summary>
    /// Interviewee user Id
    /// </summary>
    public long IntervieweeId { get; set; }
    
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
    /// Payment made for this interview
    /// </summary>
    public long? PaymentId { get; set; }
}