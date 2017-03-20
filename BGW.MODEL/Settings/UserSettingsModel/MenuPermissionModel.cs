using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Settings.UserSettingsModel
{
    public class MenuPermissionModel : BaseClass
    {


        private Int64 _PermissionID;
        public Int64 PermissionID
        {
            get { return _PermissionID; }
            set { _PermissionID = value; }
        }
        private Int64 _UserID;
        [Browsable(true),DisplayName("User Id")]
        public Int64 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private Int32 _MenuID;
        public Int32 MenuID
        {
            get { return _MenuID; }
            set { _MenuID = value; }
        }
        private Int32 _Authorization;
        public Int32 Authorization
        {
            get { return _Authorization; }
            set { _Authorization = value; }
        }

        private string _MenuName;
        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }


        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _PermissionID, _UserID, _MenuID, _Authorization };
                this.SpName = "[dbo].[spSavetblUserWiseMenu]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _PermissionID, _UserID, _MenuID, _Authorization };
                this.SpName = "[dbo].[spUpdatetblUserWiseMenu]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _PermissionID };
                this.SpName = "[dbo].[spUpdatetblUserWiseMenu]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new MenuPermissionModel
            {
                _PermissionID = reader.GetInt64("PermissionID"),
                _UserID = reader.GetInt64("UserID"),
                _MenuID = reader.GetInt32("MenuID"),
                _Authorization = reader.GetInt32("Authorization"),
                _MenuName = reader.GetToString("MenuName"),
                _DisplayName = reader.GetToString("DisplayName")
            };
        }

        public object MapParameter_1(IDataReader reader)
        {
            return new MenuPermissionModel
            {
                _PermissionID = reader.GetInt64("PermissionID"),
                _UserID = reader.GetInt64("UserID"),
                _MenuID = reader.GetInt32("MenuID"),
                _Authorization = reader.GetInt32("Authorization")
               
            };
        }
    }
}
