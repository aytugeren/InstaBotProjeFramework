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


        [HttpPost]
        public ActionResult AddInstagramPages(InstagramProfileModel instagramProfile)
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
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index", "Error");
        }
    }
}