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
        [HttpPost]
        public JsonResult SaveBooking(BookingModel bookingmodel)
        {
            try
            {
                var res = CheckAvailability(Convert.ToInt32( bookingmodel.BookingQty), bookingmodel.BookingDate, bookingmodel.BookingStatus);
                if (res == (object)0)
                    return Json(0);
                else if(res==(object)2)
                    return Json(2);
                else
                {
                    if (bookingmodel.BookingID == 0)
                    {
                        bookingmodel.Added();
                        bookingmodel.BookingStatus = 1;
                    }

                    List<BookingModel> bookinglist = new List<BookingModel>();
                    bookinglist.Add(bookingmodel);
                    var id = _reservationManager.SaveBooking(bookinglist);
                    System.Web.HttpContext.Current.Session["Email"] = bookingmodel.Email;
                    return Json(id);
                }
                
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

        public JsonResult CheckAvailability(Int32 Qty,DateTime BookingDate,Int64 BookingType)
        {
            try
            {
                return Json(_reservationManager.CkeckAvailability(Qty, BookingDate, BookingType).Value,JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ConfirmURL(Int64 Id)
        {
            try
            {
                string UrlConfirm = string.Format("Booking/ConfirmBooking?bookingId={0}",Id);
                string UrlCanceal = string.Format("Booking/CancealedBooking?bookingId={0}", Id);
                string htmlConform = "<p>If you want confirm booking then click on confirm link<span><a href="+ UrlConfirm + ">Confirm</a></span></p>"+"<br/>"+
                                        "<p>If you want canceal booking then click on canceal link<span><a href=" + UrlCanceal + ">Canceal</a></span></p>";
                return htmlConform;
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Ratings App
        /*
         * Create time 11.45 PM 4/9/17
         * Created By : Mithu
         */
        public JsonResult SaveRatings(RatingModel _ratingModel)
        {
            try
            {
                var result = _reservationManager.GetRatingByEmailId(_ratingModel.EmailId);
                if (result == null)
                {
                    _ratingModel.Added();
                }
                else
                {
                    _ratingModel.Updated();
                }
                List<RatingModel> _lstRatingModel = new List<RatingModel>();
                _lstRatingModel.Add(_ratingModel);
                _reservationManager.SaveRating(_lstRatingModel);
                return Json("success");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
