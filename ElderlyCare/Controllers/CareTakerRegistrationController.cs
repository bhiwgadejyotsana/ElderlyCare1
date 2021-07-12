using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElderlyCare.Models;

namespace ElderlyCare.Controllers
{
    public class CareTakerRegistrationController : Controller
    {
        // GET: CareTakerRegistration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveRegistration(CareTakerModel model)
        {
            return Json(new { message = (new CareTakerModel().SaveRegistration(model)) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRegistrationList()
        {
            try
            {
                return Json(new { model = (new CareTakerModel().GetRegistrationList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}