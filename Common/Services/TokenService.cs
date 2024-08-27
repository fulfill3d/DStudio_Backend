using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DStudio.Common.Core.Model;
using DStudio.Common.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DStudio.Common.Services
{

    public class TokenService(IOptions<TokenValidationOption> validation) : ITokenService
    {
        private readonly string _securityKey = validation.Value.SecurityKey;

        public string GenerateToken(TokenClaim tokenClaim)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("CompanyName", tokenClaim.CompanyName),
                new Claim("AppName", tokenClaim.AppName),
                new Claim("oid", tokenClaim.OID)
            };

            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: tokenClaim.OID,
                claims: claims,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token, TokenClaim tokenClaim)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_securityKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // Extract claims
                var appName = jwtToken.Claims.First(x => x.Type == "AppName").Value;
                var companyName = jwtToken.Claims.First(x => x.Type == "CompanyName").Value;

                // Additional claims validation
                if (appName != tokenClaim.AppName)
                {
                    return false;
                }

                if (companyName != tokenClaim.CompanyName)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string? GetOidFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var oid = jwtToken?.Claims.First(x => x.Type == "oid").Value;
                return oid;
            }
            catch
            {
                return null;
            }
        }

    }
}