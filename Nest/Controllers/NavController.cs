using Nest.API.Concrete;
using Nest.API.Models;
using Nest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nest.Controllers {
    public class NavController : Controller {
        private readonly ChannelRepository channelRepository = new ChannelRepository();

        public PartialViewResult ChannelMenu(string category = null) {
            var channels = channelRepository.Channels.Where(c => c.Id != 22).ToList();
            channels.Sort( (a, b) => a.Id.CompareTo(b.Id));

            ChannelMenuViewModel model = new ChannelMenuViewModel {
                Channels = channels,
                Current = category,
                Parent = 1
            };

            return PartialView(model);
        }
    }
}
