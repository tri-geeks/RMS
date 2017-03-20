using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Report
{
    public class ReportChildModel:BaseClass
    {


        private Int32? _ParmID;
        public Int32? ParmID
        {
            get { return _ParmID; }
            set { _ParmID = value; }
        }
        private Int32? _ReportID;
        public Int32? ReportID
        {
            get { return _ReportID; }
            set { _ReportID = value; }
        }
        private string _ParmName;
        public string ParmName
        {
            get { return _ParmName; }
            set { _ParmName = value; }
        }
        private string _QueryString;
        public string QueryString
        {
            get { return _QueryString; }
            set { _QueryString = value; }
        }
        private string _ParmVal;
        public string ParmVal
        {
            get { return _ParmVal; }
            set { _ParmVal = value; }
        }




        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ParmID, _ReportID, _ParmName, _QueryString };
                this.SpName = "[dbo].[spSaveReportChild]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ParmID, _ReportID, _ParmName, _QueryString };
                this.SpName = "[dbo].[spUpdateReportChild]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ParmID };
                this.SpName = "[dbo].[spUpdateReportChild]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ReportChildModel
            {
                _ParmID = reader.GetInt32("ParmID"),
                _ReportID = reader.GetInt32("ReportID"),
                _ParmName = reader.GetToString("ParmName"),
                _QueryString = reader.GetToString("QueryString"),
            };
        }
    }
}
