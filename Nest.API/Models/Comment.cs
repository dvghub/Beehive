using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Comment {
		public Comment() { }

		public Comment(int id) { Id = id; }

		[Required]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		public Post Post { get; set; }

		public Comment Com { get; set; }

		[Required]
		public string Text { get; set; }

		public DateTime Timestamp { get; set; } = DateTime.Now;
	}
}