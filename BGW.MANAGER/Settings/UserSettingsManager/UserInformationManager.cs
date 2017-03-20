using BGW.MODEL.Settings.UserSettingsModel;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.UserSettingsManager
{
    public class UserInformationManager
    {
        DBManager _objmanager = new DBManager();
        UserInformationModel usermodel = new UserInformationModel();       
        #region Save User Information
        public void SaveUserInformation(List<UserInformationModel> userlist)
        {
            try
            {               
                foreach (UserInformationModel user in userlist)
                {
                    if (user.UserID == 0)
                        user.UserID = _objmanager.PrimaryKey("UserInformation");
                }
                _objmanager.SaveCollection(userlist);              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get User Information

        public UserInformationModel GetUserInformationByEmployeeCode(String EmployeeCode)
        {
            try
            {
                string sql = String.Format(@"[dbo].[spGetUserInformationByEmployeeCode] '{0}'", EmployeeCode);
                return _objmanager.SingleCollection(usermodel, sql);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public List<UserInformationModel> GetAllUserList()
        {
            try
            {
                string sql = String.Format(@"SELECT * FROM tblUser");
                return _objmanager.GetDefaultCollection(usermodel, sql);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public UserInformationModel GetUser(string UserName,string Password)
        {
            try
            {
                string sql = String.Format(@"SELECT * FROM tblUser WHERE UserName='{0}' AND Password='{1}'", UserName, Password);
                return _objmanager.SingleCollection(usermodel, sql);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UserInformationModel GetUserByUserName(string UserName)
        {
            try
            {
                string sql = String.Format(@"spGetUser'{0}'", UserName);
                return _objmanager.SingleCollection(usermodel, sql);
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
                return _objmanager.PopulateComboBox("SELECT * FROM tblUser", "UserID", "UserName", "-Select User-");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
