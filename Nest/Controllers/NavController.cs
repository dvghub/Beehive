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

        public PartialViewResult FeedMenu(string category = null) {
            List<Channel> channels = channelRepository.Channels.ToList();

            ChannelMenuViewModel model = new ChannelMenuViewModel {
                Channels = channels,
                Current = category
            };

            return PartialView(model);
        }
    }
}
