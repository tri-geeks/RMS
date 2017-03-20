using BGW.MODEL.Settings.UserSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.UserSettingsManager
{
    public class MenuPermissionManager
    {
        DBManager _objmanager = new DBManager();
        MenuPermissionModel menuPermissionModel = new MenuPermissionModel();

        #region Save
        public void SaveUserWiseMenu(List<MenuPermissionModel> menulist)
        {
            try
            {
                foreach (MenuPermissionModel user in menulist)
                {
                    if (user.PermissionID == 0)
                        user.PermissionID = _objmanager.PrimaryKey("MenuPermission");
                }
                _objmanager.SaveCollection(menulist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        public List<MenuPermissionModel> GetPenuPermissionList(Int64 id)
        {
            try
            {
                string sql = String.Format(@"[dbo].[spGetMenulistByUserID] {0}",id);
                return _objmanager.GetDefaultCollection(menuPermissionModel, sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public MenuPermissionModel GetValidUser(string UserName,string Controller,string Action)
        {
            try
            {
                string sql = String.Format(@"spValidateUser '{0}','{1}','{2}'", UserName, Controller, Action);
                return _objmanager.SingleCollection(menuPermissionModel, "MapParameter_1", sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
