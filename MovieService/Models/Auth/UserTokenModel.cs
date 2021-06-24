using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models.Auth
{
	public class UserTokenModel
	{
		public string FullName { get; set; }
		public int UserId { get; set; }
		public string Role { get; set; }
	}
}
