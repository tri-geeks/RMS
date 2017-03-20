using BGW.MODEL.Production.ProductionEntry;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Production.DailyProductionManager
{
    public class ShiftWiseProductionManager
    {
        #region Inotialization
        DBManager _objmanager = new DBManager();
        ShiftWiseProductionModel swprodModel = new ShiftWiseProductionModel();
        ShiftWiseProductionQualityModel swprodQModel = new ShiftWiseProductionQualityModel();
        ShiftWiseProductionValuationModel swpValuationModel = new ShiftWiseProductionValuationModel();
        #endregion

        #region Save Daily Production
        public void SaveSWProduction(List<ShiftWiseProductionModel> swprodlist, List<ShiftWiseProductionQualityModel> swprodQlist)
        {
            try
            {
                foreach (ShiftWiseProductionModel swproditem in swprodlist)
                {
                    if (swproditem.SWPID == null)
                        swproditem.SWPID = _objmanager.PrimaryKey("SWProduction");
                }
                foreach (ShiftWiseProductionQualityModel swprodQitem in swprodQlist)
                {
                    if (swprodQitem.SWPQID == null)
                    {
                        swprodQitem.SWPQID = _objmanager.PrimaryKey("SWProductionQ");
                        swprodQitem.SWPID = swprodlist[0].SWPID;
                    }
                }
                _objmanager.SaveCollection(swprodlist, swprodQlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Get Daily Production Master List
        public List<ShiftWiseProductionModel> GetSWProdList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(swprodModel, "MapParameter_1", "spSearchShiftWiseProduction");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ShiftWiseProductionModel GetSWProd(Int64 swpid)
        {
            try
            {
                return _objmanager.SingleCollection(swprodModel, string.Format("SELECT * FROM ShiftWiseProduction WHERE SWPID={0}", swpid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ShiftWiseProductionQualityModel> GetSWProdQList(Int64 swpid)
        {
            try
            {
                return _objmanager.GetDefaultCollection(swprodQModel, string.Format("SELECT  * FROM ShiftWiseProductionQuality WHERE SWPID={0}", swpid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Shift Wise Summary
        public List<ShiftWiseProductionModel> GetSWProdSummaryByDateAndShift(Int64 ShiftID,string prodDate)
        {
            try
            {
                return _objmanager.GetDefaultCollection(swprodModel, "MapParameter_2", string.Format("spGetShiftWiseProductionByShiftANDProductionDate {0},'{1}'", ShiftID, prodDate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<ShiftWiseProductionQualityModel> GetSWProdQListSummary(Int64 swpid)
        {
            try
            {
                return _objmanager.GetDefaultCollection(swprodQModel, "MapParameter_1", string.Format("spGetQualityByProductionID {0}", swpid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ShiftWiseProductionValuationModel GetSWPValuation(Int64 ShiftID,DateTime ProdDate)
        {
            try
            {
                return _objmanager.SingleCollection(swpValuationModel, string.Format("SELECT * FROM  [dbo].[ShiftWiseProductionValuation] WHERE ProductionDate='{0}' AND ShiftID={1}", ProdDate, ShiftID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveShiftWiseProdValuation(List<ShiftWiseProductionValuationModel> swpVList)
        {
            try
            {                
                _objmanager.SaveCollection(swpVList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
