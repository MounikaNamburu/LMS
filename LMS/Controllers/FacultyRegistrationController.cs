using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using LMS.DataAccess;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace LMS.Controllers
{
    public class FacultyRegistrationController : Controller
    {
        FacultyReg objfr = new FacultyReg();
        // GET: FacultyRegistration
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
           ds = objfr.GetAllFaculty();
            return View(ds);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Faculty_Registration fr, HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["ConnSring"].ConnectionString;
            string result1 = objfr.CheckUserExist(fr.EmailID);
            if (result1 == "User Does not Exists")
            {
                string result2 = objfr.InsertInAllReg(fr.EmailID, "Faculty");
                int result = objfr.InsertData(fr);
                if (result > 0)
                    ViewData["Message"] = "Faculty Registered successfully !";
            }
            else
                ViewData["Message"] = result1;

            return View();
        }
        public ActionResult ChangeStatus(string PKFacultyRegID)
        {

            //string FKCourseID = "203";
            SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_ChangeFacultyStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PKFacultyRegID", PKFacultyRegID);
            //cmd.Parameters.AddWithValue("@Status", Status);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            // con.Open();
            ViewData["Message"] = "Faculty Deactivated successfully !";
            return RedirectToAction("Index");
          //  return RedirectToAction("Index", "FacultyRegistration");

            //return RedirectToAction("LessonList", "FacultyAssignedCourses", new { FKCourseID = TempData["FKCourseID"].ToString() });
            //TempData.Keep();
            // return RedirectToAction("LessonList");

        }

    }
}