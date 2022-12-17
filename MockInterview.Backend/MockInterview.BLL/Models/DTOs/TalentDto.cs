﻿namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents talented person
/// </summary>
public class TalentDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// Current level
    /// </summary>
    public string Level { get; set; } = null!;

    /// <summary>
    /// Earned experience
    /// </summary>
    public string Experience { get; set; } = null!;

    /// <summary>
    /// Worked projects
    /// </summary>
    public string Projects { get; set; } = null!;
}