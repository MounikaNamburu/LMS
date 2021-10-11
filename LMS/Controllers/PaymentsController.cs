
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample.Controllers
{
    public class PaymentsController : Controller
    {
        LMS1Entities1 db = new LMS1Entities1();
        // GET: Payments
        public ActionResult Payments()
        {
            //var data = db.Database.SqlQuery<Tbl_Payments("sp_Payments_Result").ToList();
            //return View(data);

            //Payments objDB = new Payments();
            //string result = objDB.GetPayments(id);

            return View();
        }
        public ActionResult Faculty()
        {
            return View();
        }
        public ActionResult Students()
        {
            return View();
        }

    }
}