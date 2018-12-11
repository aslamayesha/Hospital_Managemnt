using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class list_p_d
    {
        public List<Registerviewmodel> list_patient = new List<Registerviewmodel>();
        public List<RegisterDoctorviewmodel> list_doctor = new List<RegisterDoctorviewmodel>();
        public RegisterDoctorviewmodel Doctor = new RegisterDoctorviewmodel();
    }
}