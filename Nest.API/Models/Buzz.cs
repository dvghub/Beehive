using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Buzz {
		[Required]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public Post Post { get; set; }

		[Required]
		public Comment Comment { get; set; }
	}
}