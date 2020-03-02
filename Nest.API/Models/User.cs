using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class User {
		public User() { }
		public User(int id) { Id = id; }

		[Required]
		public int Id { get; set; }

		[Required]
		public string Handle { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; } = "$2a$10$d61r2ye3YHsuQwL1/e0fGOA1WItVj.YkaLESdfL5m0.shdTQ3qAjG";

		[Required]
		public int Role { get; set; } = 0;

		public string Icon { get; set; }

		public bool Online { get; set; } = false;

		public bool Buzzing { get; set; } = true;
	}
}