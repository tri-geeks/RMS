using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Settings.UserSettingsModel
{
    public class UserInformationModel:BaseClass
    {
        private Int64 _UserID;
        [Required]
        [Browsable(true),DisplayName("User Id")]
        public Int64 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private String _EmployeeCode;
        [Required]
        [Browsable(true), DisplayName("Employee Code")]
        public String EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }
        private String _EmployeeName;
        [Required]
        [Browsable(true), DisplayName("Employee Name")]
        public String EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        private String _Email;
        [Required]
        [Browsable(true), DisplayName("E-m@il")]
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private String _Phone;
        [Required]
        [Browsable(true), DisplayName("Contact")]
        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private String _UserName;
        [Required]
        [Browsable(true), DisplayName("User Name")]
        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private String _Password;
        [Required]
        [Browsable(true), DisplayName("Password")]
        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private String _ConfirmPassword;
        [Required]
        [Browsable(true), DisplayName("Comfirm Password")]
        public String ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value; }
        }

        private Boolean _IsActive;
        [Browsable(true), DisplayName("Is Active")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private Boolean _IsAdmin;
        [Browsable(true), DisplayName("Is Admin")]
        public Boolean IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }

        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _UserID, _EmployeeCode, _EmployeeName, _Email, _Phone, _UserName, _Password, _ConfirmPassword, _IsActive, _IsAdmin };
                this.SpName = "[dbo].[spSavetblUser]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _UserID, _EmployeeCode, _EmployeeName, _Email, _Phone, _UserName, _Password, _ConfirmPassword, _IsActive, _IsAdmin };
                this.SpName = "[dbo].[spUpdatetblUser]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _UserID };
                this.SpName = "[dbo].[spDeletetblUser]";
            }
            return arr;
        }




        public override object MapParameter(IDataReader reader)
        {
            return new UserInformationModel
            {
                _UserID = reader.GetInt64("UserID"),
                _EmployeeCode = reader.GetToString("EmployeeCode"),
                _EmployeeName = reader.GetToString("EmployeeName"),
                _Email = reader.GetToString("Email"),
                _Phone = reader.GetToString("Phone"),
                _UserName = reader.GetToString("UserName"),
                _Password = reader.GetToString("Password"),
                _ConfirmPassword = reader.GetToString("ConfirmPassword"),
                _IsActive = reader.GetBoolean("IsActive"),
                _IsAdmin = reader.GetBoolean("IsAdmin"),
            };
        }

    }
}
