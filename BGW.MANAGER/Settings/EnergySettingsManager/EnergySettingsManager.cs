using BGW.MODEL.Settings.EnergyConsumtionModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.EnergySettingsManager
{
    public class EnergySettingsManager
    {
        #region Inotialization
        DBManager _objmanager = new DBManager();
        EnergyUnitModel energyUnitModel = new EnergyUnitModel();
        EnergySourceModel energySourceModel = new EnergySourceModel();
        #endregion

        #region Save Energy Unit
        public void SaveEU(List<EnergyUnitModel> eulist)
        {
            try
            {
                foreach (EnergyUnitModel euItem in eulist)
                {
                    if (euItem.PUID == null)
                        euItem.PUID = _objmanager.PrimaryKey("UOEnergy");
                }
                _objmanager.SaveCollection(eulist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Save Energy Source
        public void SaveES(List<EnergySourceModel> eslist)
        {
            try
            {
                foreach (EnergySourceModel esItem in eslist)
                {
                    if (esItem.ECSID == null)
                        esItem.ECSID = _objmanager.PrimaryKey("SOEnergy");
                }
                _objmanager.SaveCollection(eslist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get 
        public List<EnergyUnitModel> GetEnergyUnitList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(energyUnitModel, string.Format("SELECT * FROM EnergyCategory"));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EnergySourceModel> GetEnergySourceList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(energySourceModel, string.Format("SELECT * FROM EnergyConsumptionSource"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }

}
