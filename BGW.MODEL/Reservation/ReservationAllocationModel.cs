using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BGW.MODEL.Reservation
{
    public class ReservationAllocationModel:BaseClass
    {


        private Int64 _AllocationID;
        public Int64 AllocationID
        {
            get { return _AllocationID; }
            set { _AllocationID = value; }
        }
        private Int64 _ReservationTypeID;
        public Int64 ReservationTypeID
        {
            get { return _ReservationTypeID; }
            set { _ReservationTypeID = value; }
        }
        private DateTime _AllocationDate;
        public DateTime AllocationDate
        {
            get { return _AllocationDate; }
            set { _AllocationDate = value; }
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
        private Int32 _AllocationQty;
        public Int32 AllocationQty
        {
            get { return _AllocationQty; }
            set { _AllocationQty = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _AllocationID, _ReservationTypeID, _AllocationDate, _StartTime, _EndTime, _AllocationQty };
                this.SpName = "[Reservation].[spSaveAllocateReservation]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _AllocationID, _ReservationTypeID, _AllocationDate, _StartTime, _EndTime, _AllocationQty };
                this.SpName = "[Reservation].[spUpdateAllocateReservation]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _AllocationID };
                this.SpName = "[Reservation].[spUpdateAllocateReservation]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ReservationAllocationModel
            {
                _AllocationID = reader.GetInt64("AllocationID"),
                _ReservationTypeID = reader.GetInt64("ReservationTypeID"),
                _AllocationDate = reader.GetDateTime("AllocationDate"),
                _StartTime = reader.GetToString("StartTime"),
                _EndTime = reader.GetToString("EndTime"),
                _AllocationQty = reader.GetInt32("AllocationQty"),
            };
        }
    }
}
