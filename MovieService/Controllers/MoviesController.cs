using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieService.Context;
using MovieService.Models.Movie;
using MovieService.Service.Email;
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

		//[Authorize(Roles = "member")]
		[AllowAnonymous]
		[HttpPost("addcommend")]
		public async Task<IActionResult> AddCommend(CommendModel commendModel)
		{
			try
			{
				using (var context = new MovieContext())
				{
					context.Commends.Add(new Entities.Commend
					{
						MovieId = commendModel.MovieId,
						Point = commendModel.Point,
						Note = commendModel.Note,
						UserId = commendModel.UserId

					});
					await context.SaveChangesAsync();
				}


			}
			catch (Exception)
			{

				throw;
			}
			
			//rate, note
			return Ok();
		}

		//[Authorize(Roles = "member")]
		[AllowAnonymous]
		[HttpGet("getcommend")]
		public async Task<IActionResult> GetCommend()
		{
			try
			{
				using (var context = new MovieContext())
				{
					var result= context.Commends.ToList();
					return Ok(result);
				}


			}
			catch (Exception)
			{
				return BadRequest();
			}

		}


		[AllowAnonymous]
		[HttpGet("getbyid")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				using (var context = new MovieContext())
				{
					var movieResult = context.Movies.Where(x=>x.Id==id).ToList();
					var commentResults = context.Commends.Where(x => x.MovieId == id).ToList();
					return Ok(new {movieResult, commentResults});
				}

			}
			catch (Exception)
			{
				return BadRequest();
			}

		}

		[AllowAnonymous]
		[HttpGet("sendmail")]
		public ActionResult SendMailForSuggestion(string email, string filmName)
		{
			// user bilgisi token den alınmalı
			var _userFullname = "Duygu Ulu";

			var mailBody = $"<h2>Tavsiye eden : {_userFullname}</h2>" +
				$"<h2>Film : {filmName}</h2>";

			using (GMail gmail = new GMail())
			{
				gmail.SendMail(email, mailBody);
			}
			return Ok();
		}

	}
}
