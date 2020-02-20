using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Chat {
		public int Id { get; set; }
		public User User { get; set; }
		public User Bee { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
	}
}