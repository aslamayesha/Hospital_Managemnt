using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
 
    public class DoctorController : Controller
    {
        public ActionResult Delete_history(int id)
        {

            hospital_managementEntities db = new hospital_managementEntities();
            Patient_History p = db.Patient_History.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {

                Addhistoryviewmodel model = new Addhistoryviewmodel();
                model.Age = p.Age;
                model.BP = p.BP;
                model.Gender = p.Gender;
                model.id = p.id;
                model.indications = p.indications;
                model.PatientId = p.patient_id;
                model.Pulse = p.Pulse;
                model.Weight = p.Weight;
                return View(model);
            }

        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete_history(int id, FormCollection collection)
        {
            hospital_managementEntities db = new hospital_managementEntities();

            try
            {
                // TODO: Add delete logic here
                Patient_History r = db.Patient_History.Find(id);
                db.Patient_History.Remove(r);
                db.SaveChanges();

                return RedirectToAction("checkdetails");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit_history(int id)
        {
            hospital_managementEntities db = new hospital_managementEntities();
            Patient_History p = db.Patient_History.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                Addhistoryviewmodel model = new Addhistoryviewmodel();
                model.Age = p.Age;
                model.BP = p.BP;
                model.Gender = p.Gender;
                model.id = p.id;
                model.indications = p.indications;
                model.PatientId = p.patient_id;
                model.Pulse = p.Pulse;
                model.Weight = p.Weight;

                ViewBag.collection = model;
                return View(model);
            }
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit_history(int id, Addhistoryviewmodel collection)
        {
            try
            {
                // TODO: Add update logic here
                hospital_managementEntities db = new hospital_managementEntities();
            Patient_History p = db.Patient_History.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    p.Age = collection.Age;
                    p.BP = collection.BP;
                    p.Gender = collection.Gender;
                    p.indications = collection.indications;
                    p.patient_id = collection.PatientId;
                    p.Pulse = collection.Pulse;
                    p.Weight = collection.Weight;

                    db.SaveChanges();

                }

                return RedirectToAction("checkdetails");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            hospital_managementEntities db = new hospital_managementEntities();
            Patient_Prescription p = db.Patient_Prescription.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                Addprescriptionviewmodel model = new Addprescriptionviewmodel();
                model.Duration = p.Duration;
                model.Evening = p.Evening;
                model.Medicine = p.Medicine;
                model.Morning = p.Morning;
                model.Noon = p.Noon;
                model.PatientId = id;

                ViewBag.collection = model;
                return View(model);
            }
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Addprescriptionviewmodel collection)
        {
            try
            {
                // TODO: Add update logic here
                hospital_managementEntities db = new hospital_managementEntities();
                Patient_Prescription p = db.Patient_Prescription.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
                else {
                    p.Duration = collection.Duration;

                    p.Evening = collection.Evening;
                    p.Medicine = collection.Medicine;
                   p.Morning = collection.Morning;
                   p.Noon = collection.Noon;
                    p.Registerid = collection.PatientId;

                    db.SaveChanges();

                }

                return RedirectToAction("checkdetails");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {

            hospital_managementEntities db = new hospital_managementEntities();
            Patient_Prescription r = db.Patient_Prescription.Find(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            else {

                Addprescriptionviewmodel p = new Addprescriptionviewmodel();
                p.Duration = r.Duration;
                p.Evening = r.Evening;
                p.Medicine = r.Medicine;
                p.Morning = r.Morning;
                p.Noon = r.Noon;
                p.PatientId= id;
                return View(p);
            }
        
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            hospital_managementEntities db = new hospital_managementEntities();
        
            try
            {
                // TODO: Add delete logic here
                Patient_Prescription r = db.Patient_Prescription.Find(id);
                db.Patient_Prescription.Remove(r);
                db.SaveChanges();

                return RedirectToAction("checkdetails");
            }
            catch(Exception e)
            {
                return View();
            }
        }
        public ActionResult AddHistory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHistory(Addhistoryviewmodel model)
        {

            hospital_managementEntities db = new hospital_managementEntities();

            Register_patient S = db.Register_patient.Find(model.PatientId);
            if (S == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                Patient_History h = new Patient_History();
                h.Gender = model.Gender;
                h.Age = model.Age;
                h.Weight = model.Weight;
                h.BP = model.BP;
                h.Pulse = model.Pulse;
                h.patient_id = model.PatientId;
                h.indications = model.indications;
                db.Patient_History.Add(h);
                db.SaveChanges();

                return RedirectToAction("checkdetails");
            }
            return View();
        }
   
        public ActionResult Addprescription()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addprescription(Addprescriptionviewmodel model)
        {
            hospital_managementEntities db = new hospital_managementEntities();
            
             Register_patient R= db.Register_patient.Find(model.PatientId);

            if (R == null)
            {
                return HttpNotFound();
            }
            else
            {
                Patient_Prescription p = new Patient_Prescription();
                p.Duration = model.Duration;
                p.Evening = model.Evening;
                p.Medicine = model.Medicine;
                p.Morning = model.Morning;
                p.Noon = model.Noon;
                p.Registerid = model.PatientId;
                db.Patient_Prescription.Add(p);
                db.SaveChanges();
               
                return RedirectToAction("AddHistory");
            }
            
        }
       /* public ActionResult view_prescription(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            else
            {
                hospital_managementEntities db = new hospital_managementEntities();
                List<Addprescriptionviewmodel> list = new List<Addprescriptionviewmodel>();
                foreach (Patient_Prescription p in db.Patient_Prescription)
                {
                    if (p.Registerid == id)
                    {
                        Addprescriptionviewmodel model = new Addprescriptionviewmodel();
                        
                        model.Duration = p.Duration;
                        model.Evening = p.Evening;
                        model.Medicine = p.Medicine;
                        model.Morning = p.Morning;
                        model.Noon = p.Noon;
                        model.PatientId = id;
                    }
                }
            }
        }*/
        public ActionResult checkdetails() { return View(); }
        [HttpPost]
        public ActionResult checkdetails(checkdetailsviewmodel mod)
        {
            int r = 0;
            int k = 0;
            list_pat_details list = new list_pat_details();
            hospital_managementEntities db = new hospital_managementEntities();
            Patient_Prescription R = db.Patient_Prescription.Find(mod.PatientId);
            Patient_History K = db.Patient_History.Find(mod.PatientId);
            foreach(Patient_Prescription p in db.Patient_Prescription)
            {
                if(p.Registerid==mod.PatientId)
                {
                    r = 1;
                }
            }
            foreach (Patient_History p in db.Patient_History)
            {
                if (p.patient_id == mod.PatientId)
                {
                    k = 1;
                }
            }

            if (r == 0 && k == 0)
            {
                return HttpNotFound();
            }
            /*else
            {
              
                Addprescriptionviewmodel S = new Addprescriptionviewmodel();
                Addhistoryviewmodel Q = new Addhistoryviewmodel();


                S.PatientId = mod.PatientId;
                S.Medicine = R.Medicine;
                S.Duration = R.Duration;
                S.Morning = R.Noon;
                S.Evening = R.Evening;
                S.Morning = R.Morning;
                Q.Gender = K.Gender;
                Q.Age = K.Age;
                Q.BP = K.BP;
                Q.Weight = K.Weight;
                Q.Pulse = K.Pulse;
                Q.indications = K.indications;
                Q.PatientId = mod.PatientId;
                list.list_history.Add(Q);

                list.list_prescription.Add(S);
                
            }*/
            else
            {

                return RedirectToAction("checkdetailslist", new { id = mod.PatientId });
            }
        }
        
        public ActionResult checkdetailslist(int id) {
            int r = 0;
            int k = 0;
            list_pat_details list = new list_pat_details();
            hospital_managementEntities db = new hospital_managementEntities();

            foreach (Patient_Prescription p in db.Patient_Prescription)
            {
                if (p.Registerid == id)
                {
                    r = 1;
                }
            }
            foreach (Patient_History p in db.Patient_History)
            {
                if (p.patient_id == id)
                {
                    k = 1;
                }
            }



            if (r == 0 && k == 0)
                {
                    return HttpNotFound();
                }
                else
                {

                    Addprescriptionviewmodel S = new Addprescriptionviewmodel();
                    Addhistoryviewmodel Q = new Addhistoryviewmodel();



               foreach(Patient_Prescription p in db.Patient_Prescription)
                {
                    if(p.Registerid==id)
                    {
                        S.Duration = p.Duration;
                        S.Evening = p.Evening;
                        S.Medicine = p.Medicine;
                        S.Morning = p.Morning;
                        S.Noon = p.Noon;
                        S.id = p.SR;
                        S.PatientId = p.Registerid;

                    }
                }
               foreach(Patient_History p in db.Patient_History)
                {
                    if(p.patient_id==id)
                    {
                        Q.Age = p.Age;
                        Q.BP = p.BP;
                        Q.Gender = p.Gender;
                        Q.indications = p.indications;
                        Q.PatientId = p.patient_id;
                        Q.Pulse = p.Pulse;
                        Q.id = p.id;
                        Q.Weight = p.Weight;
                       
                    }
                }

                    list.list_history.Add(Q);
                    list.list_prescription.Add(S);

                }
            
            return View(list);
            /*else
            {
              
                Addprescriptionviewmodel S = new Addprescriptionviewmodel();
                Addhistoryviewmodel Q = new Addhistoryviewmodel();


                S.PatientId = mod.PatientId;
                S.Medicine = R.Medicine;
                S.Duration = R.Duration;
                S.Morning = R.Noon;
                S.Evening = R.Evening;
                S.Morning = R.Morning;
                Q.Gender = K.Gender;
                Q.Age = K.Age;
                Q.BP = K.BP;
                Q.Weight = K.Weight;
                Q.Pulse = K.Pulse;
                Q.indications = K.indications;
                Q.PatientId = mod.PatientId;
                list.list_history.Add(Q);

                list.list_prescription.Add(S);
                
            }*/
            


          }



    }
}
