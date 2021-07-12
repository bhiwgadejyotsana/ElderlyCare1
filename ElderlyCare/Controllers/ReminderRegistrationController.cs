using ElderlyCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElderlyCare.Controllers
{
    public class ReminderRegistrationController : Controller
    {
        // GET: ReminderRegistration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveRegistration(ReminderModel model)
        {
            return Json(new { message = (new ReminderModel().SaveRegistration(model)) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SendReminder()
        {
            return Json(new { message = (new ReminderModel().SendReminder()) }, JsonRequestBehavior.AllowGet);
        }
    }
}