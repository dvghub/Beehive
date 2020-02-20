using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest.Models;
using Nest.API.Concrete;
using Nest.ViewModels;

namespace Nest.Controllers {
    public class IndexController : Controller {

        public ViewResult Index() {
            return View();
        }
    }
}
