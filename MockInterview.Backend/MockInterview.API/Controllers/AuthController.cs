using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MockInterview.BLL.Models.DTOs;
using MockInterview.BLL.Services.AuthenticationServices.Interfaces;
using MockInterview.Core.Models.Entities;

namespace MockInterview.API.Controllers
{
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IMapper mapper, IAuthService authService) : base(mapper)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">Login user into system</param>
        /// <returns>Login user into system</returns>
        /// <response code="200">If user login succeeded</response>
        /// <response code="400">If user login failed</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserTokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserTokenDto>> Login([FromBody] AuthenticationDetails model)
        {
            var data = await _authService.LoginAsync(model);
            return data != null ? CreatedAtAction(nameof(Login), Mapper.Map<UserTokenDto>(data)) : Unauthorized();
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="model">Register user</param>
        /// <returns>Register user</returns>
        /// <response code="200">If user register succeeded</response>
        /// <response code="400">If user register failed</response>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserTokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserTokenDto>> Register([FromBody] UserDto model)
        {
            var data = await _authService.RegisterAsync(Mapper.Map<User>(model));
            return data != null ? CreatedAtAction(nameof(Register), Mapper.Map<UserTokenDto>(data)) : Unauthorized();
        }

        /// <summary>
        /// Updates specific user's role
        /// </summary>
        /// <param name="id">Id of the user being updated</param>
        /// <param name="userRole">new role name</param>
        /// <response code="204">If User Role update succeeded</response>
        /// <response code="400">If User Role update failed</response>
        [HttpPut("user/{id:long}/role/{userRole}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRole([FromRoute] long id, [FromRoute] string userRole)
        {
            return await _authService.UpdateUserRoleAsync(id, userRole) ? NoContent() : BadRequest();
        }
    }
}
