using BGW.MODEL.Report;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Report
{
    public class ReportManager
    {
        #region Object Initialization
        private readonly DBManager _objmanager = new DBManager();
        private readonly ReportModuleModel reportModule = new ReportModuleModel();
        private readonly ReportMenuModel reportMenu = new ReportMenuModel();
        private readonly ReportChildModel reportChild = new ReportChildModel();
        #endregion

        #region Save Data
        public void SaveReport(List<ReportMenuModel> rptMenuList, List<ReportChildModel> rptParamList)
        {
            try
            {
                foreach(ReportMenuModel rptMenuModel in rptMenuList)
                {
                    if (rptMenuModel.ReportID == null)
                        rptMenuModel.ReportID = _objmanager.KeyForReport("ReportMenu");
                }
                foreach (ReportChildModel rptChildModel in rptParamList)
                {
                    if (rptChildModel.ParmID == null)
                    {
                        rptChildModel.ParmID = _objmanager.KeyForReport("ReportChild");
                        rptChildModel.ReportID = rptMenuList[0].ReportID;
                    }
                        
                }
                _objmanager.SaveCollection(rptMenuList, rptParamList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Data
        public List<ReportModuleModel> ReportModuleList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(reportModule, "SELECT * FROM ReportModule");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<ReportMenuModel> ReportMenuList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(reportMenu, "SELECT * FROM ReportMenu");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ReportMenuModel ReportMenuByReportID(Int32 ReportID)
        {
            try
            {
                return _objmanager.SingleCollection(reportMenu, string.Format("SELECT * FROM ReportMenu WHERE ReportID={0}",ReportID));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<ReportChildModel> ReportParamByReportID(Int32 ReportID)
        {
            try
            {
                return _objmanager.GetDefaultCollection(reportChild, string.Format("SELECT * FROM ReportChild WHERE ReportID={0}", ReportID));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Combo box
        public object VCboReportModule()
        {
            try
            {
                return _objmanager.PopulateComboBox("SELECT * FROM ReportModule", "ModuleID", "ModuleName", "-Select Module-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public object VCboReportMenu(Int32 ModuleID)
        {
            try
            {
                return _objmanager.PopulateComboBox(string.Format("SELECT * FROM ReportMenu WHERE IsParent =1 AND ModuleID={0}", ModuleID), "ReportID", "DisplayName", "-Select Parent-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Report Parameter Table
        public string HtmlTable(string sql)
        {
            DataSet ds = new DataSet();
            _objmanager.GetDataSet(sql, ref ds);
            string table = "<table class='table' id='tableData' style='border: 1px #DDD solid;'>";            
            string thead = "<thead>";            
            string tbody = "<tboby>";

            string trH = "";
            string tdH = "";
            string tr = "";
            string td = "";

            trH += "<tr>";
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                tdH += "<th>" + ds.Tables[0].Columns[i].ColumnName + "</th>";
            }
            trH += tdH;
            trH += "</tr>";
            thead += trH;
            thead += "</thead>";

            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                tr += "<tr>";
                td = "";
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    td += "<td class='td'>";
                    td += ds.Tables[0].Rows[i][j].ToString();
                    td += "</td>";
                    
                }
                tr += td;
                tr += "</tr>";
                
            }
            tbody += tr;
            tbody += "</tbody>";

            table += thead;
            table += tbody;
            table += "</table>";
            return table;
        }
        #endregion

    }
}
