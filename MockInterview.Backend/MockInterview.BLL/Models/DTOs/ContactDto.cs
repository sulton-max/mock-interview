namespace MockInterview.BLL.Models.DTOs;

/// <summary>
/// Represents contact information
/// </summary>
public class ContactDto
{
    public long Id { get; set; }
    
    /// <summary>
    /// Phone number with country code
    /// </summary>
    public long PhoneNumber { get; set; }
}