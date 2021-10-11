using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Admin_Reg
    {
        [Key]
        public int PKAdminID { get; set; }
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

        public String Role { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public String Gender { get; set; }
        public String Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public String ModifiedBy { get; set; }
    }
}