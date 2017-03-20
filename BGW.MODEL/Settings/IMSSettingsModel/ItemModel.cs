using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsModel
{
    public class ItemModel:BaseClass
    {


        private Int64? _ItemID;
        public Int64? ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        private Int64 _ItemGroupID;
        [Required(ErrorMessage="Item Group Id is required")]
        [Browsable(true),DisplayName("Item Group")]
        //[MinLength(1)]
        //[Compare("Required",ErrorMessage="Item Group is required")]
        public Int64 ItemGroupID
        {
            get { return _ItemGroupID; }
            set { _ItemGroupID = value; }
        }
        private string _ItemName;
        [Required(ErrorMessage = "Item Name is required")]
        [Browsable(true), DisplayName("Item Name")]
        [MaxLength(50),MinLength(3)]
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        private string _ItemDescription;
        
        [Browsable(true), DisplayName("Description")]
        [MaxLength(500),MinLength(0)]
        [DataType(DataType.MultilineText)]
        public string ItemDescription
        {
            get { return _ItemDescription; }
            set { _ItemDescription = value; }
        }
        private Decimal _Weight;
        [Required(ErrorMessage = "Weight(gm) is required")]
        
        [Browsable(true), DisplayName("Weight(gm)")]
        
        public Decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private Int32 _PerCartunQty;
        [Required(ErrorMessage = "PC-Qty is required")]
        [Browsable(true), DisplayName("PC-Qty")]
        public Int32 PerCartunQty
        {
            get { return _PerCartunQty; }
            set { _PerCartunQty = value; }
        }

        private string _ItemGroupName;
        public string ItemGroupName
        {
            get { return _ItemGroupName; }
            
        }

        private Int32 _ProductionRatePerMin;
        [Required(ErrorMessage = "Prod-Rate(min) is required")]
        [Browsable(true), DisplayName("Prod-Rate(min)")]
        public Int32 ProductionRatePerMin
        {
            get { return _ProductionRatePerMin; }
            set { _ProductionRatePerMin = value; }
        }

        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ItemID, _ItemGroupID, _ItemName, _ItemDescription, _Weight, _PerCartunQty, _ProductionRatePerMin };
                this.SpName = "[dbo].[spSavetblItem]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ItemID, _ItemGroupID, _ItemName, _ItemDescription, _Weight, _PerCartunQty, _ProductionRatePerMin };
                this.SpName = "[dbo].[spUpdatetblItem]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ItemID };
                this.SpName = "[dbo].[spUpdatetblItem]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ItemModel
            {
                _ItemID = reader.GetInt64("ItemID"),
                _ItemGroupID = reader.GetInt64("ItemGroupID"),
                _ItemName = reader.GetToString("ItemName"),
                _ItemDescription = reader.GetToString("ItemDescription"),
                _Weight = reader.GetDecimal("Weight"),
                _PerCartunQty = reader.GetInt32("PerCartunQty"),
                _ItemGroupName = reader.GetToString("ItemGroupName"),
                _ProductionRatePerMin = reader.GetInt32("ProductionRatePerMin")
            };
        }
    }
}
