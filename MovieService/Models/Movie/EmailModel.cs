using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models.Movie
{
	public class EmailModel
	{
		public string MovieName { get; set; }
		public string Message { get; set; }
		public string Header { get; set; }
		public string Email { get; set; }
	}
}
