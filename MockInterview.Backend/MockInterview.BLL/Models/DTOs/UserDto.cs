using MockInterview.BLL.Models.Common;

namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents system user
/// </summary>
public class UserDto : IEntityDto
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
    /// Contact projection
    /// </summary>
    public ContactDto? Contact { get; set; }
    
    /// <summary>
    /// Talent projection
    /// </summary>
    public TalentDto? Talent { get; set; }

    /// <summary>
    /// User Role projection
    /// </summary>
    public UserRoleDto? Role { get; set;} 
}