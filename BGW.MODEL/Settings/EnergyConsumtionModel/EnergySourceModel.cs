using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Settings.EnergyConsumtionModel
{
    public class EnergySourceModel:BaseClass
    {


        private Int64? _ECSID;
        public Int64? ECSID
        {
            get { return _ECSID; }
            set { _ECSID = value; }
        }
        private string _ECSName;
        public string ECSName
        {
            get { return _ECSName; }
            set { _ECSName = value; }
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
                arr = new object[] { _ECSID, _ECSName, _Description };
                this.SpName = "[dbo].[spSaveEnergyConsumptionSource]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _ECSID, _ECSName, _Description };
                this.SpName = "[dbo].[spUpdateEnergyConsumptionSource]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _ECSID };
                this.SpName = "[dbo].[spUpdateEnergyConsumptionSource]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new EnergySourceModel
            {
                _ECSID = reader.GetInt64("ECSID"),
                _ECSName = reader.GetToString("ECSName"),
                _Description = reader.GetToString("Description"),
            };
        }
    }
}
