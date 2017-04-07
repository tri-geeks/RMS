using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGW.MODEL.Settings;
using BGW.MODEL.Settings.UserSettingsModel;
using SSRL.DAL;

namespace BGW.MANAGER.Settings
{
    public class SettingsManager
    {
        #region Object Initialization
        DBManager _conManager = new DBManager();
        UserInformationModel _userModel = new UserInformationModel();
        MenuPermissionModel _menuModel = new MenuPermissionModel();
        MenuCategoryModel _menuCategory = new MenuCategoryModel();
        MenuSubCategoryModel _menuSubCategory = new MenuSubCategoryModel();
        ReservationTypeModel _reservationTypeModel = new ReservationTypeModel();
        #endregion

        #region User Information
        public void SaveUser(List<UserInformationModel> userList)
        {
            try
            {
                if (userList[0].UserID == null)
                {
                    userList[0].UserID = _conManager.PrimaryKey("UserInformation");
                }
                _conManager.SaveCollection(userList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UserInformationModel> GetUserList()
        {
            try
            {
                return _conManager.GetDefaultCollection(_userModel, string.Format("SELECT * FROM [Security].[UserInformation]"));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion

        #region Menu Permission
        public void SaveMenuPermission(List<MenuPermissionModel> menuList)
        {
            try
            {
                foreach (MenuPermissionModel menuitem in menuList)
                {
                    if (menuitem.PermissionID == 0)
                        menuitem.PermissionID = _conManager.PrimaryKey("MenuPermission");
                }
                _conManager.SaveCollection(menuList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public object VCboUser()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [Security].[UserInformation]", "UserID", "UserName", "-Select User-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MenuPermissionModel> GetMenulistByUserID(Int64 UserID)
        {
            try
            {
                return _conManager.GetDefaultCollection(_menuModel, string.Format("[Security].[GetUserWiseMenu] {0}", UserID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MenuPermissionModel GetValidUser(Int64 UserID, string Controller, string Action)
        {
            try
            {
                string sql = String.Format(@"[Security].[spValidateUser] {0},'{1}','{2}'", UserID, Controller, Action);
                return _conManager.SingleCollection(_menuModel, "MapParameter_1", sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UserInformationModel GetUser(string UserName, string Password)
        {
            try
            {
                string sql = String.Format(@"[Security].[spGetUserInformationByUserNameAndPassword] '{0}','{1}'", UserName, Password);
                return _conManager.SingleCollection(_userModel, sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Menu Category
        public void SaveMenuCategory(List<MenuCategoryModel> categorylist)
        {
            try
            {
                foreach(MenuCategoryModel ctitem in categorylist)
                {
                    if (ctitem.MCID == 0)
                        ctitem.MCID = _conManager.PrimaryKey("MenuCategory");
                }
                _conManager.SaveCollection(categorylist);
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public List<MenuCategoryModel> GetMenuCategoryList()
        {
            try
            {
                return _conManager.GetDefaultCollection(_menuCategory, @"SELECT * FROM Settings.MenuCategory");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object VCboMenuCategory()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM Settings.MenuCategory", "MCID", "CategoryName", "-Select User-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Menu Sub Category
        public void SaveSubCategory(List<MenuSubCategoryModel> subcategoryList)
        {
            try
            {
                foreach(MenuSubCategoryModel subItem in subcategoryList)
                {
                    if (subItem.SubCategoryID == 0)
                        subItem.SubCategoryID = _conManager.PrimaryKey("SubCategory");
                }
                _conManager.SaveCollection(subcategoryList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MenuSubCategoryModel> GetMenuSubCtegoryList()
        {
            try
            {
                return _conManager.GetDefaultCollection(_menuSubCategory, @"SELECT * FROM [Settings].[MenuSubCategory]");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Reservation Type
        public void SaveReservationType(List<ReservationTypeModel> rtypelist)
        {
            try
            {
                foreach(ReservationTypeModel rtypeitem in rtypelist)
                {
                    if (rtypeitem.ReservationTypeID == 0)
                        rtypeitem.ReservationTypeID = _conManager.PrimaryKey("ReservationType");
                }
                _conManager.SaveCollection(rtypelist);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ReservationTypeModel> GetReservationTypeList()
        {
            try
            {
                return _conManager.GetDefaultCollection(_reservationTypeModel, @"SELECT * FROM [Reservation].[ReservationType]");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object VCboRservationType()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [Reservation].[ReservationType]", "ReservationTypeID", "TypeName", "-Select Type-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public object VCboRservationStatus()
        {
            try
            {
                return _conManager.PopulateComboBox("SELECT * FROM [Reservation].[BookingStatus]", "ReservationStatusID", "StatusName", "-Select Type-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
