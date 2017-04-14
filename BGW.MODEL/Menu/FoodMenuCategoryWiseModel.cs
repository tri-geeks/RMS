
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Menu
{
   public class FoodMenuCategoryWiseModel :BaseClass
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

        #region  Dashboard Six Menu Details
        private string _menuNameLeft;
        public string MenuNameLeft
        {
            get { return _menuNameLeft; }
            set { _menuNameLeft = value; }
        }
        private string _menuDetailsLeft;
        public string MenuDetailsLeft
        {
            get { return _menuDetailsLeft; }
            set { _menuDetailsLeft = value; }
        }
        private string _virtualPathLeft;
        public string VirtualPathLeft
        {
            get { return _virtualPathLeft; }
            set { _virtualPathLeft = value; }
        }
        private string _actualPathLeft;
        public string ActualPathLeft
        {
            get { return _actualPathLeft; }
            set { _actualPathLeft = value; }
        }
        private string _priceLeft;
        public string PriceLeft
        {
            get { return _priceLeft; }
            set { _priceLeft = value; }
        }
        private string _menuNameRight;
        public string MenuNameRight
        {
            get { return _menuNameRight; }
            set { _menuNameRight = value; }
        }
        private string _menuDetailsRight;
        public string MenuDetailsRight
        {
            get { return _menuDetailsRight; }
            set { _menuDetailsRight = value; }
        }
        private string _virtualPathRight;
        public string VirtualPathRight
        {
            get { return _virtualPathRight; }
            set { _virtualPathRight = value; }
        }
        private string _actualPathRight;
        public string ActualPathRight
        {
            get { return _actualPathRight; }
            set { _actualPathRight = value; }
        }
        private string _priceRight;
        public string PriceRight
        {
            get { return _priceRight; }
            set { _priceRight = value; }
        }

        private string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
       
        #endregion




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
            return new FoodMenuCategoryWiseModel
            {
                _SubCategoryID = reader.GetInt64("SubCategoryID"),
                _CategoryID = reader.GetInt64("CategoryID"),
                _SubCategoryName = reader.GetToString("SubCategoryName"),
                _SubCategoryDetails = reader.GetToString("SubCategoryDetails"),
            };
        }

        public object MapParameter_2(IDataReader reader)
        {
            return new FoodMenuCategoryWiseModel
            {
                

                _SubCategoryID = reader.GetInt64("SubCategoryID"),
                _CategoryID = reader.GetInt64("CategoryID"),
                _SubCategoryName = reader.GetToString("SubCategoryName"),               
                 _CategoryName = reader.GetToString("CategoryName")
            };
        }

        public object MapParameter_1(IDataReader reader)
        {
            return new FoodMenuCategoryWiseModel
            {
                _menuNameLeft = reader.GetToString("MenuNameLeft"),
                _menuDetailsLeft = reader.GetToString("MenuDetailsLeft"),
                _virtualPathLeft = reader.GetToString("VirtualPathLeft"),
                _actualPathLeft = reader.GetToString("ActualPathLeft"),
                _priceLeft = reader.GetToString("PriceLeft"),
                _menuNameRight = reader.GetToString("MenuNameRight"),
                _menuDetailsRight = reader.GetToString("MenuDetailsRight"),
                _virtualPathRight = reader.GetToString("VirtualPathRight"),
                _actualPathRight = reader.GetToString("ActualPathRight"),
                _priceRight = reader.GetToString("PriceRight"),
            };
        }

        public object MapParameter_3(IDataReader reader)
        {
            return new FoodMenuCategoryWiseModel
            {              
                _menuNameLeft = reader.GetToString("MenuName"),
                _menuDetailsLeft = reader.GetToString("MenuDetails"),
                _virtualPathLeft = reader.GetToString("VirtualPath"),
                _actualPathLeft = reader.GetToString("ActualPath"),
                _priceLeft = reader.GetToString("Price")
            };
        }
    }
}
