using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication15.Models
{
    public class Addtimingviewmodel
    {
        [Required]
        public int? Doctor_id { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string Timing { get; set; }
    }
}