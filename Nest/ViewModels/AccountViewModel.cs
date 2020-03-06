using Nest.API.Models;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class AccountViewModel {
        public User User { get; set; }
        public HashSet<Post> Posted { get; set; }
        public HashSet<Post> Commented { get; set; }
        public HashSet<Post> Buzzed { get; set; }
        public HashSet<User> Friends { get; set; }
        public HashSet<Chat> Chats { get; set; }
        public int Segment { get; set; }
    }
}