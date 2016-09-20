using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAsync01.Controllers
{
    public class DateTimeTController : Controller
    {
        // GET: DateTimeT
        public ActionResult Index()
        {
            WebAsync01.Models.UserProfile an_user = new Models.UserProfile();
            an_user.Birthday = DateTime.Now;
            return View(an_user);
        }
    }
}