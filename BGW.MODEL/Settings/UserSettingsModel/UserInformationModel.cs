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
        private Int64? _UserID;
        
        [Browsable(true),DisplayName("User Id")]
        public Int64? UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

       
        private String _UserFullName;
        [Required]
        [Browsable(true), DisplayName("Employee Name")]
        public String UserFullName
        {
            get { return _UserFullName; }
            set { _UserFullName = value; }
        }
        private String _Email;
        [Required]
        [Browsable(true), DisplayName("E-m@il")]
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private String _Contact;
        [Required]
        [Browsable(true), DisplayName("Contact")]
        public String Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
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

        private String _ComfirmPassword;
        [Required]
        [Browsable(true), DisplayName("Comfirm Password")]
        public String ConfirmPassword
        {
            get { return _ComfirmPassword; }
            set { _ComfirmPassword = value; }
        }

        private Boolean _IsActive;
        //[Browsable(true), DisplayName("Is Active")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private Boolean _IsAdmin;
        //[Browsable(true), DisplayName("Is Admin")]
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
                arr = new object[] { _UserID, _UserFullName, _Email, _Contact, _UserName, _Password, _ComfirmPassword, _IsActive, _IsAdmin };
                this.SpName = "[Security].[spSaveUserInformation]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _UserID, _UserFullName, _Email, _Contact, _UserName, _Password, _ComfirmPassword, _IsActive, _IsAdmin };
                this.SpName = "[Security].[spUpdateUserInformation]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _UserID };
                this.SpName = "[Security].[spDeleteUserInformation]";
            }
            return arr;
        }




        public override object MapParameter(IDataReader reader)
        {
            return new UserInformationModel
            {
                _UserID = reader.GetInt64("UserID"),
                _UserFullName = reader.GetToString("UserFullName"),
                _Email = reader.GetToString("Email"),
                _Contact = reader.GetToString("Contact"),
                _UserName = reader.GetToString("UserName"),
                _Password = reader.GetToString("Password"),
                _ComfirmPassword = reader.GetToString("ComfirmPassword"),
                _IsActive = reader.GetBoolean("IsActive"),
                _IsAdmin = reader.GetBoolean("IsAdmin"),
            };
        }

    }
}
