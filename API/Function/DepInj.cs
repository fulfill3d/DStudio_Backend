using Microsoft.Extensions.DependencyInjection;
using DStudio.API.Services;
using DStudio.API.Services.Interfaces;
using DStudio.Integrations.CosmosDbClient;
using DStudio.Integrations.CosmosDbClient.Options;

namespace DStudio.API
{
    public static class DepInj
    {
        public static void RegisterServices(
            this IServiceCollection services,
            Action<CosmosDbClientOptions> configureCosmosDbClientOptions)
        {
            #region Services

            services.RegisterCosmosDbClient(configureCosmosDbClientOptions);
            services.AddTransient<IApiService, ApiService>();

            #endregion
        }
    }
}