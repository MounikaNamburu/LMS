using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class StudentRegClass
    {
        [Required(ErrorMessage ="Please Enter First Name !")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your first name is not in a valid format")]
        [Display(Name = " First Name : ")]
        [StringLength(maximumLength:10,MinimumLength =3, ErrorMessage = "Username length must be maximum 10 & minimum 3")]
        public string FirstName { get; set; }

        
        [Display(Name = " Middle Name : ")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your second name is not in a valid format")]
        public string MiddleName { get; set; }

        
        [Required(ErrorMessage = "Please Enter Last Name !")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Your last name is not in a valid format")]
        [Display(Name = " Last Name : ")]
        public string LastName { get; set; }


        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Your email address is not in a valid format")]
        [Required(ErrorMessage = "Please enter the Email Address !")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = " Email ID :")]
        public string EmailID { get; set; }


        [Required(ErrorMessage ="Please enter Password !")]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number")]
        [Display(Name = " Password : ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Please enter RePassword !")]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{5,}", ErrorMessage = "Your password must be at least 5 characters long and contain at least 1 letter and 1 number")]
        [Display(Name = " Re-Password : ")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Repwd { get; set; }


        [Required(ErrorMessage = "Please enter Contact Number !")]
        [Display(Name = " Contact Number : ")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Phone Number must be 10 digits")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }


        [Required(ErrorMessage = "Please enter Alternate Contact Number !")]
        [Display(Name = " Alternate Contact Number : ")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Phone Number must be 10 digits")]
        [DataType(DataType.PhoneNumber)]
        public string AlternateContactNo { get; set; }


        [Required(ErrorMessage = "Please Enter Address !")]
        [Display(Name = " Address : ")]
        [StringLength(maximumLength: 30, MinimumLength = 10, ErrorMessage = "Address must be #no,Area,Pincode")]
        public string Address { get; set; }





        [Display(Name = " DOB (dd/mm/yyyy) : ")]
        [Required(ErrorMessage = "Please Enter DOB in dd/mm/yyyy format !")]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "select the Gender !")]
        [Display(Name =" Gender : ")]
        public char Gender { get; set; }

        //public string Status { get; set; }
        //public string CreatedOn { get; set; }
        //public string ModifiedOn { get; set; }
        //public string ModifiedBy { get; set; }


    }
}