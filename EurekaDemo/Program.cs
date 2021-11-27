using EurekaDemo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Discovery.Client;

await Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddHttpClient();
               services.AddDiscoveryClient();
               services.AddHostedService<EurekaFetchService>();
           })
           .ConfigureAppConfiguration(app =>
           {
               app.AddJsonFile("appsettings.json");
           })
           .RunConsoleAsync();
