using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class CourseQuiz
    {
        // PKQuizID,QuestionNo,Question,OptionA,OptionB,OptionC,OptionD,NoOfCorrectAns,CorrectAns,FKFacultyRegID,CreatedOn,ModifiedOn,Status,FKCourseID
        [Key]
        public int PKQuizID { get; set; }
        public int QuestionNo { get; set; }

        [Required(ErrorMessage = "Please Enter Question !")]
        [Display(Name = " Question : ")]
        //[StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "Username length must be maximum 10 & minimum 3")]
        public string Question { get; set; }

        [Display(Name = " OptionA : ")]
        public string OptionA { get; set; }
              
        [Display(Name = " OptionB : ")]
        public string OptionB { get; set; }
                
        [Display(Name = " OptionC :")]
        public string OptionC { get; set; }
               // [Required(ErrorMessage = "Please enter Password !")]
        [Display(Name = " OptionD : ")]
        //[DataType(DataType.Password)]
        public string OptionD { get; set; }
        public string NoOfCorrectAns { get; set; }

        public string CorrectAns { get; set; }
        public string FKFacultyRegID { get; set; }
        public string CreatedOn { get; set; }
        public string Status { get; set; }
        public string FKCourseID { get; set; }
       
    }
}