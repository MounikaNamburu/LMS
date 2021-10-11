using LMS.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        LMS1Entities1 db = new LMS1Entities1();
        //////SqlConnection con = null;

        //////string CourseID = System.Web.HttpContext.Current.Session["PKCourseID"].ToString();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses (Tbl_Course obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult AddCourses(Tbl_Course model)
        {
            Tbl_Course obj = new Tbl_Course();
            if(ModelState.IsValid)
            {
                obj.PKCourseID = model.PKCourseID;
                obj.CourseName = model.CourseName;
                obj.CourseType = model.CourseType;
                obj.Duration = model.Duration;
                obj.FullDescription = model.FullDescription;
                obj.Price = model.Price;
                if (model.PKCourseID == 0)
                {
                    db.Tbl_Course.Add(obj);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            
            ModelState.Clear();
            return View("Courses");
        }

        public ActionResult CoursesList()
        {
            var res = db.Tbl_Course.ToList();
            return View(res);


            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
            //SqlCommand cmd = new SqlCommand("Tbl_Course", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@PKCourseID",CourseID);
            //con.Open();
            //adapter.SelectCommand = cmd;

            //adapter.Fill(ds);
            //// return dt;

            //return View(ds);
        }

        public ActionResult Delete(int id)
        {
            var res = db.Tbl_Course.Where(x => x.PKCourseID== id).First();
            db.Tbl_Course.Remove(res);
            db.SaveChanges();

            var list = db.Tbl_Course.ToList();
            return View("CoursesList",list);
        }
    }
}