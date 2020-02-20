using Nest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nest.ViewModels {
    public class ChannelMenuModel {
        public List<Channel> Channels { get; set; }
        public string Current { get; set; }
    }
}