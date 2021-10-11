using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;

namespace LMS.Controllers
{
    public class StudDashboardController : Controller
    {
        // GET: StudDashboard
        public ActionResult Index()
        {
            //string EmailID;
            //if (TempData.ContainsKey("Username"))
            //{
            //    // EmailID = TempData["Username"].ToString();
            //    EmailID = TempData.Peek("Username").ToString();
            //    //TempData["Username"].keep();
            //    StudentRegistrations studobj = new StudentRegistrations();

            //    DataSet ds = studobj.StudentInfo(EmailID);
            //    DataTable dt = ds.Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        TempData["StudentID"] = dt.Rows[0]["PKStudentRegID"].ToString();

            //    }

                
            //    return View();
            //}
            return View();
        }
        public ActionResult Index(string Username)
        {

            return View();
        }
    }
}