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
    public class FacultyCourseOperations
    {

        public List<FacultyCourse> FacultyCourseInfo(string FacultyID)
        {
            SqlConnection con = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            List<FacultyCourse> FacultyCList = new List<FacultyCourse>();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnSring"].ToString());
                SqlCommand cmd = new SqlCommand("SP_FacultyWithCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FKFacultyRegID", FacultyID);

                con.Open();
                adapter.SelectCommand = cmd;

                adapter.Fill(dt);
               // return dt;

                foreach (DataRow dr in dt.Rows)
                {

                    FacultyCList.Add(new FacultyCourse
                        {

                        PKFacultyCourseID = Convert.ToInt32(dr["PKFacultyCourseID"]),
                      //  CourseName = Convert.ToString(dr["CourseName"]),
                        Status = Convert.ToString(dr["Status"])
                       // FKCourseID = Convert.ToString(dr["FKCourseID"])

                        } );
                }

                return FacultyCList;

            }
            catch
            {
                return FacultyCList = null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}