using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, member, moderator")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}