using BGW.MODEL.Production.ProductionEntry;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Production.DailyProductionManager
{
    public class DailyProductionManager
    {
        #region Inotialization
        DBManager _objmanager = new DBManager();
        DailyProductionMasterModel productionMasterModel = new DailyProductionMasterModel();
        DailyProductionModel productionModel = new DailyProductionModel();
        #endregion

        #region Save Daily Production
        public void SaveDailyProduction(List<DailyProductionMasterModel> pmasterlist, List<DailyProductionModel> plist)
        {
            try
            {
                foreach(DailyProductionMasterModel masteritem in pmasterlist)
                {
                    if (masteritem.ProductionMasterID == null)
                        masteritem.ProductionMasterID = _objmanager.PrimaryKey("ProductionMaster");
                }
                foreach(DailyProductionModel pitem in plist)
                {
                    if(pitem.ProductionID==null)
                    {
                        pitem.ProductionID = _objmanager.PrimaryKey("ProductionChield");
                        pitem.ProductionMasterID = pmasterlist[0].ProductionMasterID;
                    }
                }
                _objmanager.SaveCollection(pmasterlist, plist);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Daily Production Master List
        public List<DailyProductionMasterModel> GetProductionMasterList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(productionMasterModel, "MapParameter_1", "spGetProductionMasterData");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DailyProductionMasterModel GetProductionMaster(Int64 ProductionMasterID)
        {
            try
            {
                return _objmanager.SingleCollection(productionMasterModel, string.Format("SELECT * FROM DayWiseProductionMaster WHERE ProductionMasterID={0}",ProductionMasterID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DailyProductionModel> GetDailyProductionList(Int64 ProductionMasterID)
        {
            try
            {
                return _objmanager.GetDefaultCollection(productionModel, string.Format("SELECT * FROM DayWiseProduction WHERE ProductionMasterID={0}", ProductionMasterID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
