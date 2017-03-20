using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL
{
    public class PrimaryKeyModel:BaseClass
    {


        private Int32 _SignetureID;
        public Int32 SignetureID
        {
            get { return _SignetureID; }
            set { SignetureID = value; }
        }
        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { TableName = value; }
        }
        private Int32 _PrefixID;
        public Int32 PrefixID
        {
            get { return _PrefixID; }
            set { PrefixID = value; }
        }
        private Int32 _LastNumber;
        public Int32 LastNumber
        {
            get { return _LastNumber; }
            set { LastNumber = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _SignetureID, _TableName, _PrefixID, _LastNumber };
                this.SpName = "[dbo].[spSavetblSigneture]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _SignetureID, _TableName, _PrefixID, _LastNumber };
                this.SpName = "[dbo].[spUpdatetblSigneture]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _SignetureID };
                this.SpName = "[dbo].[spUpdatetblSigneture]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new PrimaryKeyModel
            {
                _SignetureID = reader.GetInt32("SignetureID"),
                _TableName = reader.GetToString("TableName"),
                _PrefixID = reader.GetInt32("PrefixID"),
                _LastNumber = reader.GetInt32("LastNumber"),
            };
        }
    }
}
