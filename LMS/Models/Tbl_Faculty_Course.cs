//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Faculty_Course
    {
        public int PKFacultyCourseID { get; set; }
        public Nullable<int> FKCourseID { get; set; }
        public Nullable<int> FKFacultyRegID { get; set; }
        public Nullable<System.DateTime> AssignDate { get; set; }
        public Nullable<int> AssignedBy { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual Tbl_Admin_Registration Tbl_Admin_Registration { get; set; }
        public virtual Tbl_Course Tbl_Course { get; set; }
        public virtual Tbl_Faculty_Registration Tbl_Faculty_Registration { get; set; }
    }
}