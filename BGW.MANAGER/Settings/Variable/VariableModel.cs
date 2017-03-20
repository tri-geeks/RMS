using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.Variable
{
    public class VariableModel:BaseClass
    {


        private string _VariableID;
        public string VariableID
        {
            get { return _VariableID; }
            set { _VariableID = value; }
        }
        private string _VariableName;
        public string VariableName
        {
            get { return _VariableName; }
            set { _VariableName = value; }
        }
        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _VariableID, _VariableName, _IsActive };
                this.SpName = "[dbo].[spSavetblVariable]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _VariableID, _VariableName, _IsActive };
                this.SpName = "[dbo].[spUpdatetblVariable]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _VariableID };
                this.SpName = "[dbo].[spUpdatetblVariable]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new VariableModel
            {
                _VariableID = reader.GetToString("VariableID"),
                _VariableName = reader.GetToString("VariableName"),
                _IsActive = reader.GetBoolean("IsActive"),
            };
        }
    }
}
