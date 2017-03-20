using BGW.MANAGER.Settings.IMSSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsManager
{
    public class ItemManager
    {
        DBManager _objmanager = new DBManager();
        ItemModel itemmodel = new ItemModel();

        #region Save
        public void SaveItem(List<ItemModel> itemlist)
        {
            try
            {
                foreach (ItemModel model in itemlist)
                {
                    if(model.ItemID==null)
                        model.ItemID = _objmanager.PrimaryKey("Item");
                }
                _objmanager.SaveCollection(itemlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get Item  List
        public List<ItemModel> GetItemList()
        {
            try
            {
                return _objmanager.GetDefaultCollection(itemmodel, "SELECT I.*,IG.ItemGroupName FROM tblItem I LEFT JOIN tblItemGroup IG ON IG.ItemGroupID=I.ItemGroupID");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ItemModel GetItemByItemCode(Int64 ItemID)
        {
            try
            {
                return _objmanager.SingleCollection(itemmodel, String.Format("SELECT *,'' AS ItemGroupName FROM tblItem WHERE ItemID={0}",ItemID));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Combo box
        public object VCboItem()
        {
            try
            {
                return _objmanager.PopulateComboBox("SELECT * FROM tblItem", "ItemID", "ItemName", "-Select Item-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
