using DStudio.Common.Core.Model;
using DStudio.Common.Services.Interfaces;
using Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DStudio.Common.Services
{
    public static class DepInj
    {
        public static void AddDatabaseContext<TContext>(
            this IServiceCollection services, DatabaseOption dbConnectionsOptions)
            where TContext : DbContext
        {
            
            services.AddDbContext<TContext>(
                options =>
                {
                    if (!options.IsConfigured)
                    {
                        options.UseSqlServer(dbConnectionsOptions.ConnectionString, options =>
                        {
                            options.EnableRetryOnFailure(
                                maxRetryCount: 5, // Number of retry attempts
                                maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                                errorNumbersToAdd: null); // Add additional SQL error numbers to retry on
                        });
                    }
                });
        }

        public static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
        
        public static void RegisterTokenService(
            this IServiceCollection services,
            Action<IServiceProvider, TokenValidationOption> tokenValidationOption)
        {
            services.ConfigureServiceOptions(tokenValidationOption);
            services.AddSingleton<ITokenService, TokenService>();
        }
    }
}