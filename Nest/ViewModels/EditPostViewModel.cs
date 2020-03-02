using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class EditPostViewModel {
        public Post Post { get; set; }
        public HashSet<Channel> Channels { get; set; }
        public int UserId { get; set; }
        public int ChannelId { get; set; }
    }
}