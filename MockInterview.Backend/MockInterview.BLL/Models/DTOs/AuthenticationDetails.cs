namespace MockInterview.BLL.Models.DTOs
{
    public class AuthenticationDetails
    {
        
        /// <summary>
        /// Email address
        /// </summary>
        public string EmailAddress { get; set; } = null!;
        
        /// <summary>
        /// Account Password
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
