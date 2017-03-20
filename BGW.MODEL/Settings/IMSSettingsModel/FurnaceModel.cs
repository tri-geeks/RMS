using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Settings.IMSSettingsModel
{
    public class FurnaceModel:BaseClass
    {


        private Int64? _FurID;
        public Int64? FurID
        {
            get { return _FurID; }
            set { _FurID = value; }
        }
        private string _FurName;
        [Required(ErrorMessage = "Furnace Name is required")]
        [Browsable(true), DisplayName("Furnace Name")]
        [MaxLength(50), MinLength(3)]
        public string FurName
        {
            get { return _FurName; }
            set { _FurName = value; }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _FurID, _FurName, _Description };
                this.SpName = "[dbo].[spSavetblFurnace]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _FurID, _FurName, _Description };
                this.SpName = "[dbo].[spUpdatetblFurnace]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _FurID };
                this.SpName = "[dbo].[spUpdatetblFurnace]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new FurnaceModel
            {
                _FurID = reader.GetInt64("FurID"),
                _FurName = reader.GetToString("FurName"),
                _Description = reader.GetToString("Description"),
            };
        }
    }
}
