﻿using System;
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

        public List<BookingModel> GetBookingList()
        {
            try
            {
                return _conManager.GetDefaultCollection(_bookingModel, string.Format("[Reservation].[spGetBookingReservation]"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
