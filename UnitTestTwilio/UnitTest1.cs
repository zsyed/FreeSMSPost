using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Threading.Tasks;


namespace UnitTestTwilio
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var to = "+17144691491";
            var message = "I am sending message to google voice number";

            Task<HttpResponseMessage> succeeded = SendSms(to,message);
            succeeded.Wait();
            Console.WriteLine(succeeded.Result.IsSuccessStatusCode ? "SMS Message queued..." : "SMS Message failed...");
        }

        private static async Task<HttpResponseMessage> SendSms(string to, string message)
        {
            using (var client = new HttpClient())
            {
                var accountSid = "AC36241612702f6674342ac88458c378c8";
                var authToken = "5c81d4a1aec022545daf8da956a6b729";
                var from = "+17144595176";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    string.Format("{0}:{1}", accountSid, authToken)))
                );

                var content = new StringContent(string.Format("From={0}&To={1}&Body={2}", from, to, message));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var targetUri = string.Format("https://api.twilio.com/2010-04-01/Accounts/{0}/SMS/Messages", accountSid);
                return await client.PostAsync(targetUri, content);
            }
        }
    }
}
