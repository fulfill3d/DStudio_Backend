using DStudio.Common.Services;
using DStudio.Integrations.CosmosDbClient.Interfaces;
using DStudio.Integrations.CosmosDbClient.Options;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DStudio.Integrations.CosmosDbClient
{
    public static class DepInj
    {
        public static void RegisterCosmosDbClient(
            this IServiceCollection services,
            Action<CosmosDbClientOptions> configureCosmosDbClientOptions)
        {
            services.ConfigureServiceOptions<CosmosDbClientOptions>((_, options) => configureCosmosDbClientOptions(options));

            services.AddSingleton<CosmosClient>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<CosmosDbClientOptions>>().Value;
                return new CosmosClient(options.EndpointUri, options.PrimaryKey);
            });

            services.AddSingleton<Container>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<CosmosDbClientOptions>>().Value;
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                return cosmosClient.GetContainer(options.DatabaseId, options.ContainerId);
            });
            
            services.AddTransient<ICosmosDbClient, CosmosDbClient>();
        }
    }
}