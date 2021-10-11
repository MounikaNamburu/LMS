using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Lessons
    {
        // PKCourseDetailsID,FKCourseID,VideoLink,UploadedDate,ModifiedDate,Status,FKFacultyRegID,Description

        [Key]
        public int PKCourseDetailsID { get; set; }
        [Required(ErrorMessage = "Please Select Course"), MaxLength(50)]
        public int FKCourseID { get; set; }
        public int FKFacultyRegID { get; set; }
        public string Description { get; set; }

        [Required]
        public string VideoLink { get; set; }

        public DateTime UploadedDate { get; set; }

        public DateTime  ModifiedDate { get; set; }

        public string Status { get; set; }

        public virtual Course CourseName { get; set; }
        public virtual Faculty_Registration EmailID { get; set; }
    }
}