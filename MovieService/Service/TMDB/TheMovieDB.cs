using MovieService.Context;
using MovieService.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Service.TMDB
{
	public class TheMovieDB
	{
		private string apiKey="d4ba9284d4f3d8397bb1d1a20220402b";
		public void UpdateMovieDb(int page)
		{
			try
			{
				List<int> movieIds;
				using (var context = new MovieContext())
				{
					movieIds = context.Movies.Select(x=> x.Id).ToList();
					
				}

				List<dynamic> results = new List<dynamic>();

				for (int i = 1; i < 37; i++)
				{
					string path = "https://api.themoviedb.org/3/movie/top_rated?api_key=" + apiKey + "&language=en-US&page=" + i;

					var client = new RestClient(path);
					client.Timeout = -1;
					var request = new RestRequest(Method.GET);
					request.AddHeader("Accept", "application/json");
					IRestResponse response = client.Execute(request);
					var obj = response.Content;
					dynamic dynamicObj = JsonConvert.DeserializeObject<dynamic>(obj);
					results.AddRange(dynamicObj.results);
				}
				
				List<Movie> movies = new List<Movie>();
				foreach (var result in results)
				{
					if (!movieIds.Contains((int)result.id))
						movies.Add(new Movie
						{
							Adult = result.adult,
							BackdropPath = result.backdrop_path,
							//GenreIds = result.genre_ids.ToSting(),
							Id = result.id,
							OriginalLanguage = result.original_language,
							OriginalTitle = result.original_title,
							Overview = result.overview,
							Popularity = result.popularity,
							PosterPath = result.poster_path,
							ReleaseDate = result.release_date,
							Title = result.title,
							Video = result.video,
							VoteAverage = result.vote_average,
							VoteCount = result.vote_count
						});
				}
				using (var context = new MovieContext())
				{
					foreach (var movie in movies)
					{
						context.Movies.Add(movie);
					}
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				
			}
			//return response.Content;

		}
	}
}
