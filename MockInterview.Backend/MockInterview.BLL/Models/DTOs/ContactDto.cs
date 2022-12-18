using MockInterview.BLL.Models.Common;

namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents contact information
/// </summary>
public class ContactDto : IEntityDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// Phone number with country code
    /// </summary>
    public long PhoneNumber { get; set; }
}