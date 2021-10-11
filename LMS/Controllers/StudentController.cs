using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;
using LMS.Models;


namespace LMS.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentRegistrations objDB = new StudentRegistrations();
            string result = objDB.GetStudent(id);
            
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentRegistration ObjStud)
        {
            try
            {
                if (ModelState.IsValid) //checking model is valid or not    
                {
                    StudentRegistrations objDB = new StudentRegistrations();
                    string result = objDB.InsertData(ObjStud);
                    //ViewData["result"] = result;    
                    TempData["result1"] = result;
                    ModelState.Clear(); //clearing model  

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentRegistration ObjStud)
        {
            try
            {
                if (ModelState.IsValid) //checking model is valid or not    
                {
                    StudentRegistrations objDB = new StudentRegistrations();
                    string result = objDB.UpdateData(id,ObjStud);
                    //ViewData["result"] = result;    
                    TempData["result1"] = result;
                    ModelState.Clear(); //clearing model  

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error in Update data");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
