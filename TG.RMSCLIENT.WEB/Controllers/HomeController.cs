using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGW.MANAGER.ReservationManager;
using BGW.MODEL.Reservation;
using BGW.MANAGER.Email;
using System.Threading;
using System.Globalization;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class HomeController : Controller
    {
        ReservationManager _reservationManager = new ReservationManager();
        EmailManager objEamilManager = new EmailManager();
        EmailCriteriaVM objEmailCriteriaVM = new EmailCriteriaVM();
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
                    //System.Web.HttpContext.Current.Session["Email"] = bookingmodel.Email;
                    objEmailCriteriaVM.Content = ConfirmURL(id);
                    objEmailCriteriaVM.Subject = "Reservation Confirmation";
                    objEmailCriteriaVM.ToEmailAddress = bookingmodel.Email;
                    objEamilManager.Email(objEmailCriteriaVM);
                    return Json("success");
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
                var UrlConfirm = Url.Action("ConfirmBooking", "Booking", new { bookingId = Id }, protocol: Request.Url.Scheme);
                var UrlCancel = Url.Action("CancealedBooking", "Booking", new { bookingId = Id }, protocol: Request.Url.Scheme);
                //string.Format("Booking/ConfirmBooking?bookingId={0}",Id);
                //string UrlCanceal = string.Format("Booking/CancealedBooking?bookingId={0}", Id);
                string htmlConform = "<p>If you want confirm booking then click on confirm link<span><a href="+ UrlConfirm + ">Confirm</a></span></p>"+"<br/>"+
                                        "<p>If you want cancel booking then click on cancel link<span><a href=" + UrlCancel + ">Cancel</a></span></p>";
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                return htmlConform;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ConfirlHTML(string confirm,string cancel)
        {
            string html =
                @"<!DOCTYPE html>
                < html >
                    < head >
                     < meta charset = 'utf-8' />
 
                     < title ></ title >
 
                     < link href = 'assets/css/bootstrap.min.css' rel = 'stylesheet' />
    
                        < script src = assets/js/jquery.min.js ></ script >
     
                         < script src = 'assets/js/bootstrap.js' ></ script >
                      </ head >
                      < body >
      
                        < div class='container'>
                        <div class='col-lg-12 col-md-12 col-sm-12 well' style='margin-top:2%;height:100%'>"+
                            "<p> If want confirm booking, clik on confirm button<input type='button' class='btn btn-success' value='Confirm' onclick='window.open("+confirm+");'> "+
                            "or want to cancel then please click cancel button<input type='button' class='btn btn-danger' value='Cancel' onclick='window.open("+cancel+");'> </p>" +
                        @"</div>
                    </div>
                </body>
                </html>";

            return html;
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


        public ActionResult ChangeLanguage(string SelectedLanguage)
        {
            if (SelectedLanguage != null)
            {
                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(SelectedLanguage);
                Thread.CurrentThread.CurrentUICulture =
                    new CultureInfo(SelectedLanguage);
                var cookie = new HttpCookie("Language");
                cookie.Value = SelectedLanguage;
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
