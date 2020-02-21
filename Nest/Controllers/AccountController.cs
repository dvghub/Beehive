using Nest.API.Concrete;
using Nest.Concrete;
using Nest.Models;
using Nest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nest.Controllers {
    public class AccountController : Controller {
        Authoriser auth = new Authoriser();

        public ViewResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string url) {
            if (!ModelState.IsValid) return View();
            if (auth.Authenticate(model.Username, model.Password)) {
                return Redirect(url ?? Url.Action("Index", "Admin", null));
            }
            ModelState.AddModelError("", "Incorrect username or password");
            return View();
        }
    }
}
