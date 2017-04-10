using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.ReservationManager;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class BookingController : Controller
    {
        ReservationManager _reservationManager = new ReservationManager();

        public ActionResult ConfrimationSuccess()
        {
            return View();
        }

        public ActionResult CancealedSuccess()
        {
            return View();
        }

        public ActionResult ConfirmBooking(Int64 bookingId)
        {
            try
            {
                if (_reservationManager.GetBookingStatus(bookingId, 2) == null)
                    _reservationManager.UpdateBookingStatus(bookingId, 2);
                return RedirectToAction("ConfrimationSuccess", "Booking");
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult CancealedBooking(Int64 bookingId)
        {
            try
            {
                if(_reservationManager.GetBookingStatus(bookingId,3)==null)
                    _reservationManager.UpdateBookingStatus(bookingId, 3);
                return RedirectToAction("CancealedSuccess", "Booking");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
