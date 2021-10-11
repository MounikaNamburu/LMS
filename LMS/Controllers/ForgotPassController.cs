using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;

namespace LMS.Controllers
{
    public class ForgotPassController : Controller
    {
        // GET: ForgotPass
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String EmailID, String Type)
        {

            if(Type == "Student")
            {
                StudentRegistrations objsr = new StudentRegistrations();
                string result = objsr.GetForgotPassStudent(EmailID);
                if (result == "UserExists")
                {
                    string newpass = Common_Functions.DESEncrypt(Common_Functions.RandomString());
                    string updatePass = objsr.UpdateStudentPass(EmailID, newpass);

                    string MailStatus = Common_Functions.SendMail(EmailID, "Password Reset", "newpass");
                    if(MailStatus== "success")
                    {
                        ViewBag.mailstatus = "Please Check your Email for new Password.";
                    }
                    else
                    {
                        ViewBag.mailstatus = "Failed Mail Sending ";
                    }
                }
                else
                {
                    ViewBag.NotExist = result;
                }
            }
            else if(Type == "Faculty")
            {
               FacultyReg objf = new FacultyReg();
                string result = objf.GetForgotPassFaculty(EmailID);
                if (result == "UserExists")
                {
                    string newpass = Common_Functions.DESEncrypt(Common_Functions.RandomString());
                    string updatePass = objf.UpdateFacultyPass(EmailID, newpass);
                    string body = "your password";
                    string MailStatus = Common_Functions.SendMail(EmailID, "Password Reset", body);
                    if (MailStatus == "success")
                    {
                        ViewBag.mailstatus = "Please Check your Email for new Password.";
                    }
                    else
                    {
                        ViewBag.mailstatus = "Failed Mail Sending ";
                    }
                }
                else
                {
                    ViewBag.NotExist = result;
                }
            }
            else if (Type == "Admin")
            {
                AdminRegistration objA = new AdminRegistration();
                string result = objA.GetForgotPassAdmin(EmailID);
                if (result == "UserExists")
                {
                    string newpass = Common_Functions.DESEncrypt(Common_Functions.RandomString());
                    string updatePass = objA.UpdateAdminPass(EmailID, newpass);

                    string MailStatus = Common_Functions.SendMail(EmailID, "Password Reset", "newpass");
                    if (MailStatus == "success")
                    {
                        ViewBag.mailstatus = "Please Check your Email for new Password.";
                    }
                    else
                    {
                        ViewBag.mailstatus = "Failed Mail Sending ";
                    }
                }
                else
                {
                    ViewBag.NotExist = result;
                }
            }
            else
            {
                
                    ViewBag.NotExist = "Select Your Type.";
               
            }



                return View("Index");
        }
    }
}