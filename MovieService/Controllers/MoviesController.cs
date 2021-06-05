using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MoviesController : BaseController
	{
		private IConfiguration _configuration;
		public MoviesController(ILogger<AuthController> logger, IConfiguration configuration) : base(logger)
		{
			_configuration = configuration;
		}

		[Authorize(Roles ="admin")]
		[HttpPost("save")]
		public async Task<IActionResult> Save()
		{
			return Ok();
		}
	}
}
