using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Report
{
    public class ReportMenuModel:BaseClass
    {


        private Int32? _ReportID;
        public Int32? ReportID
        {
            get { return _ReportID; }
            set { _ReportID = value; }
        }
        private Int32 _ModuleID;
        public Int32 ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }
        private Int32 _ParentID;
        public Int32 ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        private string _MenuName;
        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }
        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        private string _ReportPath;
        public string ReportPath
        {
            get { return _ReportPath; }
            set { _ReportPath = value; }
        }
        private bool? _IsVisible;
        public bool? IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; }
        }
        private bool? _IsParent;
        public bool? IsParent
        {
            get { return _IsParent; }
            set { _IsParent = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ReportID, _ModuleID, _ParentID, _MenuName, _DisplayName, _ReportPath, _IsVisible, _IsParent };
                this.SpName = "[dbo].[spSaveReportMenu]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ReportID, _ModuleID, _ParentID, _MenuName, _DisplayName, _ReportPath, _IsVisible, _IsParent };
                this.SpName = "[dbo].[spUpdateReportMenu]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ReportID };
                this.SpName = "[dbo].[spUpdateReportMenu]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ReportMenuModel
            {
                _ReportID = reader.GetInt32("ReportID"),
                _ModuleID = reader.GetInt32("ModuleID"),
                _ParentID = reader.GetInt32("ParentID"),
                _MenuName = reader.GetToString("MenuName"),
                _DisplayName = reader.GetToString("DisplayName"),
                _ReportPath = reader.GetToString("ReportPath"),
                _IsVisible = reader.GetBoolean("IsVisible"),
                _IsParent = reader.GetBoolean("IsParent"),
            };
        }
    }
}
