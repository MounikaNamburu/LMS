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
    
    public partial class Tbl_Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Course()
        {
            this.Tbl_Course_Details = new HashSet<Tbl_Course_Details>();
            this.Tbl_Course_Payment = new HashSet<Tbl_Course_Payment>();
            this.Tbl_Course_Quiz_Que = new HashSet<Tbl_Course_Quiz_Que>();
            this.Tbl_Course_Registraion = new HashSet<Tbl_Course_Registraion>();
            this.Tbl_Faculty_Course = new HashSet<Tbl_Faculty_Course>();
            this.Tbl_Student_Quiz_Result = new HashSet<Tbl_Student_Quiz_Result>();
        }
    
        public int PKCourseID { get; set; }
        public string CourseName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Duration { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> FKFacultyRegID { get; set; }
        public string CourseType { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> FKCourseCategoryID { get; set; }
        public string CourseImage { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Course_Details> Tbl_Course_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Course_Payment> Tbl_Course_Payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Course_Quiz_Que> Tbl_Course_Quiz_Que { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Course_Registraion> Tbl_Course_Registraion { get; set; }
        public virtual Tbl_Course_Category Tbl_Course_Category { get; set; }
        public virtual Tbl_Faculty_Registration Tbl_Faculty_Registration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Faculty_Course> Tbl_Faculty_Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Student_Quiz_Result> Tbl_Student_Quiz_Result { get; set; }
    }
}
