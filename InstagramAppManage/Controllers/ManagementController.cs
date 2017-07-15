using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.IO;
using InstagramAppManage.Models;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InstagramAppManage.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageInfo()
        {
            string instagramGeneralUrl = "https://api.instagram.com/v1/users/" + ConfigurationManager.AppSettings["InstagramUserID"] + "/?access_token=" + ConfigurationManager.AppSettings["InstagramTokenKey"];
            string instagramMediaUrl   = "https://api.instagram.com/v1/users/self/media/recent" + "/?access_token=" + ConfigurationManager.AppSettings["InstagramTokenKey"];

            using (WebClient webClient = new WebClient())
            {
                var generalInfo = webClient.DownloadString(instagramGeneralUrl);
                var instGeneralInfoResult = JsonConvert.DeserializeObject<InstagramGeneralInfo>(generalInfo);
                ViewBag.InstaInfo = instGeneralInfoResult;
                ViewBag.FollowBackRate = (int)((decimal)instGeneralInfoResult.data.counts.followed_by / (decimal)instGeneralInfoResult.data.counts.follows * 100);

                var mediaInfo = webClient.DownloadString(instagramMediaUrl);
                var instMediaInfoResult = JsonConvert.DeserializeObject<InstagramMediaInfo>(mediaInfo);

                int totalLikes = 0;
                int totalComments = 0;
                instMediaInfoResult.data.ForEach(d => {
                                                    totalLikes += d.likes.count;
                                                    totalComments += d.comments.count;
                                                    }
                                                );
                ViewBag.totalLikes = totalLikes;
                ViewBag.totalComments = totalComments;
                ViewBag.averageLikes = totalLikes / instGeneralInfoResult.data.counts.media;
                ViewBag.averageComments = totalComments / instGeneralInfoResult.data.counts.media;
            }

            
            return View();
        }

        public ActionResult Media()
        {
            return View();
        }
    }
}