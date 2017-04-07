using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BGW.MODEL.Settings
{
    public class ReservationStatusModel:BaseClass
    {


        private Int64 _ReservationStatusID;
        public Int64 ReservationStatusID
        {
            get { return _ReservationStatusID; }
            set { _ReservationStatusID = value; }
        }
        private string _StatusName;
        public string StatusName
        {
            get { return _StatusName; }
            set { _StatusName = value; }
        }
        private string _Details;
        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ReservationStatusID, _StatusName, _Details };
                this.SpName = "[Reservation].[spSaveBookingStatus]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ReservationStatusID, _StatusName, _Details };
                this.SpName = "[Reservation].[spUpdateBookingStatus]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ReservationStatusID };
                this.SpName = "[Reservation].[spUpdateBookingStatus]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ReservationStatusModel
            {
                _ReservationStatusID = reader.GetInt64("ReservationStatusID"),
                _StatusName = reader.GetToString("StatusName"),
                _Details = reader.GetToString("Details"),
            };
        }
    }
}
