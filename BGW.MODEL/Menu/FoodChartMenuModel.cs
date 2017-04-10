using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Menu
{
    public class FoodChartMenuModel : BaseClass
    {


        private Int64 _MenuID;
        public Int64 MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }
        private Int64 _MenuCategoryID;
        public Int64 MenuCategoryID
        {
            get { return _MenuCategoryID; }
            set { _MenuCategoryID = value; }
        }
        private Int64 _Sub_Category;
        public Int64 Sub_Category
        {
            get { return _Sub_Category; }
            set { _Sub_Category = value; }
        }
        private string _MenuName;
        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }
        private string _MenuDetails;
        public string MenuDetails
        {
            get { return _MenuDetails; }
            set { _MenuDetails = value; }
        }
        private string _VirtualPath;
        public string VirtualPath
        {
            get { return _VirtualPath; }
            set { _VirtualPath = value; }
        }
        private string _ActualPath;
        public string ActualPath
        {
            get { return _ActualPath; }
            set { _ActualPath = value; }
        }
        private string _Currency;
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        private Decimal _Price;
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private bool _IsAbout;
        public bool IsAbout
        {
            get { return _IsAbout; }
            set { _IsAbout = value; }
        }
        private bool _IsGallary;
        public bool IsGallary
        {
            get { return _IsGallary; }
            set { _IsGallary = value; }
        }
        private string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        private string _SubCategoryName;
        public string SubCategoryName
        {
            get { return _SubCategoryName; }
            set { _SubCategoryName = value; }
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
        #endregion


        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _MenuID, _MenuCategoryID, _Sub_Category, _MenuName, _MenuDetails, _VirtualPath, _ActualPath, _Currency, _Price, _IsAbout, _IsGallary };
                this.SpName = "[Masterdata].[spSaveFoodChartMenu]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _MenuID, _MenuCategoryID, _Sub_Category, _MenuName, _MenuDetails, _VirtualPath, _ActualPath, _Currency, _Price, _IsAbout, _IsGallary };
                this.SpName = "[Masterdata].[spUpdateFoodCharMenu]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _MenuID };
                this.SpName = "[Masterdata].[spDeleteFoodCharMenu]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new FoodChartMenuModel
            {
                _MenuID = reader.GetInt64("MenuID"),
                _MenuCategoryID = reader.GetInt64("MenuCategoryID"),
                _Sub_Category = reader.GetInt64("Sub_Category"),
                _MenuName = reader.GetToString("MenuName"),
                _MenuDetails = reader.GetToString("MenuDetails"),
                _VirtualPath = reader.GetToString("VirtualPath"),
                _ActualPath = reader.GetToString("ActualPath"),
                _Currency = reader.GetToString("Currency"),
                _Price = reader.GetDecimal("Price"),
                _IsAbout = reader.GetBoolean("IsAbout"),
                _IsGallary = reader.GetBoolean("IsGallary"),

                _CategoryName = reader.GetToString("CategoryName"),
                _SubCategoryName = reader.GetToString("SubCategoryName"),
            };
        }

        public object MapParameter_1(IDataReader reader)
        {
            return new FoodChartMenuModel
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
    }
}
