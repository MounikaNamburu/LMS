using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using LMS.DataAccess;

namespace LMS.Controllers
{
    public class FacultyLoginController : Controller
    {
        // GET: FacultyLogin
        [HttpPost]
        public ActionResult Index(String EmailID, String Password)
        {
            String Pass = Common_Functions.DESDecrypt(Password);
          
            FacultyReg objDB = new FacultyReg();
            string result = objDB.CheckFacultyLogin(EmailID, Pass);
            //var s = cbe.GetCBLoginInfo(model.UserName, model.Password);


            if (result == "Success")
            {
                TempData["Username"] = EmailID;
                return View("FacultyLandingView");
            }
            else if (result == "User Does not Exists")

            {
                ViewBag.NotValidUser = result;

            }
            else
            {
                ViewBag.Failedcount = result;
            }

            return View("Index");
        }

    }
}