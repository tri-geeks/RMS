using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRL.DAL
{
    public abstract class BaseClass
    {        
        public abstract object[] SetParameter();
        public abstract object MapParameter(IDataReader reader);

        public bool SetAdded;
        public bool SetUpdated;
        public bool SetDeleted;

        public string SpName;
        public bool Added()
        {
            SetAdded = true;
            return SetAdded;
        }
        public bool Updated()
        {
            SetUpdated = true;
            return SetUpdated;
        }
        public bool Deleted()
        {
            SetDeleted = true;
            return SetDeleted;
        }
    }// test
}
