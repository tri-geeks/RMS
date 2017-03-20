using BGW.MANAGER.Settings.IMSSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsManager
{
    public class QualityManager
    {
        DBManager _objmanager = new DBManager();
        QualityModel qualityModel = new QualityModel();

        #region Save
        public void SaveQuality(List<QualityModel> qualitylist)
        {
            try
            {
                foreach (QualityModel model in qualitylist)
                {
                    if (model.QualityID == null)
                        model.QualityID = _objmanager.PrimaryKey("Quality");
                }
                _objmanager.SaveCollection(qualitylist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Quality List
        public List<QualityModel> GetQualityList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(qualityModel, "SELECT * FROM tblQuality");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public object VCboQuality()
        {
            try
            {
                return _objmanager.PopulateComboBox("SELECT * FROM tblQuality", "QualityID", "QualityName", "-Select Quality-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
