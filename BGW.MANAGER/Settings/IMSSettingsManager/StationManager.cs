using BGW.MODEL.Settings.IMSSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsManager
{
    public class StationManager
    {
        DBManager _objmanager = new DBManager();
        StationModel stationmodel = new StationModel();

        #region Save Station
        public void SaveStation(List<StationModel> stationlist)
        {
            try
            {
                foreach (StationModel stationitem in stationlist)
                {
                    if (stationitem.StationID == null)
                        stationitem.StationID = _objmanager.PrimaryKey("Station");
                }
                _objmanager.SaveCollection(stationlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Station list
        public List<StationModel> GetStationList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(stationmodel, @"SELECT ST.*,F.FurName FROM tblStation ST
                                                                            LEFT JOIN tblFurnace F ON F.FurID=ST.FurID");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Combo box
        public object VCboStation(Int64 furnaceid)
        {
            try
            {
                return _objmanager.PopulateComboBox(string.Format(@"SELECT * FROM tblStation WHERE FurID={0}",furnaceid), "StationID", "StationName", "-Select Station-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
        
    }
}
