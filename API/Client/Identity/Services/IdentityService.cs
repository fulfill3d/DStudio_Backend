using DStudio.Common.Core.Model;
using DStudio.Common.Database.Models;
using DStudio.Common.Services.Interfaces;
using Identity.Data.Database;
using Identity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class IdentityService(
        IdentityContext dbContext,
        ITokenService tokenService) : IIdentityService
    {

        public async Task<string> Register()
        {
            var oid = Guid.NewGuid();
            var company = "MyCompany";
            var app = "MyApp";
            var url = "http://localhost";
            
            var token = tokenService.GenerateToken(new TokenClaim
            {
                CompanyName = company,
                AppName = app,
                OID = oid.ToString()
            });
            
            var entity = new Company
            {
                RefId = oid,
                Name = company,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsEnabled = true,
                Apps = new HashSet<App>
                {
                    new ()
                    {
                        Url = url,
                        Name = app,
                        AccessToken = token,
                        IsTokenRevoked = false,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        IsEnabled = true
                    }
                }
            };

            await dbContext.Companies.AddAsync(entity);

            await dbContext.SaveChangesAsync();

            return token;
        }

        public async Task<bool> Validate(string token)
        {
            var oid = tokenService.GetOidFromToken(token);
            
            if (oid == null) return false;

            var claim = await dbContext.Apps
                .Include(a => a.Company)
                .Where(a => a.IsEnabled == true && a.Company.RefId == Guid.Parse(oid))
                .Select(a => new TokenClaim
                {
                    CompanyName = a.Company.Name ?? string.Empty,
                    AppName = a.Name ?? string.Empty
                })
                .FirstOrDefaultAsync();
            
            if (claim == null) return false;

            var isValid = tokenService.ValidateToken(token, claim);
            
            if (!isValid) return false;

            return true;
        }
    }
}