using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using System.Net.Http;

namespace SMSSender.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SendSms()
        {
            //  AC404b6d5e3b1bf362f0b72abbf9eefd00
            //  29cb65db632495b58ac61ce3f5093b37

            



            try
            {
                var accountSid = "AC404b6d5e3b1bf362f0b72abbf9eefd00";
                var authToken = "29cb65db632495b58ac61ce3f5093b37";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("whatsapp:+5511988801976"));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = "Te amo S2";

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);

                //TwilioClient.Init("ACbbf6d4122171315d7688979b5e5b19d1",
                //"8d3d1d784cbbb05fab852552f734a141");

                //var message = MessageResource.Create(
                //    to: "+5511988801976",
                //    from: "+14155238886",
                //    body: "Teste do Matheus Haha"
                //    );
                
                return View(message);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

            //// https://www.smsdev.com.br/definicao-de-precos/
            //var uri = new Uri("https://api.smsdev.com.br/v1/send?key=&type=9&number=11988801976&msg=Teste de envio");
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, uri);

            //var response = await client.SendAsync(request);

            //return Content(response.StatusCode.ToString());
        }
    }
}
