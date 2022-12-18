using MockInterview.BLL.Models.DTOs;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Services.AuthenticationServices.Interfaces
{
    public interface IAuthService
    {
        Task<UserTokenDto> LoginAsync(AuthenticationDetails model);

        Task<UserTokenDto> RegisterAsync(User model);

        Task<bool> UpdateUserRoleAsync(long id, string userRole);
    }
}
