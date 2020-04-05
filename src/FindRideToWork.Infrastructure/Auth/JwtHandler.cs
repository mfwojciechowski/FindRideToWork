using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindRideToWork.Infrastructure.Settings;
using FindRideToWork.Infrastructure.Utils;
using Microsoft.IdentityModel.Tokens;

namespace FindRideToWork.Infrastructure.Auth
{
    public class JwtHandler : IJwtHandler
    {        
        private readonly JwtSettings _jwtSettings;
        private readonly SecurityKey _issuerAuthKey;
        private readonly SigningCredentials _signinCredentials;
        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _issuerAuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.AuthKey));
            _signinCredentials = new SigningCredentials(_issuerAuthKey, SecurityAlgorithms.HmacSha256);
        }
        public JsonWebToken CreateToken(Guid userId, string role)
        {
            var now = DateTime.Now;
            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp())
            };

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: _signinCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JsonWebToken
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };

        }
    }
}