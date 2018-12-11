using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class New_AccountController : Controller
    {
        // GET: New_Account
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Main_login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Main_login(loginviewmodel model)
        {
            try
            {
                hospital_managementEntities db = new hospital_managementEntities();
                if (model.type == "patient")
                {
                    foreach (Register_patient R in db.Register_patient)
                    {
                        if (R.password == model.Password && R.email == model.Email )
                        {
                            return RedirectToAction("MakeAppointment", "Patient");
                        }

                    }
                }
                else if(model.type=="Doctor")
                {
                    foreach (Register_doctor R in db.Register_doctor)
                    {
                        if (R.password == model.Password && R.email == model.Email && R.type == model.type && R.status==1)
                        {
                            return RedirectToAction("Addprescription", "Doctor");
                        }

                    }
                }
                else
                {
                    return View();
                }
               
            }
            catch (Exception e)
            {
                return View();
            }
            return View();

            
        }

        public ActionResult Register_As()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register_doc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register_doc(RegisterDoctorviewmodel model)
        {
            try
            {

                Register_doctor R = new Register_doctor();
                R.answer = model.Answer;
                R.email = model.Email;
                R.name = model.name;
                R.password = model.Password;
                R.question = model.Question;
                R.category = model.Category;
                R.type = "Doctor";
                R.status = 0;
                int k = 0;
                hospital_managementEntities db = new hospital_managementEntities();
                foreach(Register_doctor t in db.Register_doctor)
                {
                    if(t.email==model.Email)
                    {
                        ViewBag.error = "this email already exists";
                        k = 1;
                        

                    }
                }
                if (k == 0)
                {
                    db.Register_doctor.Add(R);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch(Exception e) {
                return View(); }
            
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Registerviewmodel model)
        {
            try
            {
                
               
                   Register_patient R = new Register_patient();
                    R.type = "patient";
                    R.answer = model.Answer;
                    R.email = model.Email;
                    R.password = model.Password;
                    R.question = model.Question;
                    R.status = 0;
                int k = 0;
                hospital_managementEntities db = new hospital_managementEntities();
                foreach (Register_patient t in db.Register_patient)
                {
                    if (t.email == model.Email)
                    {
                        ViewBag.error = "this email already exists";
                        k = 1;


                    }
                }
                if (k == 0)
                {
                    db.Register_patient.Add(R);
                    db.SaveChanges();
                    return RedirectToAction("MakeAppointment", "Patient");
                }
                else
                {
                    return View();
                }
                
            }
            catch (Exception e)
            {
                return View();
            }
            
            
        }
    }
}