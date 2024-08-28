namespace DStudio.API.Client.Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<string> Register();
        Task<bool> Validate(string token);
    }
}