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
    public class Roles
    {
        public string InsertData(UserRoles objRole)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
              con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_InsertTbl_Role", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", objRole.RoleName);
              
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

        public string UpdateData(int id, UserRoles objRole)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_UpdateRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PKRoleID",id);    
                cmd.Parameters.AddWithValue("@RoleName", objRole.RoleName);
                cmd.Parameters.AddWithValue("@ModifiedBy", objRole.ModifiedBy);
               
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