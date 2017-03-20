using BGW.MANAGER.Settings.IMSSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsManager
{
    public class ShiftInformationManager
    {
        #region Object Initialization
        DBManager _objmanager = new DBManager();
        ShiftInformationModel shiftmodel = new ShiftInformationModel();
        #endregion

        #region Save Shift
        public void SaveShiftInformation(List<ShiftInformationModel> shiftlist)
        {
            try
            {
                foreach(ShiftInformationModel model in shiftlist)
                {
                    if(model.ShiftID==0)
                        model.ShiftID = _objmanager.PrimaryKey("ShiftInformation");
                }
                _objmanager.SaveCollection(shiftlist);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetShift Information
        public List<ShiftInformationModel> GetShiftList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(shiftmodel, "SELECT * FROM tblShiftInformation");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ShiftInformationModel GetShiftByShiftID(Int64 shiftID)
        {
            try
            {
                return _objmanager.SingleCollection(shiftmodel, string.Format("SELECT * FROM tblShiftInformation WHERE ShiftID={0}",shiftID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Combo box
        public object VCboShift()
        {
            try
            {
                return _objmanager.PopulateComboBox("SELECT * FROM tblShiftInformation", "ShiftID", "ShiftName", "-Select Shift-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
