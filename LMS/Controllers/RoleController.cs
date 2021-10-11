using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.DataAccess;
using LMS.Models;

namespace LMS.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(UserRoles objRoles)
        {
            try
            {
                if (ModelState.IsValid) //checking model is valid or not    
                {
                    Roles objDB = new Roles();
                    string result = objDB.InsertData(objRoles);
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

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id ,UserRoles objRoles)
        {
            try
            {
                Roles objDB = new Roles();
                string result = objDB.UpdateData(id, objRoles);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model  

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
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
