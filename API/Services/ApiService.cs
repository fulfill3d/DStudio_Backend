using DStudio.API.Data.Models;
using DStudio.API.Services.Interfaces;
using DStudio.Integrations.CosmosDbClient.Interfaces;

namespace DStudio.API.Services
{
    public class ApiService(ICosmosDbClient cosmosDbClient) : IApiService
    {
        public async Task<Manifest> GetManifest(string id, string partitionKey)
        {
            return await cosmosDbClient.GetItemAsync<Manifest>(id, partitionKey);
        }

        public async Task<IEnumerable<Manifest>> GetManifests()
        {
            string query = @"SELECT c.id, c.name, c.partitionKey FROM c";
            return await cosmosDbClient.QueryItemsAsync<Manifest>(query);
        }
    }
}