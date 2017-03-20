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
    public class DailyProductionMasterModel:BaseClass
    {

        #region Properties
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

        private Int64 _FurID;
        [Required(ErrorMessage = "Furnace Name is required")]
        [Browsable(true), DisplayName("Furnace")]        
        public Int64 FurID
        {
            get { return _FurID; }
            set { _FurID = value; }
        }
        private Int64 _ItemID;
        [Required(ErrorMessage = "Item Name is required")]
        [Browsable(true), DisplayName("Item Name")]  
        public Int64 ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        private Int64 _StationID;
        [Required(ErrorMessage = "Station is required")]
        [Browsable(true), DisplayName("Station")]  
        public Int64 StationID
        {
            get { return _StationID; }
            set { _StationID = value; }
        }
       
        private Decimal? _LossMin=0.0m;
        public Decimal? LossMin
        {
            get { return _LossMin; }
            set { _LossMin = value; }
        }
        private Int32 _TotalPices;
        public Int32 TotalPices
        {
            get { return _TotalPices; }
            set { _TotalPices = value; }
        }
        private Decimal _TotalKG;
        public Decimal TotalKG
        {
            get { return _TotalKG; }
            set { _TotalKG = value; }
        }
        private Decimal _TotalEfficiency;
        public Decimal TotalEfficiency
        {
            get { return _TotalEfficiency; }
            set { _TotalEfficiency = value; }
        }        
        
        private string _Remark=null;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
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


        private bool? _IsApproved;
        public bool? IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        private Int64? _ApprovedBy;
        public Int64? ApprovedBy
        {
            get { return _ApprovedBy; }
            set { _ApprovedBy = value; }
        } 

        //F.FurName,ST.StationName,I.ItemName
        //**********--Optional--******************
        private string _FurName;
        public string FurName
        {
            get { return _FurName; }
        }

        private string _StationName;
        public string StationName
        {
            get { return _StationName; }
        }
        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
        }
        #endregion
        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ProductionMasterID, _ProductionDate, _FurID, _ItemID, _StationID,_LossMin, _TotalPices, _TotalKG, _TotalEfficiency,_Remark,_AddedBy,_AddedDate };
                this.SpName = "[dbo].[spSaveDayWiseProductionMaster]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ProductionMasterID, _ProductionDate, _FurID, _ItemID, _StationID,_LossMin, _TotalPices, _TotalKG, _TotalEfficiency,_Remark,_UpdatedBy,_UpdatedDate };
                this.SpName = "[dbo].[spUpdateDayWiseProductionMaster]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ProductionMasterID };
                this.SpName = "[dbo].[spUpdateDayWiseProductionMaster]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new DailyProductionMasterModel
            {
                _ProductionMasterID = reader.GetInt64("ProductionMasterID"),
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _FurID = reader.GetInt64("FurID"),
                _ItemID = reader.GetInt64("ItemID"),
                _StationID = reader.GetInt64("StationID"),                
                _LossMin = reader.GetDecimal("LossMin"),
                _TotalPices = reader.GetInt32("TotalPices"),
                _TotalKG = reader.GetDecimal("TotalKG"),
                _TotalEfficiency = reader.GetDecimal("TotalEfficiency"),               
                _Remark = reader.GetToString("Remark"),
            };
        }

        public object MapParameter_1(IDataReader reader)
        {
            return new DailyProductionMasterModel
            {
                _ProductionMasterID = reader.GetInt64("ProductionMasterID"),
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _FurName = reader.GetToString("FurName"),
                _ItemName = reader.GetToString("ItemName"),
                _StationName = reader.GetToString("StationName"),                
                _TotalPices = reader.GetInt32("TotalPices"),
                _TotalKG = reader.GetDecimal("TotalKG"),
                _TotalEfficiency = reader.GetDecimal("TotalEfficiency")
                
            };
        }
    }
}
