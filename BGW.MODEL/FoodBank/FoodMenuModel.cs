using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.FoodBank
{
    public class FoodMenuModel:BaseClass
    {


        private Int64 _MID;
        public Int64 MID
        {
            get { return _MID; }
            set { _MID = value; }
        }
        private Int64 _MCID;
        public Int64 MCID
        {
            get { return _MCID; }
            set { _MCID = value; }
        }
        private string _MName;
        public string MName
        {
            get { return _MName; }
            set { _MName = value; }
        }
        private string _MDetails;
        public string MDetails
        {
            get { return _MDetails; }
            set { _MDetails = value; }
        }
        private string _MIMG;
        public string MIMG
        {
            get { return _MIMG; }
            set { _MIMG = value; }
        }
        private string _MIMGPathAc;
        public string MIMGPathAc
        {
            get { return _MIMGPathAc; }
            set { _MIMGPathAc = value; }
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



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _MID, _MCID, _MName, _MDetails, _MIMG, _MIMGPathAc, _Currency, _Price, _IsAbout, _IsGallary };
                this.SpName = "[Masterdata].[spSaveMenu]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _MID, _MCID, _MName, _MDetails, _MIMG, _MIMGPathAc, _Currency, _Price, _IsAbout, _IsGallary };
                this.SpName = "[Masterdata].[spUpdateMenu]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _MID };
                this.SpName = "[Masterdata].[spUpdateMenu]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new FoodMenuModel
            {
                _MID = reader.GetInt64("MID"),
                _MCID = reader.GetInt64("MCID"),
                _MName = reader.GetToString("MName"),
                _MDetails = reader.GetToString("MDetails"),
                _MIMG = reader.GetToString("MIMG"),
                _MIMGPathAc = reader.GetToString("MIMGPathAc"),
                _Currency = reader.GetToString("Currency"),
                _Price = reader.GetDecimal("Price"),
                _IsAbout = reader.GetBoolean("IsAbout"),
                _IsGallary = reader.GetBoolean("IsGallary"),
            };
        }
    }
}
