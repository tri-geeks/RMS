using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SSRL.DAL
{
    //public delegate void SaveCollection(params object[] prm);
    public interface IDBManager
    {
        //public IDBManager()
        //{

        //}
        void SaveCollection(params object[] prm);
        List<T> GetCollection<T>(T classobject,string classmethod,string sqlquery);
        List<T> GetDefaultCollection<T>(T classobject,string sqlquery);
        T SingleCollection<T>(T classobject, string classmethod, string sqlquery);
        Int64 PrimaryKey(object prm);
    }
}
