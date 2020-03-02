using Nest.API.Concrete;
using Nest.API.Models;
using Nest.Models;
using Nest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nest.Controllers {
    [Authorize]
    public class AdminController : Controller {
        private readonly ChannelRepository channelRepository = new ChannelRepository();
        private readonly UserRepository userRepository = new UserRepository();

        public ViewResult Index() {
            return View(); 
        }

        public ViewResult Channels() {
            var channels = channelRepository.Channels.ToList();
            channels.Sort( (a, b) => a.Id.CompareTo(b.Id) );
            return View(channels);
        }

        public ViewResult CreateChannel() {
            var model = new EditChannelViewModel {
                Channel = new Channel(-1),
                Channels = channelRepository.Channels.ToHashSet()
            };
            return View("EditChannel", model);
        }

        public ViewResult EditChannel(int id) {
            var channel = channelRepository.Channels.Find(id);
            var model = new EditChannelViewModel {
                Channel = channel,
                Channels = channelRepository.Channels.ToHashSet(),
                ParentId = channel.Parent.Id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditChannel(EditChannelViewModel model) {
            model.Channels = channelRepository.Channels.ToHashSet();
            model.Channel.Parent = channelRepository.Channels.Find(model.ParentId);

            ModelState.Clear();

            TryValidateModel(model);
            TryValidateModel(model.Channel, "Channel");
            TryValidateModel(model.Channel.Parent, "Channel.Parent");

            if (ModelState.IsValid) {
                channelRepository.CreateOrUpdate(model.Channel);
                TempData["message"] = string.Format("{0} has been saved.", model.Channel.Name);
                return RedirectToAction("Channels");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteChannel(int id) {
            channelRepository.Delete(id);
            TempData["message"] = "Channel was deleted.";
            return RedirectToAction("Channels");
        }

        public ViewResult Users() {
            return View(userRepository.Users);
        }

        public ViewResult CreateUser() {
            return View("EditUser", new User(-1));
        }

        public ViewResult EditUser(int id) {
            var user = userRepository.Users
                .FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user) {
            if (ModelState.IsValid) {
                userRepository.CreateOrUpdate(user);
                TempData["message"] = string.Format("{0} has been saved.", user.Handle);
                return RedirectToAction("Users");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult RestoreUser(int id) {
            userRepository.Restore(id);
            TempData["message"] = "User was restored";
            return RedirectToAction("Users");
        }

        [HttpPost]
        public ActionResult DeleteUser(int id) {
            userRepository.Delete(id);
            TempData["message"] = "User was archived";
            return RedirectToAction("Users");
        }
    }
}
