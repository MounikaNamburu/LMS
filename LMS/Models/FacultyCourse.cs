using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class FacultyCourse
    {
        //PKFacultyCourseID,FKCourseID,FKFacultyRegID,AssignDate,AssignedBy,Status,ModifiedOn
        [Key]
        public int PKFacultyCourseID { get; set; }
        [Required(ErrorMessage = "Please Select Course"), MaxLength(50)]
        public int FKCourseID { get; set; }

        [Required]
        public int FKFacultyRegID { get; set; }

       
        public DateTime AssignDate { get; set; }
               
        public int AssignedBy { get; set; }

        public string Status { get; set; }

        public virtual Course CourseName { get; set; }
        public virtual Faculty_Registration EmailID { get; set; }

}
}