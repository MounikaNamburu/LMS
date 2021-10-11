using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LMS.Models;


namespace LMS.DataAccess
{
    public class FacultyReg
    {
        public int InsertData(Faculty_Registration objReg)
        {
            SqlConnection con = null;

            int result = 0;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_InsertTbl_Faculty_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", objReg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objReg.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objReg.LastName);
                cmd.Parameters.AddWithValue("@EmailID", objReg.EmailID);
                cmd.Parameters.AddWithValue("@Password", Common_Functions.DESEncrypt("LMS@123"));
                cmd.Parameters.AddWithValue("@ContactNo", objReg.ContactNo);
                cmd.Parameters.AddWithValue("@AlternateContactNo", objReg.AlternateContactNo);
                cmd.Parameters.AddWithValue("@Address", objReg.Address);
                cmd.Parameters.AddWithValue("@Skills", objReg.Skills);
                //cmd.Parameters.AddWithValue("@DOB",  Convert.ToDateTime(objReg.DOB));
                cmd.Parameters.AddWithValue("@Gender", objReg.Gender);

                // @FirstName,@MiddleName,@LastName,@EmailID,@Password,@ContactNo,@AlternateContactNo,@Address,@DOB,@Gender
                con.Open();
                result = cmd.ExecuteNonQuery();

                
                // ViewBag.mailstatus = "Please Check your Email for new Password.";
                string msgbody = "<p>Hello "+ objReg.FirstName + "</p><br> <br> <p>Please Login with below Details </p><br><p>Username:"+ objReg.EmailID + " <p>Password :LMS@123 </p><br><br><br><p>Regards,</p><br> <p>LMS TEAM</p>";

                string MailStatus = Common_Functions.SendMail(objReg.EmailID, "Login Details", msgbody);
                //if (MailStatus == "success")
                //{
                //    ViewBag.mailstatus = "Please Check your Email for new Password.";
                //}
                //else
                //{
                //    ViewBag.mailstatus = "Failed Mail Sending ";
                //}
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateData(int id, Faculty_Registration objReg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateTbl_Faculty_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKFacultyRegID", id);
                cmd.Parameters.AddWithValue("@FirstName", objReg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objReg.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objReg.LastName);
                cmd.Parameters.AddWithValue("@EmailID", objReg.EmailID);
                //cmd.Parameters.AddWithValue("@Password", objReg.Password);
                cmd.Parameters.AddWithValue("@ContactNo", objReg.ContactNo);
                cmd.Parameters.AddWithValue("@AlternateContactNo", objReg.AlternateContactNo);
                cmd.Parameters.AddWithValue("@Address", objReg.Address);
                cmd.Parameters.AddWithValue("@Skills", objReg.Skills);
                //cmd.Parameters.AddWithValue("@DOB", objReg.DOB);
                cmd.Parameters.AddWithValue("@Gender", objReg.Gender);
                cmd.Parameters.AddWithValue("@ModifiedBy", objReg.ModifiedBy);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string GetFaculty(int id)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_GetSingleFaculty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKFacultyRegID", id);

                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string CheckUserExist(String Username)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_CheckUserExist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Username);

                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string InsertInAllReg(string emailID, string role)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_InsertTbl_AllRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", emailID);
                cmd.Parameters.AddWithValue("@Role", role);


                // @FirstName,@MiddleName,@LastName,@EmailID,@Password,@ContactNo,@AlternateContactNo,@Address,@DOB,@Gender
                con.Open();
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet GetAllFaculty()
        {
            SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
           
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_GetAllFaculty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@PKFacultyRegID", id);

                con.Open();
                adapter.SelectCommand = cmd;

                adapter.Fill(ds);
                // return dt;
                //Faculty_Registration   fr = new Faculty_Registration();
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    // PKRegID,FirstName,MiddleName,LastName,EmailID,Password,ContactNo,AlternateContactNo,Address,BirthDate,Gender,
                //    //ModifiedBy,FKRoleID,Status,CreatedOn,ModifiedOn
                //    fr.PKFacultyRegID =Convert.ToInt32(dr["PKFacultyRegID"]);
                //    fr.FirstName = dr["FirstName"].ToString();
                //    fr.MiddleName = dr["MiddleName"].ToString();
                //    fr.LastName = dr["LastName"].ToString();
                //    fr.EmailID = dr["EmailID"].ToString();
                //    fr.Password = dr["Password"].ToString();
                //    fr.ContactNo = dr["ContactNo"].ToString();
                //    fr.AlternateContactNo = dr["AlternateContactNo"].ToString();
                //    fr.Address = dr["Address"].ToString();
                //    fr.DOB =Convert.ToDateTime(dr["DOB"]);
                //    fr.Gender = dr["Gender"].ToString();
                //    fr.Status = dr["Status"].ToString();
                //    fr.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                //}
                //                result ="Success";
                return ds;
            }
            catch
            {
                return ds = null;
            }
            finally
            {
                con.Close();
            }
        }

        public string CheckFacultyLogin(String Username, String Password)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("GetFacultyLoginInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string GetForgotPassFaculty(String EmailID)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("GetFacultyForgotPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", EmailID);

                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateFacultyPass(String EmailID, String Password)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateFacultyPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string ResetFacultyPass(String EmailID, String OldPass, String NewPass)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_ResetFacultyPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@OldPass", OldPass);
                cmd.Parameters.AddWithValue("@NewPass", NewPass);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
    }
}