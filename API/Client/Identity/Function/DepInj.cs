using DStudio.Common.Core.Model;
using DStudio.Common.Database;
using DStudio.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using DStudio.API.Client.Identity.Data.Database;
using DStudio.API.Client.Identity.Services;
using DStudio.API.Client.Identity.Services.Interfaces;

namespace DStudio.API.Client.Identity
{
    public static class DepInj
    {
        public static void RegisterServices(
            this IServiceCollection services,
            DatabaseOption dbOption,
            Action<TokenValidationOption> tokenValidationOption)
        {
            #region Miscellaneous

            services.RegisterTokenService((_, opt) => tokenValidationOption(opt));
            services.AddDatabaseContext<IdentityContext>(dbOption);

            #endregion

            #region Services

            services.AddTransient<IIdentityService, IdentityService>();

            #endregion
        }
    }
}