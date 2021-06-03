using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Entities
{
	public class User
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required, MaxLength(30)]
		public string Username { get; set; }

		[Required, MaxLength(20)]
		public string Password { get; set; }

		[Required, MaxLength(30)]
		public string FirstName { get; set; }

		[Required, MaxLength(30)]
		public string LastName { get; set; }

		[Required, MaxLength(30)]
		public string Email { get; set; }
	}
}
