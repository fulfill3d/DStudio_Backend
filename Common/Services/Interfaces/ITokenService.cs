using DStudio.Common.Core.Model;

namespace DStudio.Common.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(TokenClaim token);
        public bool ValidateToken(string token, TokenClaim tokenClaim);
        public string? GetOidFromToken(string token);
    }
}