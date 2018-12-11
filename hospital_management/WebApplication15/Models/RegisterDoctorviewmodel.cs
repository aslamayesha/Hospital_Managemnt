using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class RegisterDoctorviewmodel
    {
        public int Doctor_id;
        [Required(ErrorMessage ="this field is require")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "entered text should be char")]
        public string name { get; set; }
        [Required]
        [EmailAddress]
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
        [Required]
        public string Category { get; set; }
    }
}