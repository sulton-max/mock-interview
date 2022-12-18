using MockInterview.Core.Models.Common;

namespace MockInterview.Core.Models.Entities;

/// <summary>
/// Represents contact information
/// </summary>
public class Contact : IEntity
{
    public long Id { get; set; }
    
    /// <summary>
    /// Phone number with country code
    /// </summary>
    public long PhoneNumber { get; set; }
}