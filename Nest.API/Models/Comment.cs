using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Comment {
		public int Id { get; set; }
		public User User { get; set; }
		public Post Post { get; set; }
		public Comment Com { get; set; }
		public string Message { get; set; }
		public DateTime Timestamp { get; set; }
	}
}