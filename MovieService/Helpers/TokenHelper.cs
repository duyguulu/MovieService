using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Helpers
{
	public static class TokenHelper
	{
		
		public static string CreateToken(IConfiguration _configuration)
		{
			//static classtan instance üretilmez!
			var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
				SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
					_configuration["Jwt:Issuer"],
					_configuration["Jwt:Issuer"],
					//roleList.ToArray(),
					expires: DateTime.Now.AddDays(7),
					signingCredentials: credentials); ;

			return new JwtSecurityTokenHandler().WriteToken(token);

		}
	}
}
