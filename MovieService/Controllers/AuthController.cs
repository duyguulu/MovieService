using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieService.Context;
using MovieService.Entities;
using MovieService.Helpers;
using MovieService.Models.Auth;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : BaseController
	{
		private IConfiguration _configuration;
		public AuthController(ILogger<AuthController> logger, IConfiguration configuration) :base(logger)
		{
			_configuration = configuration;
		}

		//todo ++++ neden asenkron bir yapı kullandık?
		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register(UserRegisterModel user)
		{
			try
			{
				using (var context = new MovieContext())
				{
					context.Users.Add(
						new User
						{
							FirstName = user.FirstName,
							Email = user.Email,
							LastName = user.LastName,
							Password = user.Password,
							Username = user.Username
						});

					await context.SaveChangesAsync();
				}

				return Ok(user);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login(UserLoginModel user)
		{
			try
			{
				using (var context = new MovieContext())
				{
					var result=await context.Users.FirstOrDefaultAsync(x=> x.Username==user.Username && x.Password==user.Password);
					if (result != null)
					{
						var token = TokenHelper.CreateToken(_configuration, new UserTokenModel { FullName=result.FirstName+" "+result.LastName, UserId=result.Id,Role=result.Role });
						return Ok(new { token = token, username = result.Username});
					}
					else
					{
						return NoContent();
					}
				}

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		
		[HttpGet("myprofile")]
		public async Task<IActionResult> MyProfile()
		{

			return Ok();
		}

		
	}
}
