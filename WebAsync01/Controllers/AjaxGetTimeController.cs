using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAsync01.Controllers
{
    public class AjaxGetTimeController : Controller
    {
        // GET: AjaxGetTime
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Server Time. 
        /// for Ajax call testing
        /// </summary>
        /// <returns>Server Time</returns>
        public ActionResult Time()
        {
            var time = DateTime.Now.ToString("yyyy/M/d HH:mm:ss");
            return Content(time);
        }
    }
}