using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlackTest.Models;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using SlackTest.Models.RaisingCodeBotSmarts;

namespace SlackTest.Controllers
{
    public class SlackController : Controller
    {
      
        public ActionResult SlackHandler(ContentRoot content)
        {
            //TODO: change Challenge Class to payload
            if (content.Type.Contains("event_callback"))
            {
                if (content.@Event.Type == "app_mention")
                {
                    string user = "<@" + content.@Event.User + ">";
                    string orig_channel = content.@Event.Channel;
		    string bearerToken =""; //you must provide a bearerToken for this to work!!
                
                    var wc = new HttpClient();
                    wc.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);

                    if (content.Event.Text.ToUpper().Contains("INSULT"))
                    {
                        var ranObj = new
                        {

                            channel = orig_channel,
                            text = user + " " + InsultMe.Quote,
                         //   attachments = new[]
                         //    {
                         //new {
                         //          title = "ok",
                         //          image_url = "http://ronntorossian.com/wp-content/uploads/2014/02/power-of-the-meme-ronn-torossian-1024x640.jpg"
                         //    }
                         //}
                        };


                        var t = wc.PostAsync("https://slack.com/api/chat.postMessage", new StringContent(JsonConvert.SerializeObject(ranObj), System.Text.Encoding.UTF8, "application/json"));
                        var response = t.Result;
                    }

                }
            }
            return Json(content.Challenge, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Index()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}