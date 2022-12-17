﻿using MockInterview.Core.Models.Common;

namespace MockInterview.Core.Models.Entities;

/// <summary>
/// Represents interviewee details
/// </summary>
public class Interviewee : IEntity
{
    public long Id { get; set; }
    
    /// <summary>
    /// Related user Id
    /// </summary>
    public long UserId { get; set; }
    
    /// <summary>
    /// User projection
    /// </summary>
    public User User { get; set; } = null!;
}