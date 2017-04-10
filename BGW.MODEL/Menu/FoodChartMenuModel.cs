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
    }
}
