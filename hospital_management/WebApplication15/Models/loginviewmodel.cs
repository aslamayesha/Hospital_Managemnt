using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class loginviewmodel
    {
       
        [Required(ErrorMessage ="this field is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "this field is required")]
       
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Display(Name ="Login As")]
        public string type { get; set; }
    }
}