using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Message {
		[Required]
		public int Id { get; set; }

		[Required]
		public Chat Chat { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public string Text { get; set; }
	}
}