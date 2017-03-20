using BGW.MANAGER.Settings.IMSSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BGW.MANAGER.Settings.IMSSettingsManager
{
    public class ItemGroupManager
    {
        #region Object Initialization
        DBManager _objmanager = new DBManager();
        ItemGroupModel itemgroupmodel = new ItemGroupModel();
        #endregion

        #region Save
        public void SaveItemGroup(List<ItemGroupModel> itemGrouplist)
        {
            try
            {
                foreach (ItemGroupModel model in itemGrouplist)
                {
                    if(model.ItemGroupID==0)
                        model.ItemGroupID = _objmanager.PrimaryKey("ItemGroup");
                }
                _objmanager.SaveCollection(itemGrouplist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Item Group List
        public List<ItemGroupModel> GetItemGroupList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(itemgroupmodel, "SELECT * FROM tblItemGroup");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object JCboItemGroup()
        {
            try
            {
                var itmGlist = _objmanager.GetDefaultCollection(itemgroupmodel, "SELECT * FROM tblItemGroup");
                List<Dictionary<Int64, string>> dlist = new List<Dictionary<Int64, string>>();
                foreach(var item in itmGlist)
                {
                    Dictionary<Int64, string> dmodel = new Dictionary<Int64, string>();
                    dmodel.Add(item.ItemGroupID, item.ItemGroupName);
                    dlist.Add(dmodel);
                }
                
                return dlist.ToDictionary(x=>x.Keys,y=>y.Values);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public object VCboItemGroup()
        {
            try
            {
                return _objmanager.PopulateComboBox("SELECT * FROM tblItemGroup", "ItemGroupID", "ItemGroupName", "-Select Item Group-");
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
