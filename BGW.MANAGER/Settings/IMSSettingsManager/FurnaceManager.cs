using BGW.MODEL.Settings.IMSSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BGW.MANAGER.Settings.IMSSettingsManager
{
    public class FurnaceManager
    {
        DBManager _objmanager = new DBManager();
        FurnaceModel furnacemodel = new FurnaceModel();
        #region Save Furnace
        public void SaveFurnace(List<FurnaceModel> flist)
        {
            try
            {
                foreach(FurnaceModel fitem in flist)
                {
                    if (fitem.FurID == 0 || fitem.FurID == null)
                        fitem.FurID=_objmanager.PrimaryKey("Furnace");
                }                
                _objmanager.SaveCollection(flist);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Furnace list
        public List<FurnaceModel> GetFurnaceList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(furnacemodel, "SELECT * FROM tblFurnace");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Combo box
        public object VCboFurnace()
        {
            try
            {
                return _objmanager.PopulateComboBox("SELECT * FROM tblFurnace", "FurID", "FurName", "-Select Furnace-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
