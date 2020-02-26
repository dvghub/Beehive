using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class CreateChannelViewModel {
        public Channel Channel { get; set; }
        public HashSet<Channel> Channels { get; set; }
    }
}