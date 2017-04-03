using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.ReservationManager;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class DashBoardController : Controller
    {
        //
        // GET: /DashBoard/

        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["UserID"] == null)
                return RedirectToAction("Index", "Account");
            else
                return View();
        }

        public JsonResult GetBookingList()
        {
            try
            {
                ReservationManager _objmanager = new ReservationManager();
                return Json(_objmanager.GetBookingList(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
