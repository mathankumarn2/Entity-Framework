using OnlineCollegeAdmission.BL;
using OnlineCollegeAdmission.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCollegeAdmission.Controllers
{
    public class UserController : Controller
    {
        // GET: Usser
        UserBL userBL;
        public ActionResult Index()
        {
            return View();
        }
        public UserController()
        {
            userBL = new UserBL();
        }
        [HttpGet]
        [ActionName("Registration")]
        public ActionResult Registration_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Registration")]
        public ActionResult Registration_Post()
        {
            User user = new User();
            TryUpdateModel(user);
            if (user.Password != user.ConfirmPassword)
            {
                TempData["Message"] = "Both passwords are not equal";
                return View();
            }
            else if (ModelState.IsValid)
            {
                userBL.SignUp(user);
                TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string emailId = Request.Form["emailId"];
            string password = Request.Form["password"];
            if (ModelState.IsValid)
            {
                if (userBL.Login(emailId, password) == "User")
                {
                    return RedirectToAction("DisplayCollegeByUser", "College");
                }
                if (userBL.Login(emailId, password) == "Admin")
                {
                    TempData["Role"] = "Admin";
                    return RedirectToAction("DisplayCollegeByAdmin", "College");
                }
                TempData["Message"] = "Incorrect EmailId or Password";
                return View();
            }
            return View();

        }
    }
}