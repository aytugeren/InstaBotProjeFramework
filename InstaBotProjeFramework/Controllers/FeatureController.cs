using InstaBotProjeFramework.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaBotProjeFramework.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager();

        // GET: Feature
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FollowingBot(Guid featureId)
        {
            var userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);
            var profiles = featureManager.GetFeatureOfUser(userId, featureId);
            return PartialView(profiles);
        }

        public ActionResult UnFollowBot(Guid featureId)
        {
            var userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);
            var profiles = featureManager.GetFeatureOfUser(userId, featureId);
            return View(profiles);
        }

        [HttpPost]
        public JsonResult CheckInstagramUser(string username,string profileId, string featureId)
        {
            var result = featureManager.IsUsernameAvailable(username, profileId, featureId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}