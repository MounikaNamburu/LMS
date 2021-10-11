using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;

namespace LMS.Controllers
{
    public class ResetPasswordController : Controller
    {
        // GET: ResetPassword
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index( string Password, string newPassword)
        {
            if (ModelState.IsValid)
            {
                StudentRegistrations objstud = new StudentRegistrations();
                FacultyReg objfaculty = new FacultyReg();
                AdminRegistration objadmin = new AdminRegistration();
                if (Session["Username"] != null && Session["Role"] != null)
                {
                    string oldpass = Common_Functions.DESEncrypt(Password);
                    string newpass = Common_Functions.DESEncrypt(newPassword);

                    if (Session["Role"].ToString().Trim() == "Student")
                    {
                        string result = objstud.ResetStudentPass(Session["Username"].ToString(), oldpass, newpass);
                        if (result == "Success")
                        {
                            ViewBag.Result = "Password reset Successfully.";
                        }
                        else
                        {
                            ViewBag.Result = "Invalid Password.";
                        }
                    }
                    else if (Session["Role"].ToString().Trim() == "Faculty")
                    {
                        string result = objfaculty.ResetFacultyPass(Session["Username"].ToString(), oldpass, newpass);
                        if (result == "Success")
                        {
                            ViewBag.Result = "Password reset Successfully.";
                        }
                        else
                        {
                            ViewBag.Result = "Invalid Password.";
                        }
                    }
                    else if (Session["Role"].ToString().Trim() == "Admin")

                    {
                        string result = objadmin.ResetAdminPass(Session["Username"].ToString(), oldpass, newpass);
                        if (result == "Success")
                        {
                            ViewBag.Result = "Password reset Successfully.";
                        }
                        else
                        {
                            ViewBag.Result = "Invalid Password.";
                        }
                    }

                }
                else
                    ViewBag.Result = "Session Expired.";

            }
            return View();

        }
    }
}