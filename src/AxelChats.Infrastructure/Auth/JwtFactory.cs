using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AxelChats.Infrastructure.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var credentials = new SigningCredentials(_jwtOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenLifeTime);

            var securityToken = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                expires: expires,
                signingCredentials: credentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
