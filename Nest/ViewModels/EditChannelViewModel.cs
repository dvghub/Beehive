using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class EditChannelViewModel {
        public Channel Channel { get; set; }
        public int ParentId { get; set; }
        public HashSet<Channel> Channels { get; set; }
    }
}