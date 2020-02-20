using Nest.API.Concrete;
using Nest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nest.Controllers {
    public class LogController : Controller {
        private UserRepository userRepository = new UserRepository();

        public ActionResult Index() {
            HashSet<User> users = userRepository.Users
                .ToHashSet();
            return View(users);
        }
    }
}