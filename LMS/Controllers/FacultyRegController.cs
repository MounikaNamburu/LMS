using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace LMS.Controllers
{
    public class FacultyRegController : Controller
    {
        // GET: FacultyReg
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(FacultyRegClass uc, HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["ConnSring"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into [dbo].[Tbl_Faculty_Registration] (FirstName,MiddleName,LastName,EmailID,Password,ContactNo,AlternateContactNo,Address,Skills,DOB,Gender) values (@FirstName,@MiddleName,@LastName,@EmailID,@Password,@ContactNo,@AlternateContactNo,@Address,@Skills,@DOB,@Gender) ";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@FirstName", uc.FirstName);
            sqlcomm.Parameters.AddWithValue("@MiddleName", uc.MiddleName);
            sqlcomm.Parameters.AddWithValue("@LastName", uc.LastName);
            sqlcomm.Parameters.AddWithValue("@EmailID", uc.EmailID);
            sqlcomm.Parameters.AddWithValue("@Password", uc.Password);
            sqlcomm.Parameters.AddWithValue("@ContactNo", uc.ContactNo);
            sqlcomm.Parameters.AddWithValue("@AlternateContactNo", uc.AlternateContactNo);
            sqlcomm.Parameters.AddWithValue("@Address", uc.Address);
            sqlcomm.Parameters.AddWithValue("@Skills", uc.Skills);
            sqlcomm.Parameters.AddWithValue("@DOB", uc.DOB);
            sqlcomm.Parameters.AddWithValue("@Gender", uc.Gender);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            ViewData["Message"] = "User " + uc.FirstName + " is Registered successfully !";
            return View();
        }
    }
}