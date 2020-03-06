using Nest.Abstract;
using Nest.API.Concrete;
using Nest.Models;
using Nest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Nest.Concrete {
    public class Authoriser : IAuthoriser {
        private readonly UserRepository userRepository = new UserRepository();

        public bool Authenticate(LoginViewModel model) {

            User user = userRepository.Users.First(u => u.Email == model.Username);
            if (user == null) return false;

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) return false;

            if (user.Buzzing == false) userRepository.Restore(user.Id);

            userRepository.Online(user);
            user.Online = true;

            FormsAuthentication.SetAuthCookie(model.Username, false);
            HttpContext.Current.Session["user"] = user;

            return true;
        }

        public bool Logout() {
            User user = (User) HttpContext.Current.Session["user"];
            if (user == null) return false;

            userRepository.Offline(user);

            HttpContext.Current.Session.Remove("user");
            return true;
        }
    }
}
