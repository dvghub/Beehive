using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.Models {
	public class Message {
		public int Id { get; set; }
		public Chat Chat { get; set; }
		public User User { get; set; }
		public string Text { get; set; }
	}
}