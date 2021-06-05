using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Entities
{
	public class Commend
		//Todoo duzelt
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int MovieId { get; set; }
		public string Note { get; set; }
		public double Point { get; set; }
	}
}
