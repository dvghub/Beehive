using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Buzz {
		public int Id { get; set; }
		public User User { get; set; }
		public Post Post { get; set; }
		public Comment Comment { get; set; }
	}
}