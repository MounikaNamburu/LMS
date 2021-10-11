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
    public class StudentRegistrations
    {
        public string InsertInAllReg(string emailID,string role)
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
            public string CheckUserReg(String Username)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_CheckUserReg", con);
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
        public string InsertData(StudentRegistration objReg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_InsertTbl_Student_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", objReg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objReg.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objReg.LastName);
                cmd.Parameters.AddWithValue("@EmailID", objReg.EmailID);
                cmd.Parameters.AddWithValue("@Password", objReg.Password);
                cmd.Parameters.AddWithValue("@ContactNo", objReg.ContactNo);
                cmd.Parameters.AddWithValue("@AlternateContactNo", objReg.AlternateContactNo);
                cmd.Parameters.AddWithValue("@Address", objReg.Address);
                cmd.Parameters.AddWithValue("@DOB", objReg.DOB);
                cmd.Parameters.AddWithValue("@Gender", objReg.Gender);

                // @FirstName,@MiddleName,@LastName,@EmailID,@Password,@ContactNo,@AlternateContactNo,@Address,@DOB,@Gender
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

        public string UpdateData(int id, StudentRegistration objReg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateTbl_Student_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKStudentRegID", id);
                cmd.Parameters.AddWithValue("@FirstName", objReg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objReg.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objReg.LastName);
                cmd.Parameters.AddWithValue("@EmailID", objReg.EmailID);
                //cmd.Parameters.AddWithValue("@Password", objReg.Password);
                cmd.Parameters.AddWithValue("@ContactNo", objReg.ContactNo);
                cmd.Parameters.AddWithValue("@AlternateContactNo", objReg.AlternateContactNo);
                cmd.Parameters.AddWithValue("@Address", objReg.Address);
                cmd.Parameters.AddWithValue("@DOB", objReg.DOB);
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

        public string GetStudent(int id)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_GetSingleStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKStudentRegID", id);
              
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

        public string CheckStudentLogin(String Username, String Password)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("GetStudentLoginInfo", con);
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

        public string GetForgotPassStudent(String EmailID)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("GetStudentForgotPassword", con);
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

        public string UpdateStudentPass(String EmailID, String Password)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateStudentPassword", con);
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

        public string ResetStudentPass(String EmailID, String OldPass, String NewPass)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_ResetStudentPassword", con);
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

        public DataSet StudentInfo(String EmailID)
        {
            SqlConnection con = null;
            SqlDataAdapter adapter= new SqlDataAdapter();
            DataSet dataset = new DataSet();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_GetStudentData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);

                con.Open();
                adapter.SelectCommand = cmd;
                
                adapter.Fill(dataset);
                return dataset;
               
            }
            catch
            {
                return dataset = null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}