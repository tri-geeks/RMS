using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BGW.MODEL.Reservation
{
    public class BookingModel:BaseClass
    {


        private Int64 _BookingID;
        public Int64 BookingID
        {
            get { return _BookingID; }
            set { _BookingID = value; }
        }
        private string _InvoiceID;
        public string InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }
        private DateTime _BookingDate;
        public DateTime BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }
        private Int64 _ReservationTypeID;
        public Int64 ReservationTypeID
        {
            get { return _ReservationTypeID; }
            set { _ReservationTypeID = value; }
        }
        private string _BookingQty;
        public string BookingQty
        {
            get { return _BookingQty; }
            set { _BookingQty = value; }
        }
        private string _StartTime;
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        private string _EndTime;
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _Contact;
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        private string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        private Int64 _BookingStatus;
        public Int64 BookingStatus
        {
            get { return _BookingStatus; }
            set { _BookingStatus = value; }
        }

        private string _StatusName;
        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }

        //TypeName
        private string _TypeName;
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        private Int32 _value;
        public Int32 Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _BookingID, _InvoiceID, _BookingDate, _ReservationTypeID, _BookingQty, _StartTime, _EndTime, _Name, _Email, _Contact, _Remark, _BookingStatus };
                this.SpName = "[Reservation].[spSaveBookingReservation]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _BookingID, _InvoiceID, _BookingDate, _ReservationTypeID, _BookingQty, _StartTime, _EndTime, _Name, _Email, _Contact, _Remark, _BookingStatus };
                this.SpName = "[Reservation].[spUpdateBookingReservation]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _BookingID };
                this.SpName = "[Reservation].[spUpdateBookingReservation]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new BookingModel
            {
                _BookingID = reader.GetInt64("BookingID"),
                _InvoiceID = reader.GetToString("InvoiceID"),
                _BookingDate = reader.GetDateTime("BookingDate"),
                _ReservationTypeID = reader.GetInt64("ReservationTypeID"),
                _BookingQty = reader.GetToString("BookingQty"),
                _StartTime = reader.GetToString("StartTime"),
                _EndTime = reader.GetToString("EndTime"),
                _Name = reader.GetToString("Name"),
                _Email = reader.GetToString("Email"),
                _Contact = reader.GetToString("Contact"),
                _Remark = reader.GetToString("Remark"),
                _BookingStatus = reader.GetInt64("BookingStatus"),
                _StatusName = reader.GetToString("StatusName"),
                _TypeName = reader.GetToString("TypeName")
            };
        }

        public object MapParameter_1(IDataReader reader)
        {
            return new BookingModel
            {
                _value = reader.GetInt32("Value")
            };
        }
    }
}
