using Microsoft.EntityFrameworkCore;
using MovieService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Context
{
	public class MovieContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(@"Server = localhost; Port = 5432; User Id = postgres; Password = 78560; Database = MovieServiceDB; ");
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Movie> Movies { get; set; }

	}
}
