using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models.Movie
{
	public class EmailModel
	{
		public int Id { get; set; }
		public string MovieName { get; set; }
		public string Message { get; set; }
		public string Header { get; set; }
	}
}
