using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class Registerviewmodel
    {
        public int patient_id { get; set; }
        [Required(ErrorMessage ="this field is Required")]
        [EmailAddress(ErrorMessage ="email should be f correct format")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "the {0} must be atleast {2} characters long ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        [Display(Name = "Login As")]
        public string type { get; set; }
       public int register_status { get; set; }
    }
}