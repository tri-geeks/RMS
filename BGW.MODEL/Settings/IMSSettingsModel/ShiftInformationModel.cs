using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsModel
{
    public class ShiftInformationModel:BaseClass
    {


        private Int64 _ShiftID;
        [DisplayName("Shift Id")]
        public Int64 ShiftID
        {
            get { return _ShiftID; }
            set { _ShiftID = value; }
        }

        private string _ShiftName;
        [DisplayName("Shift Name")]
        public string ShiftName
        {
            get { return _ShiftName; }
            set { _ShiftName = value; }
        }
        private string _ShiftDescription;
        [DisplayName("Description")]
        public string ShiftDescription
        {
            get { return _ShiftDescription; }
            set { _ShiftDescription = value; }
        }
        private Int32 _DurationMIN;
        [DisplayName("Duration")]
        public Int32 DurationMIN
        {
            get { return _DurationMIN; }
            set { _DurationMIN = value; }
        }
        

        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ShiftID, _ShiftName, _ShiftDescription, _DurationMIN };
                this.SpName = "[dbo].[spSavetblShiftInformation]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ShiftID, _ShiftName, _ShiftDescription, _DurationMIN };
                this.SpName = "[dbo].[spUpdatetblShiftInformation]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ShiftID };
                this.SpName = "[dbo].[spUpdatetblShiftInformation]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ShiftInformationModel
            {
                _ShiftID = reader.GetInt64("ShiftID"),
                _ShiftName = reader.GetToString("ShiftName"),
                _ShiftDescription = reader.GetToString("ShiftDescription"),
                _DurationMIN = reader.GetInt32("DurationMIN")
            };
        }

        
    }
}
