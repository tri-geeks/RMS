﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.ReservationManager;
using BGW.MODEL.Reservation;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class HomeController : Controller
    {
        ReservationManager _reservationManager = new ReservationManager();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveBooking(BookingModel bookingmodel)
        {
            try
            {
                if (bookingmodel.BookingID == 0)
                {
                    bookingmodel.Added();
                    bookingmodel.BookingStatus = 1;
                }
                    
                List<BookingModel> bookinglist = new List<BookingModel>();
                bookinglist.Add(bookingmodel);
                var id = _reservationManager.SaveBooking(bookinglist);
                return Json(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult CboReservationType()
        {
            try
            {
                return Json(_reservationManager.VCboReservationType(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JsonResult GetTime(Int64 reservationType)
        {
            try
            {
                return Json(_reservationManager.GetTimePeriod(reservationType),JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
