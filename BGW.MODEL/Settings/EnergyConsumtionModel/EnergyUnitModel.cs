using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Settings.EnergyConsumtionModel
{
    public class EnergyUnitModel:BaseClass
    {


        private Int64? _PUID;
        public Int64? PUID
        {
            get { return _PUID; }
            set { _PUID = value; }
        }
        private string _PUName;
        public string PUName
        {
            get { return _PUName; }
            set { _PUName = value; }
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
                arr = new object[] { _PUID, _PUName, _Description };
                this.SpName = "[dbo].[spSaveEnergyCategory]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _PUID, _PUName, _Description };
                this.SpName = "[dbo].[spUpdateEnergyCategory]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _PUID };
                this.SpName = "[dbo].[spUpdateEnergyCategory]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new EnergyUnitModel
            {
                _PUID = reader.GetInt64("PUID"),
                _PUName = reader.GetToString("PUName"),
                _Description = reader.GetToString("Description"),
            };
        }
    }
}
