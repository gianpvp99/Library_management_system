using Library_management_system.DOMAIN.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Infrastructure.Security
{
    public class JwtTokenGenerator: IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings) => _jwtSettings = jwtSettings.Value;
        public string GenerateToken(int userId, string userEmail)
        {
           
            // CREACIÓN DE CLAIMS //
            var claims = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, "Nombres"),
                new Claim("apellido", "Apellidos"),
                new Claim(JwtRegisteredClaimNames.Email, userEmail),
                new Claim(ClaimTypes.Role, Guid.NewGuid().ToString())
            };

            // CREACIÓN DEL HEADER //
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // CREACIÓN DEL PAYLOAD //
            var payload = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: credentials
            );
            // CREACIÓN DEL TOKEN //
            var token = new JwtSecurityTokenHandler().WriteToken(payload);
            return token;
        }
    }
}
