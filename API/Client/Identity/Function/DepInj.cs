using DStudio.Common.Core.Model;
using DStudio.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Identity.Data;
using Identity.Data.Database;
using Identity.Services;
using Identity.Services.Interfaces;

namespace Identity
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