using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsModel
{
    public class ItemGroupModel : BaseClass
    {


        private Int64 _ItemGroupID;
        [DisplayName("Item Group Id")]
        public Int64 ItemGroupID
        {
            get { return _ItemGroupID; }
            set { _ItemGroupID = value; }
        }
        private string _ItemGroupName;
        [DisplayName("Item Group Name")]
        public string ItemGroupName
        {
            get { return _ItemGroupName; }
            set { _ItemGroupName = value; }
        }
        private string _ItemGroupDescription;
        [DisplayName("Description")]
        public string ItemGroupDescription
        {
            get { return _ItemGroupDescription; }
            set { _ItemGroupDescription = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _ItemGroupID, _ItemGroupName, _ItemGroupDescription };
                this.SpName = "[dbo].[spSavetblItemGroup]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ItemGroupID, _ItemGroupName, _ItemGroupDescription };
                this.SpName = "[dbo].[spUpdatetblItemGroup]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ItemGroupID };
                this.SpName = "[dbo].[spUpdatetblItemGroup]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new ItemGroupModel
            {
                _ItemGroupID = reader.GetInt64("ItemGroupID"),
                _ItemGroupName = reader.GetToString("ItemGroupName"),
                _ItemGroupDescription = reader.GetToString("ItemGroupDescription"),
            };
        }
    }
}
