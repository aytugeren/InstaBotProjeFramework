using InstaBotProjeFramework.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaBotProjeFramework.Controllers
{
    public class DashboardController : Controller
    {
        DashboardManager dashManager = new DashboardManager();

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetProfile()
        {
            var userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);
            var instagramProfiles = dashManager.GetUserProfile(userId);

            return PartialView(instagramProfiles);
        }

        public PartialViewResult GetBots()
        {
            var userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);
            var features = dashManager.GetActiveBots(userId);

            return PartialView(features);
        }
    }
}