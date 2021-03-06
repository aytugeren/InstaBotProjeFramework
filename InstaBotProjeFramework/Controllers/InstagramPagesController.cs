using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Managers;
using InstaBotProjeFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaBotProjeFramework.Controllers
{
    public class InstagramPagesController : Controller
    {
        InstagramManager instaManager = new InstagramManager();

        // GET: InstagramPages
        public PartialViewResult Index()
        {
            if (HttpContext.Request.IsAuthenticated)
            {
                var userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);
                var instagramProfiles = instaManager.GetInstagramProfilesByUserId(userId);

                return PartialView(instagramProfiles);
            }

            return PartialView(default(InstagramProfileDTO));
        }

        public PartialViewResult AddInstagramPages()
        {
            return PartialView(new InstagramProfileModel());
        }

        [HttpGet]
        public PartialViewResult EditInstagramProfile()
        {
            return PartialView(default(InstagramProfileModel));
        }



        [HttpPost]
        public ActionResult EditInstagramProfile(InstagramProfileModel instagramProfile)
        {
            return RedirectToAction("Index", "User");
        }

        public JsonResult DeleteInstagramProfile(Guid id)
        {
            var result = instaManager.DeleteInstagramProfile(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddInstagramPages(InstagramProfileModel instagramProfile)
        {
            if (ModelState.IsValid)
            {
                if (instagramProfile != null)
                {
                    var userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);

                    var instaDTO = new InstagramProfileDTO
                    {
                        Description = instagramProfile.Description,
                        Url = instagramProfile.Url,
                        Password = instagramProfile.Password,
                        UserId = userId,
                        Username = instagramProfile.Username
                    };

                    var isAdded = instaManager.AddInstagramProfile(instaDTO);

                    if (isAdded)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }

                return RedirectToAction("Index", "Error");
            }

            return View();

        }

        [HttpPost]
        public JsonResult CheckUsernameOfUser(string username)
        {
            var result = instaManager.CheckUserNameOfUser(username);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditInstagramProfileByUrl(string url)
        {
            var result = instaManager.GetInstagramProfileInfoByUrl(url);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckUsernameOfUrl(string url)
        {
            var result = instaManager.CheckUserNameOfUrl(url);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}