using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Models.Movie
{
	public class CommendModel
	{
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public string Note { get; set; }
		public double Point { get; set; }
	}
}
