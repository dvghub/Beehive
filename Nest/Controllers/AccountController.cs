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
        private readonly Authoriser auth = new Authoriser();
        private readonly UserRepository userRepository = new UserRepository();
        private readonly PostRepository postRepository = new PostRepository();
        private readonly BuzzRepository buzzRepository = new BuzzRepository();
        private readonly ChatRepository chatRepository = new ChatRepository();
        private readonly CommentRepository commentRepository = new CommentRepository();

        [Authorize]
        public ViewResult Account(int segment = 0) {
            User user = (User)HttpContext.Session["user"];

            var model = new AccountViewModel {
                User = user,
                Segment = segment,
                Chats = chatRepository.Chats.Where(c => c.User.Id == user.Id || c.Bee.Id == user.Id).ToHashSet()
            };

            switch (segment) {
                case 0:
                    model.Posted = postRepository.Posts
                        .Include("User")
                        .Include("Channel")
                        .Where(p => p.User.Id == user.Id)
                        .Take(5)
                        .ToHashSet();
                    break;
                case 1:
                    model.Buzzed = postRepository.Posts
                        .Include("User")
                        .Include("Channel")
                        .Where(p => p.User.Id == user.Id)
                        .Take(5)
                        .ToHashSet();
                    break;
                case 2:
                    model.Commented = postRepository.Posts
                        .Include("User")
                        .Include("Channel")
                        .Where(p => p.User.Id == user.Id)
                        .Take(5)
                        .ToHashSet();
                    break;
            }

            return View(model);
        }

        public ViewResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string url) {
            if (!ModelState.IsValid) return View();
            if (auth.Authenticate(model)) return Redirect(url ?? Url.Action("Index", "Index", null));
            ModelState.AddModelError("Password", "Incorrect username or password");
            return View(model);
        }

        public ActionResult Logout() {
            auth.Logout();
            return Redirect(Url.Action("Index", "Index", null));
        }

        public ViewResult Signup() {
            var model = new SignUpViewModel {
                User = new User(-1)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Signup(SignUpViewModel model) {
            User user = model.User;

            if (ModelState.IsValid) {
                if (model.NewPassword == model.RepeatPassword) {
                    user.Password = model.NewPassword;
                    user = userRepository.CreateOrUpdate(user);
                    TempData["message"] = "Your account has been created!";
                    return RedirectToAction("Account", new { user });
                }
                ModelState.AddModelError("RepeatPassword", "Passwords do not match");
            }

            return View(model);
        }

        [Authorize]
        public ViewResult EditAccount(User user) {
            return View(user);
        }
    }
}
