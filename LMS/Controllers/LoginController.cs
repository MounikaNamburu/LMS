using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;
using LMS.Models;


namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View("Index");
        }
            [HttpPost]
        //[Route("IndexLogin")]
        public ActionResult Index(String EmailID,String Password)
        {
            StudentRegistrations objStudDB = new StudentRegistrations();
            String EncodePass = Common_Functions.DESEncrypt(Password);
            string Pass = Common_Functions.DESDecrypt(EncodePass);
            String Type = objStudDB.CheckUserReg(EmailID);
            if (Type=="Student")
            { 
             
            string result = objStudDB.CheckStudentLogin(EmailID, EncodePass);
            //var s = cbe.GetCBLoginInfo(model.UserName, model.Password);


            if (result == "Success")
            {
                //TempData["Username"] = EmailID;
                //    TempData["Role"] = "Student";
                Session["Username"]= EmailID;
                    Session["Role"] = "Student";
                    return Redirect("~/Home/index.html");
                    //return View("FacultyLandingView");
                }
            else if (result == "User Does not Exists")

            {
                ViewBag.NotValidUser = result;

            }
            else if(result== "Maximum Attempt Reached (5 times) .Your Account is locked now.")
            {
                ViewBag.Failedcount = result;
            }
            

            }
            else if(Type=="Faculty")
            {
                FacultyReg objFacultyDB = new FacultyReg();
                string result = objFacultyDB.CheckFacultyLogin(EmailID, EncodePass);
                //var s = cbe.GetCBLoginInfo(model.UserName, model.Password);


                if (result == "Success")
                {
                    //TempData["Username"] = EmailID;
                    //TempData["Role"] = "Faculty";
                    Session["Username"] = EmailID;
                    Session["Role"] = "Faculty";

                    SqlConnection con = null;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataSet dataset = new DataSet();
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                    SqlCommand cmd = new SqlCommand("SP_GetFacultyDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", EmailID);

                    con.Open();
                    adapter.SelectCommand = cmd;

                    adapter.Fill(dataset);
                    foreach (DataRow dr in dataset.Tables[0].Rows)
                    {
                        Session["PKFacultyRegID"] = dr["PKFacultyRegID"];
                        Session["FirstName"] = dr["FirstName"];
                        Session["FullName"] = dr["FullName"];

                    }
                    return RedirectToAction("Dashboard", "FacultyAssignedCourses");
                    //return View("FacultyLandingView");
                }
                else if (result == "User Does not Exists")

                {
                    ViewBag.NotValidUser = result;

                }
                else if (result == "Maximum Attempt Reached (5 times) .Your Account is locked now.")
                {
                    ViewBag.Failedcount = result;
                }
            }
            else if(Type=="Admin")
            {
                AdminRegistration objAdminDB = new AdminRegistration();
                string result = objAdminDB.CheckAdminLogin(EmailID, EncodePass);
                //var s = cbe.GetCBLoginInfo(model.UserName, model.Password);


                if (result == "Success")
                {
                    //TempData["Username"] = EmailID;
                    //TempData["Role"] = "Admin";
                    Session["Username"] = EmailID;
                    Session["Role"] = "Admin";
                    //return Redirect("~/admin/Index.cshtml");
                    return Redirect("~/Admin/Index");
                    //return View("Views/Admin/Index");

                    //return RedirectToAction("Index", "Admin");
                }
                else if (result == "User Does not Exists")

                {
                    ViewBag.NotValidUser = result;

                }
                else if (result == "Maximum Attempt Reached (5 times) .Your Account is locked now.")
                {
                    ViewBag.Failedcount = result;
                }
            }
            else
            {
                ViewBag.Type = Type;
            }

            return View("Index");
        }

       

    }
}