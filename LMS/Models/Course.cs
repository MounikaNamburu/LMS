using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Course
    {

        // PKCourseID,CourseName,ShortDescription,FullDescription,Duration,Price,FKRegID,CourseType,Status,CreatedOn,ModifiedOn,FKCourseCategorID,CourseImage,CreatedBy

        public string PKCourseID { get; set; }
        public string CourseName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Duration { get; set; }
        public string Price { get; set; }
        public string CourseType { get; set; }
        public string Status { get; set; }




    }
}