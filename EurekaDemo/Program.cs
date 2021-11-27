using EurekaDemo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               services.AddHttpClient();
           })
           .ConfigureAppConfiguration(app =>
           {
               app.AddJsonFile("appsettings.json");
           })
           .RunConsoleAsync();
