using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.FoodMenuCategoryWiseManager
{
    public class FoodMenuCategoryWise
    {


        private Int64 _SubCategoryID;
        public Int64 SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID = value; }
        }
        private Int64 _CategoryID;
        public Int64 CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        private string _SubCategoryName;
        public string SubCategoryName
        {
            get { return _SubCategoryName; }
            set { _SubCategoryName = value; }
        }
        private string _SubCategoryDetails;
        public string SubCategoryDetails
        {
            get { return _SubCategoryDetails; }
            set { _SubCategoryDetails = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _SubCategoryID, _CategoryID, _SubCategoryName, _SubCategoryDetails };
                this.SpName = "[Settings].[spSaveMenuSubCategory]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _SubCategoryID, _CategoryID, _SubCategoryName, _SubCategoryDetails };
                this.SpName = "[Settings].[spUpdateMenuSubCategory]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _SubCategoryID };
                this.SpName = "[Settings].[spUpdateMenuSubCategory]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new Demo
            {
                _SubCategoryID = reader.GetInt64("SubCategoryID"),
                _CategoryID = reader.GetInt64("CategoryID"),
                _SubCategoryName = reader.GetToString("SubCategoryName"),
                _SubCategoryDetails = reader.GetToString("SubCategoryDetails"),
            };
        }
    }
}
