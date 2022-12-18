using MockInterview.Core.Models.Common;

namespace MockInterview.Core.Models.Entities;

/// <summary>
/// Represents system user
/// </summary>
public class User : IEntity
{
    public long Id { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Lastname 
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Email address
    /// </summary>
    public string EmailAddress { get; set; } = null!;

    /// <summary>
    /// Gender
    /// </summary>
    public string Gender { get; set; } = null!;

    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>
    /// Stored photo Id
    /// </summary>
    public long PhotoStorageId { get; set; }

    /// <summary>
    /// Account password
    /// </summary>
    public string Password { get; set; } = null!;
    
    /// <summary>
    /// Related contact Id
    /// </summary>
    public long ContactId { get; set; }
    
    /// <summary>
    /// Related talent Id
    /// </summary>
    public long? TalentId { get; set; }

    /// <summary>
    /// Contact projection
    /// </summary>
    public Contact Contact { get; set; } = null!;
    
    /// <summary>
    /// Talent projection
    /// </summary>
    public Talent? Talent { get; set; }
}