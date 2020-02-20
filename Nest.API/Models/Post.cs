using Nest.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nest.API.Models {
	public class Post {
		public int Id { get; set; }
		public User User { get; set; }
		public string Title { get; set; }
		[Required(ErrorMessage ="Please enter a message to post.")]
		public string Message { get; set; }
		public Channel Channel { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
