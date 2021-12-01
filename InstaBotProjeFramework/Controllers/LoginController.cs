using InstaBotProjeFramework.Data.DTOs;
using InstaBotProjeFramework.Data.Managers;
using InstaBotProjeFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InstaBotProjeFramework.Controllers
{
    public class LoginController : Controller
    {
        UserManager userManager = new UserManager();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            if (login != null)
            {
                var isUserValid = userManager.CheckUserIsValid(login);
                if (!string.IsNullOrEmpty(isUserValid))
                {
                    FormsAuthentication.SetAuthCookie(isUserValid, true);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var userDTO = new UserDTO
                    {
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Username = user.Username,
                        Email = user.Email,
                        Age = user.Age,
                        Password = user.Password
                    };

                    var isSigned = userManager.InsertUser(userDTO);

                    if (isSigned)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();
        }
    }
}