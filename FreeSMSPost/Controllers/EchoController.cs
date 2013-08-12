using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FreeSMSPost.Controllers
{
    public class EchoController : Controller
    {
        //
        // GET: /Echo/

        public ActionResult Index()
        {
            // return Content(String.Format("<Response><Sms>{0}</Sms></Response>", Request.Params["Body"]));

            var accountSid = "AC36241612702f6674342ac88458c378c8";
            var authToken = "5c81d4a1aec022545daf8da956a6b729";
            var from = "+17144595176";
            var to = "+19492099893";
            var message = "zulfiqar is sending message to google voice number";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", accountSid, authToken))));
                var content = new StringContent(string.Format("From={0}&To{1}&Body{2}", from, to, message));
                var targetUri = string.Format("https://api.twilio.com/2010-04-01/Accounts/{0}/SMS/Messages", accountSid);
                var succeeded = client.PostAsync(targetUri, content);
                succeeded.Wait();
            }
            return Content("Sent message to 19492099893");
        }

    }
}
