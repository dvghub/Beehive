using Nest.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nest.API.Models {
	public class Post {
		public Post() { }
		public Post(int id) { Id = id; }

		[Required]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		public string Title { get; set; }

		[Required(ErrorMessage ="Please enter a message to post.")]
		public string Text { get; set; }

		[Required(ErrorMessage = "Please select a channel.")]
		public Channel Channel { get; set; }

		public DateTime Timestamp { get; set; } = DateTime.Now;
	}
}
