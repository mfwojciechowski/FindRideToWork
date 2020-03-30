using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindRideToWork.Infrastructure.Settings;
using FindRideToWork.Infrastructure.Utils;
using Microsoft.IdentityModel.Tokens;

namespace FindRideToWork.Infrastructure.Services
{
    public class JwtDTO {
        public string Token { get; set; }
        public string Expiry { get; set; }

    }
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;
        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public JwtDTO CreateToken(Guid userId, string role)
        {
            var now = DateTime.Now;
            var expiry = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var testexpirty = expiry.ToTimestamp();
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp())
            };

            var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.AuthKey)), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expiry,
                signingCredentials: signinCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtDTO
            {
                Token = token,
                Expiry = expiry.ToTimestamp()
            };

        }
    }
}