using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using WebApplication15.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication15.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Edit_Timing(int? id)
        {
            hospital_managementEntities db = new hospital_managementEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Doctor_timing t = db.Doctor_timing.Find(id);
                if (t == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Addtimingviewmodel k = new Addtimingviewmodel();
                    k.Day = t.Day;
                    k.Timing = t.Timing;
                    k.Doctor_id = t.id_doctor;
                    return View(k);
                }
            }

        }
        [HttpPost]
        public ActionResult Edit_Timing(int id,Addtimingviewmodel k)
        {
            hospital_managementEntities db = new hospital_managementEntities();
           
           
                Doctor_timing t = db.Doctor_timing.Find(id);
                if (t == null)
                {
                    return HttpNotFound();
                }
                else
                {
                   
                    t.Day = k.Day;
                    t.Timing = k.Timing;
                    db.SaveChanges();
                return RedirectToAction("ViewHistory");
                }
            

        }
        public ActionResult viewTiming(int? id)
        {
            enumerable s = new enumerable();
            hospital_managementEntities db = new hospital_managementEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register_doctor p = db.Register_doctor.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                List<Addtimingviewmodel> list = new List<Addtimingviewmodel>();
                 foreach(Doctor_timing d in db.Doctor_timing)
                {
                    if(d.id_doctor==id)
                    {
                        Addtimingviewmodel model = new Addtimingviewmodel();
                        model.Day = d.Day;
                        model.Doctor_id = d.id_doctor;
                        model.Timing = d.Timing;
                        list.Add(model);
                    }
                }
                return View(list);
            }

        }

      
        [HttpPost]
        public ActionResult Addtiming(int id,Addtimingviewmodel model)
        {
            try
            {
                hospital_managementEntities db = new hospital_managementEntities();
                Doctor_timing t = new Doctor_timing();
                t.id_doctor = id;
                t.Day = model.Day;
                t.Timing = model.Timing;
                db.Doctor_timing.Add(t);
                db.SaveChanges();
                //saving
                ModelState.Clear();
                return View(new Addtimingviewmodel());
                
               
               
            }
            catch(Exception e)
            {
                return View();
            }
        }
        public ActionResult Addtiming( int? id)
        {
            enumerable s = new enumerable();
            hospital_managementEntities db = new hospital_managementEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register_doctor p = db.Register_doctor.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View();
            }
            
        }

        public ActionResult ViewHistory()
        {
            hospital_managementEntities db = new hospital_managementEntities();
            List<RegisterDoctorviewmodel> list = new List<RegisterDoctorviewmodel>();
            foreach(Register_doctor R in db.Register_doctor)
            {
                if(R.status==1)
                {
                    RegisterDoctorviewmodel model = new RegisterDoctorviewmodel();
                    model.name = R.name;
                    model.Email = R.email;
                    model.Password = R.password;
                    model.Question = R.question;
                    model.Answer = R.answer;
                    model.Category = R.category;
                    model.register_status = R.status;
                    model.type = R.type;
                    model.Doctor_id = R.id;
                    list.Add(model);
                }
            }
            return View(list);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult unRegister_patient(int ?id,string type)
        {
            hospital_managementEntities db = new hospital_managementEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (type == "patient")
            {
                Register_patient p = db.Register_patient.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Registerviewmodel R = new Registerviewmodel();
                    R.Email = p.email;
                    R.Password = p.password;
                    R.patient_id = p.id;
                    R.Question = p.question;
                    R.register_status = p.status;
                    R.type = p.type;
                    R.Answer = p.answer;
                    return View(R);


                }
            }
            else if (type == "Doctor")
            {
                Register_doctor p = db.Register_doctor.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    RegisterDoctorviewmodel R = new RegisterDoctorviewmodel();
                    R.name = p.name;
                    R.Email = p.email;
                    R.Password = p.password;
                    R.Doctor_id = p.id;
                    R.Question = p.question;
                    R.register_status = p.status;
                    R.type = p.type;
                    R.Category = p.category;

                    R.Answer = p.answer;
                    return View(R);


                }
            }
            else
            {
                return HttpNotFound();
            }


        }
        public  ActionResult Register(int ?id,string type)
        {
            hospital_managementEntities db = new hospital_managementEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (type == "patient")
            {
                Register_patient p = db.Register_patient.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Registerviewmodel R = new Registerviewmodel();
                    R.Email = p.email;
                    R.Password = p.password;
                    R.patient_id = p.id;
                    R.Question = p.question;
                    R.register_status = p.status;
                    R.type = p.type;
                    R.Answer = p.answer;
                    return View(R);


                }
            }
            else if(type=="Doctor")
            {
                Register_doctor p = db.Register_doctor.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    RegisterDoctorviewmodel R = new RegisterDoctorviewmodel();
                    R.Email = p.email;
                    R.Password = p.password;
                    R.Doctor_id = p.id;
                    R.Question = p.question;
                    R.register_status = p.status;
                    R.type = p.type;
                    R.Category = p.category;
                    
                    R.Answer = p.answer;
                    return View(R);


                }
            }
            else
            {
                return HttpNotFound();
            }
            
        }
        [HttpPost]
        public ActionResult Register(int id,string type)
        {
            try
            {
                // TODO: Add delete logic here
                hospital_managementEntities db = new hospital_managementEntities();

                if (type == "patient")
                {
                    Register_patient p = db.Register_patient.Find(id);
                    p.status = 1;
                    db.SaveChanges();
                    return RedirectToAction("Approve_status");
                }
                else if(type=="Doctor")
                {
                    Register_doctor p = db.Register_doctor.Find(id);
                    p.status = 1;
                    db.SaveChanges();
                    return RedirectToAction("Approve_status");
                }
                else
                {
                    return RedirectToAction("Register");
                }
               

                
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult unRegister_patient(int id,string type)
        {
            try
            {
               
                hospital_managementEntities db = new hospital_managementEntities();

                if (type == "patient")
                {
                    Register_patient p = db.Register_patient.Find(id);
                    db.Register_patient.Remove(p);
                    db.SaveChanges();

                    return RedirectToAction("Approve_status");
                }
                else if(type=="Doctor")
                {
                    Register_doctor p = db.Register_doctor.Find(id);
                    db.Register_doctor.Remove(p);
                    db.SaveChanges();
                    return RedirectToAction("Approve_status");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Approve_status()
        {
            list_p_d list = new list_p_d();
            hospital_managementEntities db = new hospital_managementEntities();
            foreach(Register_patient p in db.Register_patient)
            {
                if (p.status == 0)
                {
                    Registerviewmodel R = new Registerviewmodel();
                    R.Email = p.email;
                    R.Password = p.password;
                    
                    R.patient_id = p.id;
                    R.Question = p.question;
                    R.register_status = p.status;
                    R.Answer = p.answer;
                    R.type = p.type;
                    R.ConfirmPassword = p.password;
                    list.list_patient.Add(R);
                }
                
            }
            foreach (Register_doctor p in db.Register_doctor)
            {
                if (p.status == 0) { 
                    RegisterDoctorviewmodel R = new RegisterDoctorviewmodel();
                    R.Email = p.email;
                    R.name = p.name;
                    R.Password = p.password;
                    R.Doctor_id = p.id;
                    R.Question = p.question;
                    R.register_status = p.status;
                    R.Answer = p.answer;
                    R.type = p.type;
                    R.Category = p.category;
                    R.ConfirmPassword = p.password;
                    list.list_doctor.Add(R);
                }

            }

            return View(list);
        }

        public ActionResult AddDoctor()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddDoctor(AddDoctorviewmodel model)
        {
            try
            {
                return View();

            }
            catch(Exception e)
            {

                return View();
            }
            
        }
        public ActionResult ApproveStatus()
        {

            return View();
        }

    }
}

 