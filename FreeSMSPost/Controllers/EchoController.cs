using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeSMSPost.Controllers
{
    public class EchoController : Controller
    {
        //
        // GET: /Echo/

        [HttpPost]
        public ActionResult Index()
        {
            return Content(String.Format("<Response><Sms>{0}</Sms></Response>", Request.Params["Body"]));

        }

    }
}
