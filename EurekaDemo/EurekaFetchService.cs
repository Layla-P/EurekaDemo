using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Eureka;

namespace EurekaDemo
{
    internal class EurekaFetchService : IHostedService
    {
		private readonly DiscoveryClient _discoveryClient;
		private readonly ILogger<EurekaFetchService> _logger;
		private readonly HttpClient _client;

		public EurekaFetchService(IDiscoveryClient discoveryClient, HttpClient client, ILogger<EurekaFetchService> logger)
		{
			_discoveryClient = discoveryClient as DiscoveryClient 
				?? throw new NotImplementedException(nameof(discoveryClient));
			_client = client;
			_logger = logger;
		}

        public async Task StartAsync(CancellationToken cancellationToken)
        {
			Thread.Sleep(10000);

			var apps = _discoveryClient.Applications.GetRegisteredApplications();

			var appName = "";
			var count = 0;
			foreach (var app in apps)
			{
				var firstInstance = app.Instances[0];
				appName = app.Name;
				//appUrl = $"Http://{firstInstance.HostName}:{firstInstance.Port}";
				_logger.LogInformation(@$"Name:{appName} and hostname: {firstInstance.HostName} and 
					port:{firstInstance.SecurePort}");
				count++;
				try
				{
					if (appName.ToLower() == "dadjokeapi" && !string.IsNullOrEmpty(firstInstance.HomePageUrl))
					{
						_logger.LogError($"{firstInstance.HomePageUrl}dadjoke");
						var response = await _client.GetStringAsync($"{firstInstance.HomePageUrl}dadjoke");
						_logger.LogWarning(response);

					}
				}
				catch(Exception ex)
                {

                }

			}
			_logger.LogWarning(@$"There are {count} apps registered with Eureka");
		}

        public Task StopAsync(CancellationToken cancellationToken)
        {
			return _discoveryClient.ShutdownAsync();
		}
    }
}
