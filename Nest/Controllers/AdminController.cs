using Nest.API.Concrete;
using Nest.API.Models;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nest.Controllers {
    public class AdminController : Controller {
        private ChannelRepository channelRepository = new ChannelRepository();
        private UserRepository userRepository = new UserRepository();

        public ViewResult Admin() {
            return View(); 
        }

        public ViewResult Channels() {
            return View(channelRepository.Channels);
        }

        public ViewResult CreateChannel() {
            return View("EditChannel", new Channel(-1));
        }

        public ViewResult EditChannel(int id) {
            Channel channel = channelRepository.Channels
                .FirstOrDefault(p => p.Id == id);
            return View(channel);
        }

        [HttpPost]
        public ActionResult EditChannel(Channel channel) {
            if (ModelState.IsValid) {
                channelRepository.CreateOrUpdate(channel);
                TempData["message"] = string.Format("{0} has been saved.", channel.Name);
                return RedirectToAction("Channels");
            }
            return View(channel);
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
            User user = userRepository.Users
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
