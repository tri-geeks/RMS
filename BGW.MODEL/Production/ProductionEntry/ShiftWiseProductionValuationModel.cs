using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Production.ProductionEntry
{
    public class ShiftWiseProductionValuationModel:BaseClass
    {


        private DateTime _ProductionDate;
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        private Int64 _ShiftID;
        public Int64 ShiftID
        {
            get { return _ShiftID; }
            set { _ShiftID = value; }
        }
        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] {_ProductionDate, _ShiftID, _Comment };
                this.SpName = "[dbo].[spSaveShiftWiseProductionValuation]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ProductionDate, _ShiftID, _Comment };
                this.SpName = "[dbo].[spUpdateShiftWiseProductionValuation]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ProductionDate, _ShiftID };
                this.SpName = "[dbo].[spUpdateShiftWiseProductionValuation]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ShiftWiseProductionValuationModel
            {                
                _ProductionDate = reader.GetDateTime("ProductionDate"),
                _ShiftID = reader.GetInt64("ShiftID"),
                _Comment = reader.GetToString("Comment"),
            };
        }
    }
}
