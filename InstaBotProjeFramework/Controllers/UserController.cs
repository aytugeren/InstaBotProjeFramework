using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstaBotProjeFramework.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager();

        // GET: User
        public ActionResult Index()
        {

            var userId = Guid.Empty;
            if (HttpContext.Request.IsAuthenticated)
            {
                userId = Guid.Parse(HttpContext.User.Identity.Name.Split('|')[1]);
                var userDTO = userManager.GetUserById(userId);
                var userCount = userManager.GetUserStatistics(userId);
                UserProfileDTO userProfileDTO = new UserProfileDTO() { User = userDTO, UserStaticOfProfile = userCount };
                return View(userProfileDTO);
            }

            return RedirectToAction("Index","Login");
        }

        public ActionResult EditPictureOfUser(string picture, Guid id)
        {
            if (!string.IsNullOrEmpty(picture) && id != Guid.Empty)
            {
                if (Request.Files.Count > 0 && !string.IsNullOrEmpty(Request.Files[0].FileName))
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    if (fileName.Contains("jpg") || fileName.Contains("png"))
                    {
                        picture = "/Content/adminlte/dist/img/" + fileName;
                    }
                    else
                    {
                        string ext = Path.GetExtension(Request.Files[0].FileName);
                        picture = "/Content/adminlte/dist/img/" + fileName + ext;
                    }
                }
                Request.Files[0].SaveAs(Server.MapPath(picture));
                var user = userManager.UpdateUserPicture(picture, id);
                if (user)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index", "Error");
        }


    }
}