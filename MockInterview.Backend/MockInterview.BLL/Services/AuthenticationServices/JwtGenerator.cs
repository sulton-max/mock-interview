using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MockInterview.BLL.Models.Configurations;
using MockInterview.BLL.Services.AuthenticationServices.Interfaces;
using MockInterview.Core.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MockInterview.BLL.Services.AuthenticationServices
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public JwtGenerator(IConfiguration config)
        {
            _configuration = config;
            string key = "mysupersecretkey";
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public (string token, DateTime expires) CreateToken(User user)
        {
            var expires = DateTime.UtcNow.AddDays(1);

            if(user == null)
                throw new ArgumentNullException(nameof(user));

            var identity = GetIdentity(user);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                notBefore: now,
                expires: expires,
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return (encodedJwt, expires);
        }

        public ClaimsIdentity GetIdentity(User user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            if(string.IsNullOrWhiteSpace(user.EmailAddress))
                throw new ArgumentException(nameof(user.EmailAddress));

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.EmailAddress),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name),
                new Claim(ApplicationClaims.UserId, user.Id.ToString())
            };

            if(user.TalentId != null || user.TalentId > 0)
                claims.Add(new Claim(ApplicationClaims.TalentId, user.TalentId.Value.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "JwtAuth", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return identity;
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApplicationClaims.Key));
        }
    }
}
