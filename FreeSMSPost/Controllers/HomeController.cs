using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeSMSPost.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}

        [HttpPost]
        public ActionResult Index()
        {
            return Content(String.Format("<Response><Sms>{0}</Sms></Response>", Request.Params["Body"]));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
