using MockInterview.Core.Models.Entities;
using System.Security.Claims;

namespace MockInterview.BLL.Services.AuthenticationServices.Interfaces
{
    public interface IJwtGenerator
    {
        public (string token, DateTime expires) CreateToken(User user);

        public ClaimsIdentity GetIdentity(User user);
    }
}
