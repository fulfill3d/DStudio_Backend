using DStudio.API.Data.Models;

namespace DStudio.API.Services.Interfaces
{
    public interface IApiService
    {
        Task<Manifest> GetManifest(string id, string partitionKey);
        Task<IEnumerable<Manifest>> GetManifests();
    }
}