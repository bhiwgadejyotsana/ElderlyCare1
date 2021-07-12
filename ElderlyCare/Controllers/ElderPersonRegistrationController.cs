using ElderlyCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElderlyCare.Controllers
{
    public class ElderPersonRegistrationController : Controller
    {
        // GET: ElderPersonRegistration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveRegistration(ElderPersonModel model)
        {
            return Json(new { message = (new ElderPersonModel().SaveRegistration(model)) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRegistrationList()
        {
            try
            {
                return Json(new { model = (new ElderPersonModel().GetRegistrationList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}