using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Production.ProductionEntry
{
    public class ShiftWiseProductionQualityModel:BaseClass
    {


        private Int64? _SWPQID;
        public Int64? SWPQID
        {
            get { return _SWPQID; }
            set { _SWPQID = value; }
        }
        private Int64 _QualityID;
        public Int64 QualityID
        {
            get { return _QualityID; }
            set { _QualityID = value; }
        }
        private Decimal _Quantity;
        public Decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        private Int64? _SWPID;
        public Int64? SWPID
        {
            get { return _SWPID; }
            set { _SWPID = value; }
        }
        private Int64? _AddedBy;
        public Int64? AddedBy
        {
            get { return _AddedBy; }
            set { _AddedBy = value; }
        }
        private DateTime? _DateAdded;
        public DateTime? DateAdded
        {
            get { return _DateAdded; }
            set { _DateAdded = value; }
        }
        private Int64? _UpdatedBy;
        public Int64? UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        private DateTime? _UpdatedDate;
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        //***********************************
        //Q.QualityName,SQ.Quantity
        private string _QualityName;
        public string QualityName
        {
            get { return _QualityName; }
            set { _QualityName = value; }
        }

        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _SWPQID, _QualityID, _Quantity, _SWPID, _AddedBy, _DateAdded, _UpdatedBy, _UpdatedDate };
                this.SpName = "[dbo].[spSaveShiftWiseProductionQuality]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _SWPQID, _QualityID, _Quantity, _SWPID, _AddedBy, _DateAdded, _UpdatedBy, _UpdatedDate };
                this.SpName = "[dbo].[spUpdateShiftWiseProductionQuality]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _SWPQID };
                this.SpName = "[dbo].[spUpdateShiftWiseProductionQuality]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ShiftWiseProductionQualityModel
            {
                _SWPQID = reader.GetInt64("SWPQID"),
                _QualityID = reader.GetInt64("QualityID"),
                _Quantity = reader.GetDecimal("Quantity"),
                _SWPID = reader.GetInt64("SWPID"),
                _AddedBy = reader.GetInt64("AddedBy"),
                _DateAdded = reader.GetDateTime("DateAdded"),
                _UpdatedBy = reader.GetInt64("UpdatedBy"),
                _UpdatedDate = reader.GetDateTime("UpdatedDate"),
            };
        }

        public object MapParameter_1(IDataReader reader)
        {
            return new ShiftWiseProductionQualityModel
            {
                _SWPQID = reader.GetInt64("SWPQID"),
                _QualityName = reader.GetToString("QualityName"),
                _Quantity = reader.GetDecimal("Quantity")
                
            };
        }
    }
}
