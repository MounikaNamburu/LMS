using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;
using LMS.Models;

namespace LMS.Controllers
{
    public class FacultyAssignedCoursesController : Controller
    {
        SqlConnection con = null;
       // string FacultyID = "1";
        string FacultyID = System.Web.HttpContext.Current.Session["PKFacultyRegID"].ToString();
        // GET: FacultyAssignedCourses
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Index()
        {
            
           
            //string FacultyId = Session["PKFacultyRegID"].ToString();
            //FacultyCourseOperations fco = new FacultyCourseOperations();
            //List<FacultyCourse> FacultyCList = new List<FacultyCourse>();
            //FacultyCList = fco.FacultyCourseInfo(FacultyId);
           // SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //try
            //{
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_FacultyWithCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FKFacultyRegID", FacultyID);

            con.Open();
            adapter.SelectCommand = cmd;

            adapter.Fill(ds);
            // return dt;

            return View(ds);
            //}
            //catch
            //{
            //    return ds = null;
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
        public ActionResult LessonList(string FKCourseID)
        {
            TempData["FKCourseID"] = FKCourseID;
            Session["FKCourseID"]= FKCourseID;
            string FacultyID = "1";
            //string FKCourseID = "203";
           // SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_CourseLessons", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FKCourseID", FKCourseID);
            cmd.Parameters.AddWithValue("@FKFacultyRegID", FacultyID);

            con.Open();
            adapter.SelectCommand = cmd;

            adapter.Fill(ds);
            // return dt;

            return View(ds);

        }

        public ActionResult DeactivateLesson(string PKCourseDetailsID)
        {

            //string FKCourseID = "203";
            SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_ChangeLessonStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PKCourseDetailsID", PKCourseDetailsID);
            //cmd.Parameters.AddWithValue("@Status", Status);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            // con.Open();
            ViewData["Message"] = "Lesson Deactivated successfully !";
           
                return RedirectToAction("LessonList", "FacultyAssignedCourses", new { FKCourseID = Session["FKCourseID"].ToString() });

            //return RedirectToAction("LessonList", "FacultyAssignedCourses", new { FKCourseID = TempData["FKCourseID"].ToString() });
            //TempData.Keep();
            // return RedirectToAction("LessonList");

        }

        public ActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLesson( HttpPostedFileBase postedFile,string Description)
        {
           // string VideoLink = "";
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // VideoLink = path + Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
               // 
            


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_InsertTbl_Course_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FKCourseID", Session["FKCourseID"].ToString());
            cmd.Parameters.AddWithValue("@VideoLink", postedFile.FileName);
            cmd.Parameters.AddWithValue("@FKFacultyRegID", FacultyID);
            cmd.Parameters.AddWithValue("@Description", Description);
            con.Open();
            int i = cmd.ExecuteNonQuery();
                if(i>0)
                    ViewBag.Message = "Lesson Added successfully.";
                
            }
            else
                ViewBag.Message = "Please upload file.";
            return View();
        }

        //public ActionResult CourseQuizQueList()
        //{
        //    return View();
        //}
        public ActionResult CourseQuizQueList(string FKCourseID)
        {
            TempData["FKCourseID"] = FKCourseID;
            Session["FKCourseID"] = FKCourseID;
            //string FacultyID = "1";
            //string FKCourseID = "203";
            // SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_CourseQuizQuestionList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FKFacultyRegID", Session["PKFacultyRegID"].ToString());
            cmd.Parameters.AddWithValue("@FKCourseID", Session["FKCourseID"].ToString());
            

            con.Open();
            adapter.SelectCommand = cmd;

            adapter.Fill(ds);
            // return dt;
            
            return View(ds);

        }

        public ActionResult ChangeQueStatus(string PKQuizID)
        {

            //string FKCourseID = "203";
            SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_ChangeQuizQueStatus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PKQuizID", PKQuizID);
            //cmd.Parameters.AddWithValue("@Status", Status);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            // con.Open();
            ViewData["Message"] = "Question Deactivated successfully !";

            return RedirectToAction("CourseQuizQueList", "FacultyAssignedCourses", new { FKCourseID = Session["FKCourseID"].ToString() });

            //return RedirectToAction("LessonList", "FacultyAssignedCourses", new { FKCourseID = TempData["FKCourseID"].ToString() });
            //TempData.Keep();
            // return RedirectToAction("LessonList");

        }
        public ActionResult AddCourseQUE()
        {
            return View();
        }
       [HttpPost]
        public ActionResult AddCourseQUE(CourseQuiz cq)
        {
            
               con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_InsertTbl_Course_Quiz_Que", con);
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuestionNo", cq.QuestionNo);
            cmd.Parameters.AddWithValue("@Question", cq.Question); 
            cmd.Parameters.AddWithValue("@OptionA", cq.OptionA);
            cmd.Parameters.AddWithValue("@OptionB", cq.OptionB);
            cmd.Parameters.AddWithValue("@OptionC", cq.OptionC);
            cmd.Parameters.AddWithValue("@OptionD", cq.OptionD);
            cmd.Parameters.AddWithValue("@NoOfCorrectAns", cq.NoOfCorrectAns);
            cmd.Parameters.AddWithValue("@CorrectAns", cq.CorrectAns);
            cmd.Parameters.AddWithValue("@FKFacultyRegID", FacultyID);
            cmd.Parameters.AddWithValue("@FKCourseID", Session["FKCourseID"].ToString());
                        
                
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    ViewBag.Message = "Question Added successfully.";

           
            return View();
        }

        public ActionResult EditCourseQUE(CourseQuiz cq)
        {

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            SqlCommand cmd = new SqlCommand("SP_UpdateTbl_Course_Quiz_Que", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PKQuizID", cq.PKQuizID);
            cmd.Parameters.AddWithValue("@QuestionNo", cq.QuestionNo);
            cmd.Parameters.AddWithValue("@Question", cq.Question);
            cmd.Parameters.AddWithValue("@OptionA", cq.OptionA);
            cmd.Parameters.AddWithValue("@OptionB", cq.OptionB);
            cmd.Parameters.AddWithValue("@OptionC", cq.OptionC);
            cmd.Parameters.AddWithValue("@OptionD", cq.OptionD);
            cmd.Parameters.AddWithValue("@NoOfCorrectAns", cq.NoOfCorrectAns);
            cmd.Parameters.AddWithValue("@CorrectAns", cq.CorrectAns);
                        con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                ViewBag.Message = "Question Edited successfully.";


            return View();
        }
    }
}