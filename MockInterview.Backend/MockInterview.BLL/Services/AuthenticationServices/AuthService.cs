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
        private readonly IUserRoleService _userRoleService;
        private readonly IInterviewerService _interviewerService;

        public AuthService(IJwtGenerator jwtGenerator, IUserService userService, IUserRoleService userRoleService, IInterviewerService interviewerService)
        {
            _jwtGenerator = jwtGenerator;
            _userService = userService;
            _userRoleService = userRoleService;
            _interviewerService = interviewerService;
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

        public async Task<bool> UpdateUserRoleAsync(long id, string userRole)
        {
            if(id <= 0) 
                throw new ArgumentException();

            User? user = await _userService.GetByIdAsync(id);
            
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(userRole))
                throw new ArgumentNullException(nameof(userRole));

            UserRole? role = await _userRoleService.GetByNameAsync(userRole);

            if(role == null)       
                throw new ArgumentNullException(nameof(role));

            return await Task.Run(async () =>
            {
                user.RoleId = role.Id;

                Interviewer? interviewer = await _interviewerService.CreateAsync(new Interviewer{ UserId = user.Id });
                
                bool userUpdateResult = await _userService.UpdateAsync(id, user);

                return interviewer != null && userUpdateResult;
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
