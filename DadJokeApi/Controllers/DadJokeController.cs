using EurekaDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurekaDemo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DadJokeController : ControllerBase
	{
		

		private readonly ILogger<DadJokeController> _logger;
		private readonly DadJokeService _dadJokeService;

		public DadJokeController(ILogger<DadJokeController> logger, DadJokeService dadJokeService)
		{
			_logger = logger;
			_dadJokeService = dadJokeService;
		}

		[HttpGet]
		public async Task<string> Get()
		{
			return await _dadJokeService.GetJokeAsync();
		}
	}
}
