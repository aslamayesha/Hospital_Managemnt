using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class Addhistoryviewmodel
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? id { get; set; }
        public int Age { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string BP { get; set; }
        [Required]
        public int Pulse { get; set; }
        [Required]

        public string indications { get; set; }

        


    }
}