using Azure.Identity;
using DStudio.Common.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using DStudio.API.Client.Identity;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(builder =>
    {
        var configuration = builder.Build();
        var token = new DefaultAzureCredential();
        var appConfigUrl = configuration["AppConfigUrl"] ?? string.Empty;

        builder.AddAzureAppConfiguration(config =>
        {
            config.Connect(new Uri(appConfigUrl), token);
            config.ConfigureKeyVault(kv => kv.SetCredential(token));
        });
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services.RegisterServices(new DatabaseOption
        {
            ConnectionString = configuration["ConnectionString"] ?? string.Empty,
        }, tokenValidationOption =>
        {
            tokenValidationOption.SecurityKey = configuration["TokenValidationSecurityKey"] ?? string.Empty;
        });
    })
    .Build();

host.Run();