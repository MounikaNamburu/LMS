using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using LMS.DataAccess;

namespace Registration.Controllers
{
    public class StudentNewRegController : Controller
    {
        // GET: StudentNewReg
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentRegClass uc,HttpPostedFileBase file)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["ConnSring"].ConnectionString;
            StudentRegistrations objStudDB = new StudentRegistrations();

          string result1= objStudDB.CheckUserExist(uc.EmailID);
            if (result1 == "User Does not Exists")
            {
                string result = objStudDB.InsertInAllReg(uc.EmailID, "Student");

                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "insert into [dbo].[Tbl_Student_Registration] (FirstName,MiddleName,LastName,EmailID,Password,ContactNo,AlternateContactNo,Address,DOB,Gender) values(@FirstName,@MiddleName,@LastName,@EmailID,@Password,@ContactNo,@AlternateContactNo,@Address,@DOB,@Gender)";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                //string sqlquery1 = "insert into [dbo].[Tbl_AllRegistration] (EmailID,Role) values(@EmailID,@Role)";
                //SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn);
                sqlconn.Open();
                //sqlcomm1.Parameters.AddWithValue("@EmailID", uc.EmailID);
                //sqlcomm1.Parameters.AddWithValue("@Role", "Student");
                sqlcomm.Parameters.AddWithValue("@FirstName", uc.FirstName);
                sqlcomm.Parameters.AddWithValue("@MiddleName", uc.MiddleName);
                sqlcomm.Parameters.AddWithValue("@LastName", uc.LastName);
                sqlcomm.Parameters.AddWithValue("@EmailID", uc.EmailID);
                sqlcomm.Parameters.AddWithValue("@Password", Common_Functions.DESEncrypt(uc.Password));
                sqlcomm.Parameters.AddWithValue("@ContactNo", uc.ContactNo);
                sqlcomm.Parameters.AddWithValue("@AlternateContactNo", uc.AlternateContactNo);
                sqlcomm.Parameters.AddWithValue("@Address", uc.Address);
                sqlcomm.Parameters.AddWithValue("@DOB", Convert.ToDateTime(uc.DOB));
                sqlcomm.Parameters.AddWithValue("@Gender", uc.Gender);
                //sqlcomm1.ExecuteNonQuery();
                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
                ViewData["Message"] = "User Record  " + uc.FirstName + " is Registered successfully !";
            }
            else
            {
                ViewData["Message"] = result1;
            }
            return View();
        }


    }
}