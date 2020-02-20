using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest.API.Models;
using Nest.Models;

namespace Nest.API.Concrete {
	class NestContext : DbContext {
		public DbSet<User> Users { get; set; }
		public DbSet<Friend> Friends { get; set; }
		public DbSet<Channel> Channels { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Buzz> Buzzes { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Message> Messages { get; set; }
	}
}
