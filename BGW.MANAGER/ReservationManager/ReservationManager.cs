using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGW.MODEL.Reservation;
using BGW.MODEL.Settings;
using SSRL.DAL;

namespace BGW.MANAGER.ReservationManager
{
    public class ReservationManager
    {
        #region Object Initialization
        DBManager _conManager = new DBManager();        
        ReservationAllocationModel _reservationAllocationModel = new ReservationAllocationModel();
        ReservationTypeModel _reservationTypeModel = new ReservationTypeModel();
        BookingModel _bookingModel = new BookingModel();
        RatingModel _ratingModel = new RatingModel();
        #endregion
        #region Save Reservation Allocation
        public void SaveReservationAllocation(List<ReservationAllocationModel> allocationlist)
        {
            try
            {
                foreach (ReservationAllocationModel allocationItem in allocationlist)
                {
                    if (allocationItem.AllocationID == 0)
                        allocationItem.AllocationID = _conManager.PrimaryKey("ReservationAllocation");
                }
                _conManager.SaveCollection(allocationlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Get

        public List<ReservationAllocationModel> GetAllocationList(DateTime allocationDate)
        {
            try
            {
                return _conManager.GetDefaultCollection(_reservationAllocationModel, string.Format("SELECT * FROM Reservation.AllocateReservation WHERE AllocationDate = '{0}'", allocationDate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object VCboReservationType()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [Reservation].[ReservationType]", "ReservationTypeID", "TypeName", "-Select Reservation-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ReservationTypeModel GetTimePeriod(Int64 ReservationTypeID)
        {
            try
            {
                return _conManager.SingleCollection(_reservationTypeModel, string.Format("SELECT * FROM [Reservation].[ReservationType] WHERE ReservationTypeID = {0}", ReservationTypeID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
        #region Booking 
        public Int64 SaveBooking(List<BookingModel> bookinglist)
        {
            try
            {
                Int64 id = 0;
                foreach (BookingModel bookingItem in bookinglist)
                {
                    if (bookingItem.BookingID == 0)
                    {
                        bookingItem.BookingID = _conManager.PrimaryKey("Booking");
                        bookingItem.InvoiceID = "INV-"+bookingItem.BookingID;
                        id = bookingItem.BookingID;
                    }
                        
                }
                _conManager.SaveCollection(bookinglist);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<BookingModel> GetBookingList(Int64 BookingType, string BookingDate, Int64 BookingStatus)
        {
            try
            {
                return _conManager.GetDefaultCollection(_bookingModel, string.Format("[Reservation].[spGetBookingReservation] {0},'{1}',{2}",BookingType,BookingDate,BookingStatus));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<BookingModel> GetBookingSummary()
        {
            try
            {
                return _conManager.GetDefaultCollection(_bookingModel, "MapParameter_2", string.Format("[Reservation].[spGetBookingSummary]"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BookingModel CkeckAvailability(Int32 Qty, DateTime BookingDate, Int64 BookingType)
        {
            try
            {
                return _conManager.SingleCollection(_bookingModel, "MapParameter_1", string.Format("[Reservation].[spCheckAvailability] {0},'{1}',{2}",Qty,BookingDate,BookingType));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBookingStatus(Int64 bookingId, Int64 bookingStatus )
        {
            try
            {
                string sql = string.Format("[Reservation].[spUpdateBookingStatus]  {0},{1}", bookingId, bookingStatus);
                _conManager.ExecuteNonQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateBookingStatusAdmin(List<BookingModel> bookingList)
        {
            try
            {
                //string sql = string.Format("[Reservation].[spUpdateBookingStatus]  {0},{1}", bookingId, bookingStatus);
                //_conManager.ExecuteNonQuery(sql);
                foreach (BookingModel _bokingItem in bookingList)
                {
                    string sql = "";
                    sql = string.Format("[Reservation].[spUpdateBookingStatus]  {0},{1}", _bokingItem.BookingID, _bokingItem.BookingStatus);
                    _conManager.ExecuteNonQuery(sql);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion




        #region Rating
        /*
         * Create time 11.45 PM 4/9/17
         */
        public void SaveRating(List<RatingModel> ratinglist)
        {
            try
            {
                _conManager.SaveCollection(ratinglist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RatingModel GetRatingByEmailId(string email)
        {
            try
            {
                return _conManager.SingleCollection(_ratingModel, string.Format("Select * from Ratings Where EmailId='{0}'", email));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update Booking
        /* 
         <=======Arup=====(04/10/2017 11:25PM)>
         */

        //public void UpdateBooking(Int64 bookingId, Int64 bookingStatus)
        //{
        //    try
        //    {
        //        string sql = string.Format("[Reservation].[spUpdateBookingStatus] {0},{1}", bookingId, bookingStatus);
        //        _conManager.ExecuteNonQuery(sql);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public BookingModel GetBookingStatus(Int64 bookingId, Int64 bookingStatus)
        {
            try
            {
                return _conManager.SingleCollection(_bookingModel, "MapParameter_1", string.Format("SELECT * FROM Reservation.BookingReservation WHERE BookingID={0} AND BookingStatus={1}", bookingId, bookingStatus));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
