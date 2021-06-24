using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieService.Models.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Helpers
{
	public static class TokenHelper
	{
		
		public static string CreateToken(IConfiguration _configuration, UserTokenModel userTokenModel)
		{
			//static classtan instance üretilmez!
			var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
				SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Name, userTokenModel.FullName));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, userTokenModel.UserId.ToString()));
			claims.Add(new Claim(ClaimTypes.Role, userTokenModel.Role));
			var token = new JwtSecurityToken(
					_configuration["Jwt:Issuer"],
					_configuration["Jwt:Issuer"],
					claims,
					expires: DateTime.Now.AddDays(7),
					signingCredentials: credentials); 

			return new JwtSecurityTokenHandler().WriteToken(token);

		}
	}
}
