using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Chat {
		[Required]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public User Bee { get; set; }

		public string Name { get; set; }
		
		public string Icon { get; set; }
	}
}