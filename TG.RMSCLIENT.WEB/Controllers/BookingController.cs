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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmBooking(Int64 bookingId)
        {
            try
            {
                _reservationManager.UpdateBookingStatus(bookingId, 2);
                return RedirectToAction("Index","Home");
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
                _reservationManager.UpdateBookingStatus(bookingId, 3);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
