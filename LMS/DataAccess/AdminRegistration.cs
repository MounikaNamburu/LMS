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
    public class AdminRegistration
    {
        public string InsertData(Admin_Reg objReg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_InsertTbl_Admin_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", objReg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objReg.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objReg.LastName);
                cmd.Parameters.AddWithValue("@EmailID", objReg.EmailID);
                cmd.Parameters.AddWithValue("@Password", objReg.Password);
               cmd.Parameters.AddWithValue("@Role", objReg.Role);
                cmd.Parameters.AddWithValue("@DOB", objReg.DOB);
                cmd.Parameters.AddWithValue("@Gender", objReg.Gender);

               
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

        public string UpdateData(int id, Admin_Reg objReg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateTbl_Admin_Registration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKAdminID", id);
                cmd.Parameters.AddWithValue("@FirstName", objReg.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", objReg.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", objReg.LastName);
                cmd.Parameters.AddWithValue("@EmailID", objReg.EmailID);
               cmd.Parameters.AddWithValue("@Role", objReg.Role);
               cmd.Parameters.AddWithValue("@DOB", objReg.DOB);
                cmd.Parameters.AddWithValue("@Gender", objReg.Gender);
              
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

        public string GetAdmin(int id)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_GetAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKAdminID", id);

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

      

        public string CheckAdminLogin(String Username, String Password)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("GetAdminLoginInfo", con);
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

        public string GetForgotPassAdmin(String EmailID)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("GetAdminForgotPassword", con);
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

        public string UpdateAdminPass(String EmailID, String Password)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateAdminPassword", con);
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

        public string ResetAdminPass(String EmailID, String OldPass, String NewPass)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_ResetAdminPassword", con);
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