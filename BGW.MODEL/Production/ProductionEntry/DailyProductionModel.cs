using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Production.ProductionEntry
{
    public class DailyProductionModel : BaseClass
    {

        #region Properties
        private Int64? _ProductionID;
        public Int64? ProductionID
        {
            get { return _ProductionID; }
            set { _ProductionID = value; }
        }
        private Int64? _ProductionMasterID;
        public Int64? ProductionMasterID
        {
            get { return _ProductionMasterID; }
            set { _ProductionMasterID = value; }
        }
        
        private DateTime _ProductionDate;
        [Required(ErrorMessage = "Production Date is required")]
        [Browsable(true), DisplayName("Production Date")]
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        private Int64 _ItemID;
        [Required(ErrorMessage = "Item Id is required")]
        [Browsable(true), DisplayName("Item Id")]
        public Int64 ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        private Int64 _FurID;        
        [Browsable(true), DisplayName("Furnace")]
        public Int64 FurID
        {
            get { return _FurID; }
            set { _FurID = value; }
        }
        private Int64 _StationID;
        [Browsable(true), DisplayName("StationID")]
        public Int64 StationID
        {
            get { return _StationID; }
            set { _StationID = value; }
        }
        private Int64 _Section;
        [Browsable(true), DisplayName("Section")]
        public Int64 Section
        {
            get { return _Section; }
            set { _Section = value; }
        }
        private Int64 _ShiftID;
        [Required(ErrorMessage = "ShiftID is required")]
        [Browsable(true), DisplayName("Shift Id")]
        public Int64 ShiftID
        {
            get { return _ShiftID; }
            set { _ShiftID = value; }
        }
        private Decimal _EfficiencyRate;
        [Required(ErrorMessage = "EfficiencyRate is required")]
        [Browsable(true), DisplayName("Efficiency Rate")]
        public Decimal EfficiencyRate
        {
            get { return _EfficiencyRate; }
            set { _EfficiencyRate = value; }
        }
        private Decimal _Efficiency;
        [Required(ErrorMessage = "Efficiency is required")]
        [Browsable(true), DisplayName("Efficiency")]
        public Decimal Efficiency
        {
            get { return _Efficiency; }
            set { _Efficiency = value; }
        }
        private Int32 _PicesPerCartun;
        [Required(ErrorMessage = "PicesPerCartun is required")]
        [Browsable(true), DisplayName("PicesPer Cartun")]
        public Int32 PicesPerCartun
        {
            get { return _PicesPerCartun; }
            set { _PicesPerCartun = value; }
        }
        private Int32 _TotalCartun;
        [Required(ErrorMessage = "TotalCartun is required")]
        [Browsable(true), DisplayName("Total Cartun")]
        public Int32 TotalCartun
        {
            get { return _TotalCartun; }
            set { _TotalCartun = value; }
        }
        private Int32 _TotalPices;
        [Required(ErrorMessage = "Total Pices is required")]
        [Browsable(true), DisplayName("Total Pices")]
        public Int32 TotalPices
        {
            get { return _TotalPices; }
            set { _TotalPices = value; }
        }
        private Decimal _UnitWeightGM;
        [Required(ErrorMessage = "UnitWeightGM is required")]
        [Browsable(true), DisplayName("UnitWeightGM")]
        public Decimal UnitWeightGM
        {
            get { return _UnitWeightGM; }
            set { _UnitWeightGM = value; }
        }
        private Decimal _TotalWeightKG;
        [Required(ErrorMessage = "TotalWeightKG is required")]
        [Browsable(true), DisplayName("TotalWeightKG")]
        public Decimal TotalWeightKG
        {
            get { return _TotalWeightKG; }
            set { _TotalWeightKG = value; }
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

        #endregion

        #region Set Parameter
        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ProductionID, _ProductionMasterID, _ProductionDate, _ItemID, _FurID, _StationID, _Section, _ShiftID, _EfficiencyRate, _Efficiency, _PicesPerCartun, _TotalCartun, _TotalPices, _UnitWeightGM, _TotalWeightKG, _AddedBy, _DateAdded};
                this.SpName = "[dbo].[spSaveDayWiseProduction]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ProductionID, _ProductionMasterID, _ProductionDate, _ItemID, _FurID, _StationID, _Section, _ShiftID, _EfficiencyRate, _Efficiency, _PicesPerCartun, _TotalCartun, _TotalPices, _UnitWeightGM, _TotalWeightKG,_UpdatedBy, _UpdatedDate };
                this.SpName = "[dbo].[spUpdateDayWiseProduction]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ProductionID };
                this.SpName = "[dbo].[spUpdateDayWiseProduction]";
            }
            return arr;
        }

        #endregion

        #region Parameter Mapping
        public override object MapParameter(IDataReader reader)
        {
            return new DailyProductionModel
            {
                _ProductionID = reader.GetInt64("ProductionID"),
                _ProductionMasterID = reader.GetInt64("ProductionMasterID"),
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _ItemID = reader.GetInt64("ItemID"),
                _FurID = reader.GetInt64("FurID"),
                _StationID = reader.GetInt64("StationID"),
                _Section = reader.GetInt64("Section"),
                _ShiftID = reader.GetInt64("ShiftID"),
                _EfficiencyRate = reader.GetDecimal("EfficiencyRate"),
                _Efficiency = reader.GetDecimal("Efficiency"),
                _PicesPerCartun = reader.GetInt32("PicesPerCartun"),
                _TotalCartun = reader.GetInt32("TotalCartun"),
                _TotalPices = reader.GetInt32("TotalPices"),
                _UnitWeightGM = reader.GetDecimal("UnitWeightGM"),
                _TotalWeightKG = reader.GetDecimal("TotalWeightKG"),
                _AddedBy = reader.GetInt64("AddedBy"),
                _DateAdded = reader.GetDateTime("DateAdded"),
                _UpdatedBy = reader.GetInt64("UpdatedBy"),
                _UpdatedDate = reader.GetDateTime("UpdatedDate"),
            };
        }
        #endregion
    }
}
