using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LMS.Models
{
    public class UserRoles
    {
        [Key]
        public int PKRoleID { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
       // [StringLength(50, ErrorMessage = "Name should be less than or equal to four characters.")]
           public    String RoleName { get; set; }
        public String Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int  ModifiedBy { get; set; }
        
    }
}