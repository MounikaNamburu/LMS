using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class StudentRegistration
    {
        //        PKRegID,FirstName,MiddleName,LastName,EmailID,Password,ContactNo,AlternateContactNo,Address,BirthDate,Gender,
        //ModifiedBy,FKRoleID,Status,CreatedOn,ModifiedOn
        [Key]
        public int PKStudentRegID { get; set; }
        [Required(ErrorMessage = "Please enter FirstName"), MaxLength(50)]
        public String FirstName { get; set; }
        [Required]
        public String MiddleName { get; set; }
        [Required]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public String EmailID { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public String newPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare(nameof(newPassword), ErrorMessage = "Password and Confirmation Password must match.")]
        //[Compare("newPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        public String confirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter Mobile No")]
        public String ContactNo { get; set; }
        public String AlternateContactNo { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public String Gender { get; set; }
        public String Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public String ModifiedBy { get; set; }

        public String Type { get; set; }
    }
}