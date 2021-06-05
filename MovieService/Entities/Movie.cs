using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Entities
{
	public class Movie
	{
		public int Id { get; set; }
		public bool Adult { get; set; }
		public string BackdropPath { get; set; }
		public string GenreIds { get; set; }
		public string OriginalLanguage { get; set; }
		public string OriginalTitle { get; set; }
		public string Overview { get; set; }
		public int Popularity { get; set; }
		public string PosterPath { get; set; }
		public string ReleaseDate { get; set; }
		public string Title { get; set; }
		public bool Video { get; set; }
		public double VoteAverage { get; set; }
		public int VoteCount { get; set; }
	}
}
