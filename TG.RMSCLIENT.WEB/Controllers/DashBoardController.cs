using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.ReservationManager;
using BGW.MANAGER.Settings;

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

        public JsonResult GetBookingList(string BookingType,string BookingDate, string BookingStatus)
        {
            try
            {
                ReservationManager _objmanager = new ReservationManager();
                return Json(_objmanager.GetBookingList(Convert.ToInt64(BookingType),BookingDate, Convert.ToInt64(BookingStatus)), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetReservationCategory()
        {
            try
            {
                SettingsManager _objmanager = new SettingsManager();
                return Json(_objmanager.VCboRservationType(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetReservationStatus()
        {
            try
            {
                SettingsManager _objmanager = new SettingsManager();
                return Json(_objmanager.VCboRservationStatus(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

    }
}
