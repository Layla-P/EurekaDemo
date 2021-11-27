
using Microsoft.Extensions.Logging;

namespace EurekaDemo
{

    /// <summary>
    /// A class to fetch all the apps within the Service Registry
    /// </summary>
    internal class EurekaFetchService
    {
        private readonly ILogger<EurekaFetchService> _logger;
        private readonly HttpClient _httpClient;

        public EurekaFetchService(HttpClient httpClient, ILogger<EurekaFetchService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

    }
}
