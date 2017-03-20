using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Settings.IMSSettingsModel
{
    public class StationModel:BaseClass
    {


        private Int64? _StationID;
        [Browsable(true), DisplayName("Station Id")]
        public Int64? StationID
        {
            get { return _StationID; }
            set { _StationID = value; }
        }
        private Int64 _FurID;
        [Required(ErrorMessage = "Furnace Name is required")]
        [Browsable(true), DisplayName("Furnace Name")]
        //[MaxLength(50), MinLength(1)]
        public Int64 FurID
        {
            get { return _FurID; }
            set { _FurID = value; }
        }
        private string _StationName;
        [Required(ErrorMessage = "Station is required")]
        [Browsable(true), DisplayName("Station Name")]
        //[MaxLength(50), MinLength(1)]
        public string StationName
        {
            get { return _StationName; }
            set { _StationName = value; }
        }
        private string _StationDescription;
        [Browsable(true), DisplayName("Description")]
        public string StationDescription
        {
            get { return _StationDescription; }
            set { _StationDescription = value; }
        }

        private string _FurName;        
        public string FurName
        {
            get { return _FurName; }           
        }


        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _StationID, _FurID, _StationName, _StationDescription };
                this.SpName = "[dbo].[spSavetblStation]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _StationID, _FurID, _StationName, _StationDescription };
                this.SpName = "[dbo].[spUpdatetblStation]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _StationID };
                this.SpName = "[dbo].[spUpdatetblStation]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new StationModel
            {
                _StationID = reader.GetInt64("StationID"),
                _FurID = reader.GetInt64("FurID"),
                _StationName = reader.GetToString("StationName"),
                _StationDescription = reader.GetToString("StationDescription"),
                _FurName = reader.GetToString("FurName")
            };
        }
    }
}
