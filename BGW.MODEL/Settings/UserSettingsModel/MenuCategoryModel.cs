using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BGW.MODEL.Settings.UserSettingsModel
{
    public class MenuCategoryModel:BaseClass
    {


        private Int64 _MCID;
        public Int64 MCID
        {
            get { return _MCID; }
            set { _MCID = value; }
        }
        private string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        private string _Details;
        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _MCID, _CategoryName, _Details };
                this.SpName = "[Settings].[spSaveMenuCategory]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _MCID, _CategoryName, _Details };
                this.SpName = "[Settings].[spUpdateMenuCategory]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _MCID };
                this.SpName = "[Settings].[spUpdateMenuCategory]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new MenuCategoryModel
            {
                _MCID = reader.GetInt64("MCID"),
                _CategoryName = reader.GetToString("CategoryName"),
                _Details = reader.GetToString("Details"),
            };
        }
    }
}
