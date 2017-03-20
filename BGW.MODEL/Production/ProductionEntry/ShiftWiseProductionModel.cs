using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Production.ProductionEntry
{
    public class ShiftWiseProductionModel:BaseClass
    {


        private Int64? _SWPID;
        public Int64? SWPID
        {
            get { return _SWPID; }
            set { _SWPID = value; }
        }
        private DateTime _ProductionDate;
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        private Int64 _FurnaceID;
        public Int64 FurnaceID
        {
            get { return _FurnaceID; }
            set { _FurnaceID = value; }
        }
        private Int64 _StationID;
        public Int64 StationID
        {
            get { return _StationID; }
            set { _StationID = value; }
        }
        private Int32 _Section;
        public Int32 Section
        {
            get { return _Section; }
            set { _Section = value; }
        }
        private Int64 _ShiftID;
        public Int64 ShiftID
        {
            get { return _ShiftID; }
            set { _ShiftID = value; }
        }
        private Int64 _ItemID;
        public Int64 ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        private Int32 _BPM;
        public Int32 BPM
        {
            get { return _BPM; }
            set { _BPM = value; }
        }
        private Decimal _UnitWeightGM;
        public Decimal UnitWeightGM
        {
            get { return _UnitWeightGM; }
            set { _UnitWeightGM = value; }
        }
        private Int32 _QuantityPCS;
        public Int32 QuantityPCS
        {
            get { return _QuantityPCS; }
            set { _QuantityPCS = value; }
        }
        private Decimal _QuantityKG;
        public Decimal QuantityKG
        {
            get { return _QuantityKG; }
            set { _QuantityKG = value; }
        }
        private Int32 _ProductionMIN;
        public Int32 ProductionMIN
        {
            get { return _ProductionMIN; }
            set { _ProductionMIN = value; }
        }
        private Int32? _ProductionLossMIN;
        public Int32? ProductionLossMIN
        {
            get { return _ProductionLossMIN; }
            set { _ProductionLossMIN = value; }
        }
        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        private Int64? _AddedBy;
        public Int64? AddedBy
        {
            get { return _AddedBy; }
            set { _AddedBy = value; }
        }
        private DateTime? _AddedDate;
        public DateTime? AddedDate
        {
            get { return _AddedDate; }
            set { _AddedDate = value; }
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

        private Decimal _Efficiency;
        public Decimal Efficiency
        {
            get { return _Efficiency; }
            set { _Efficiency = value; }
        }
        

        //----------------------------------

        private string _ShiftName;
        public string ShiftName
        {
            get { return _ShiftName; }
            set { _ShiftName = value; }
        }

        private string _FurName;
        public string FurName
        {
            get { return _FurName; }
            set { _FurName = value; }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private string _StationName;
        public string StationName
        {
            get { return _StationName; }
            set { _StationName = value; }
        }
//        SP.Section,SP.UnitWeightGM,
//SP.QuantityPCS,SP.QuantityKG,SP.ProductionMIN,SP.Efficiency,SP.ProductionLossMIN,SP.Comment


        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _SWPID, _ProductionDate, _FurnaceID, _StationID, _Section, _ShiftID, _ItemID, _BPM, _UnitWeightGM, _QuantityPCS, _QuantityKG, _ProductionMIN, _ProductionLossMIN, _Comment, _AddedBy, _AddedDate, _UpdatedBy, _UpdatedDate, _Efficiency };
                this.SpName = "[dbo].[spSaveShiftWiseProduction]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _SWPID, _ProductionDate, _FurnaceID, _StationID, _Section, _ShiftID, _ItemID, _BPM, _UnitWeightGM, _QuantityPCS, _QuantityKG, _ProductionMIN, _ProductionLossMIN, _Comment, _AddedBy, _AddedDate, _UpdatedBy, _UpdatedDate, _Efficiency };
                this.SpName = "[dbo].[spUpdateShiftWiseProduction]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _SWPID };
                this.SpName = "[dbo].[spUpdateShiftWiseProduction]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ShiftWiseProductionModel
            {
                _SWPID = reader.GetInt64("SWPID"),
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _FurnaceID = reader.GetInt64("FurnaceID"),
                _StationID = reader.GetInt64("StationID"),
                _Section = reader.GetInt32("Section"),
                _ShiftID = reader.GetInt64("ShiftID"),
                _ItemID = reader.GetInt64("ItemID"),
                _BPM = reader.GetInt32("BPM"),
                _UnitWeightGM = reader.GetDecimal("UnitWeightGM"),
                _QuantityPCS = reader.GetInt32("QuantityPCS"),
                _QuantityKG = reader.GetDecimal("QuantityKG"),
                _ProductionMIN = reader.GetInt32("ProductionMIN"),
                _ProductionLossMIN = reader.GetInt32("ProductionLossMIN"),
                _Comment = reader.GetToString("Comment"),
                _AddedBy = reader.GetInt64("AddedBy"),
                _AddedDate = reader.GetDateTime("AddedDate"),
                _UpdatedBy = reader.GetInt64("UpdatedBy"),
                _UpdatedDate = reader.GetDateTime("UpdatedDate"),
                _Efficiency = reader.GetDecimal("Efficiency")
            };
        }


        public object MapParameter_1(IDataReader reader)
        {
            return new ShiftWiseProductionModel
            {
                _SWPID = reader.GetInt64("SWPID"),
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _FurName = reader.GetToString("FurName"),          
                _ShiftName = reader.GetToString("ShiftName"),
                _ItemName = reader.GetToString("ItemName"),
                _QuantityPCS = reader.GetInt32("QuantityPCS"),
                _QuantityKG = reader.GetDecimal("QuantityKG")
                
            };
        }


        public object MapParameter_2(IDataReader reader)
        {
            return new ShiftWiseProductionModel
            {
                _SWPID = reader.GetInt64("SWPID"),
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _FurName = reader.GetToString("FurName"),
                _Section = reader.GetInt32("Section"),
                _ShiftName = reader.GetToString("ShiftName"),
                _ItemName = reader.GetToString("ItemName"),
                _QuantityPCS = reader.GetInt32("QuantityPCS"),
                _QuantityKG = reader.GetDecimal("QuantityKG"),
                _ProductionMIN = reader.GetInt32("ProductionMIN"),
                _ProductionLossMIN = reader.GetInt32("ProductionLossMIN"),
                _Efficiency = reader.GetDecimal("Efficiency"),
                _StationName = reader.GetToString("StationName"),
                _UnitWeightGM = reader.GetDecimal("UnitWeightGM"),
                _BPM = reader.GetInt32("BPM")

            };
        }
    }
}
//SP.SWPID,ProductionDate,SF.ShiftName,F.FurName,ST.StationName,SP.Section,SP.UnitWeightGM,
//SP.QuantityPCS,SP.QuantityKG,SP.ProductionMIN,SP.Efficiency,SP.ProductionLossMIN,SP.Comment