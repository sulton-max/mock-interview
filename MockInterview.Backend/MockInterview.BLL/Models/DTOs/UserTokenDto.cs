namespace MockInterview.BLL.Models.DTOs
{
    public class UserTokenDto
    {
        public long Id { get; set; }

        public long? TalentId { get; set; }

        public string Token { get; set; } = null!;

        public DateTime ExpireTime { get; set; }
    }
}
