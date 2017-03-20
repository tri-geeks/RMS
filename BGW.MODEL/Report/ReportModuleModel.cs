using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Report
{
    public class ReportModuleModel:BaseClass
    {


        private Int32 _ModuleID;
        public Int32 ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }
        private string _ModuleName;
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }
        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        private bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ModuleID, _ModuleName, _DisplayName, _IsVisible };
                this.SpName = "[dbo].[spSaveReportModule]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ModuleID, _ModuleName, _DisplayName, _IsVisible };
                this.SpName = "[dbo].[spUpdateReportModule]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ModuleID };
                this.SpName = "[dbo].[spUpdateReportModule]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ReportModuleModel
            {
                _ModuleID = reader.GetInt32("ModuleID"),
                _ModuleName = reader.GetToString("ModuleName"),
                _DisplayName = reader.GetToString("DisplayName"),
                _IsVisible = reader.GetBoolean("IsVisible"),
            };
        }
    }
}
