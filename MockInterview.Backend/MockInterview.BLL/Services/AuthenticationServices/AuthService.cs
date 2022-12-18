using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.AuthenticationServices.Interfaces;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;

namespace MockInterview.BLL.Services.AuthenticationServices
{
    public class AuthService : IAuthService
    {
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserService _userService;

        public AuthService(IJwtGenerator jwtGenerator, IUserService userService)
        {
            _jwtGenerator = jwtGenerator;
            _userService = userService;
        }

        public async Task<UserTokenDto?> LoginAsync(AuthenticationDetails model)
        {
            if(model == null) 
                throw new ArgumentNullException(nameof(model)); 

            User? user = await _userService.GetByEmailAddressAsync(model.EmailAddress);
            if(user == null)
                throw new EntryPointNotFoundException("User not found");

            if(await CheckPasswordAsync(user, model.Password))
            {
                return await Task.Run(async () =>
                {
                    return await GetTokenAsync(model);
                });
            }

            return null;
        }

        public async Task<UserTokenDto> RegisterAsync(User model)
        {
            if(model == null) 
                throw new ArgumentNullException(nameof(model));

            return await Task.Run(async () =>
            {
                User? user = await _userService.CreateAsync(model);
                return await GetTokenAsync(new AuthenticationDetails { EmailAddress = user.EmailAddress, Password = user.Password});
            });
        }

        private async Task<UserTokenDto> GetTokenAsync(AuthenticationDetails model)
        {
            if(model == null) 
                throw new ArgumentNullException(nameof(model)); 

            User? user = await _userService.GetByEmailAddressAsync(model.EmailAddress);
            if(user == null)
                throw new EntryPointNotFoundException("User not found");

            var tokenResult = _jwtGenerator.CreateToken(user);

            return await Task.Run(() =>{
                return new UserTokenDto
                {
                      Id = user.Id,
                      TalentId = user.TalentId,
                      Token = tokenResult.token,
                      ExpireTime = tokenResult.expires
                };
            });
        }

        private async Task<bool> CheckPasswordAsync(User user, string password)
        {
            if(user == null) 
                throw new ArgumentNullException(nameof(user)); 

            if(password == null) 
                throw new ArgumentNullException(nameof(password)); 

            return await Task.Run(() =>
            {
                return user.Password.Equals(password);
            });
        }
    }
}
