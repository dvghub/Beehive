using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class User {
		public User() { }
		public User(int id) { Id = id; }

		public int Id { get; set; }
		public string Handle { get; set; }
		public string Email { get; set; }
		public string Password { get; set; } = "$2a$10$d61r2ye3YHsuQwL1/e0fGOA1WItVj.YkaLESdfL5m0.shdTQ3qAjG";
		public int Role { get; set; }
		public string Icon { get; set; } = "defaults/user_default.jpg";
		public bool Online { get; set; }
		public bool Buzzing { get; set; } = true;
	}
}