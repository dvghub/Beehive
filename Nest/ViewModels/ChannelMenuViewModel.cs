using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class ChannelMenuViewModel {
        public List<Channel> Channels { get; set; }
        public string Current { get; set; }
        public int Parent { get; set; }
    }
}