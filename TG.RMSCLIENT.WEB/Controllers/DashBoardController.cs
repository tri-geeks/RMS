using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.ReservationManager;
using BGW.MANAGER.Settings;
using BGW.MANAGER.FoodChartMenuManager;
using BGW.IMSF.WEB.Models;
using TG.RMSCLIENT.WEB.Security;
using BGW.MODEL.Reservation;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class DashBoardController : Controller
    {
        //
        // GET: /DashBoard/
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [CustomAuthorizeAttribute]
        [CustomActionFilter]
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

        public JsonResult GetBookingSummary()
        {
            try
            {
                ReservationManager _objmanager = new ReservationManager();
                return Json(_objmanager.GetBookingSummary(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
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



        public JsonResult LoadGallaryItem()
        {
            FoodChartMenuManager _FoodChartMenuManager = new FoodChartMenuManager();
            return Json(_FoodChartMenuManager.LoadGallaryItem(), JsonRequestBehavior.AllowGet);
        }

        #region Update Booking Status
        public ActionResult UpdateBookingStatus()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateBookingStatusC(List<BookingModel> BookingList)
        {
            try
            {
                foreach(BookingModel bookingItem in BookingList)
                {
                    bookingItem.Updated();                    
                }
                return Json(0);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
