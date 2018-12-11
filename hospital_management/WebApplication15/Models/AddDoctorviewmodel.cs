using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication15.Models
{
    public class AddDoctorviewmodel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "the {0} must be atleast {2} characters long ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       [Required]
        public string Category { get; set; }
        [Required]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Enter only alphabets and numbers of First Name")]
        public string Name { get; set; }
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}