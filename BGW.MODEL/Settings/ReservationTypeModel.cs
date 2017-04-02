using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BGW.MODEL.Settings
{
    public class ReservationTypeModel:BaseClass
    {


        private Int64 _ReservationTypeID;
        public Int64 ReservationTypeID
        {
            get { return _ReservationTypeID; }
            set { _ReservationTypeID = value; }
        }
        private string _TypeName;
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
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



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ReservationTypeID, _TypeName, _StartTime, _EndTime };
                this.SpName = "[Reservation].[spSaveReservationType]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ReservationTypeID, _TypeName, _StartTime, _EndTime };
                this.SpName = "[Reservation].[spUpdateReservationType]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ReservationTypeID };
                this.SpName = "[Reservation].[spUpdateReservationType]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ReservationTypeModel
            {
                _ReservationTypeID = reader.GetInt64("ReservationTypeID"),
                _TypeName = reader.GetToString("TypeName"),
                _StartTime = reader.GetToString("StartTime"),
                _EndTime = reader.GetToString("EndTime"),
            };
        }
    }
}
