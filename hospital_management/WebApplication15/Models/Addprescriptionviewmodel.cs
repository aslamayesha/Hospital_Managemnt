using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class Addprescriptionviewmodel
    {
        public int? id { get; set; }
       [Required]
        public int PatientId { get; set; }
        [Required]
        public string Medicine { get; set; }
        [Required]

        public int Duration { get; set; }
        public int? Morning { get; set; }
        public int? Noon { get; set; }
        public int? Evening{ get; set; }
      

    }
}