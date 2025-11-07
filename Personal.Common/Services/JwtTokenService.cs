using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Personal.Common.Domain;
using Personal.Common.Domain.Interfaces.Services;
using Personal.Common.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Personal.Common.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

    
        public Result GenerateToken(string userName)
        {
            try
            {
                
                var secretKey = _jwtSettings.Key;
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                // 2) credenciais de assinatura
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 3) claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                };

                // 4) criar token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
                    SigningCredentials = creds,
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience
                };

                var handler = new JwtSecurityTokenHandler();
                var token = handler.CreateToken(tokenDescriptor);
                var jwt = handler.WriteToken(token);

                return Result<string>.Success(jwt);
            }
            catch(Exception e )
            {
                return Result.Failure("500", e.Message);
            }
        }
    }
}
