using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SSRL.DAL
{
    public delegate object GetData(BaseClass obj);
    public class DBManager:IDBManager
    {
        
        public DBManager()
        {
            
        }
        DBConnection _con = new DBConnection();
        public void SaveCollection(params object[] prm)
        {
            try
            {
                _con.BeginTransection();
                foreach (var p in prm)
                {
                    var objlist = ((IEnumerable)p).Cast<object>().ToList();
                    QueryString(objlist);
                }
                _con.CommitTransection();
            }
            catch (Exception ex)
            {
                _con.RollBack();
                throw new Exception(ex.Message);
            }
            
        }

        public List<T> GetCollection<T>(T classobject, string classmethod, string sqlquery)
        {
            try
            {
                //_con.BeginTransection();
                IDataReader reader = null;
                reader = _con.ExecuteReader(sqlquery, reader);
                var Parameters = new object[] { reader };
                List<object> list = new List<object>();
                while (reader.Read())
                {
                    MethodInfo methodInfo = classobject.GetType().GetMethod(classmethod);
                    var obj = methodInfo.Invoke(classobject, Parameters);
                    list.Add(obj);
                }
                //_con.CommitTransection();
                _con.CloseConnection();
                return list.Cast<T>().ToList();
            }
            catch (Exception ex)
            {
                _con.CloseConnection();
                throw new Exception(ex.Message);
            }

        }

        public List<T> GetDefaultCollection<T>(T classobject, string sqlquery)
        {
            return GetDefaultCollection(classobject, "MapParameter", sqlquery);            
        }

        public List<T> GetDefaultCollection<T>(T classobject, string classmethod, string sqlquery)
        {
            try
            {
                //_con.BeginTransection();
                IDataReader reader = null;
                reader = _con.ExecuteReader(sqlquery, reader);
                var Parameters = new object[] { reader };
                List<object> list = new List<object>();
                while (reader.Read())
                {
                    MethodInfo methodInfo = classobject.GetType().GetMethod(classmethod);
                    var obj = methodInfo.Invoke(classobject, Parameters);
                    list.Add(obj);
                }
                //_con.CommitTransection();
                _con.CloseConnection();
                return list.Cast<T>().ToList();
            }
            catch (Exception ex)
            {
                _con.RollBack();
                //_con.CloseConnection();
                throw new Exception(ex.Message);
                
            }            
        }
        public T SingleCollection<T>(T classobject,string sqlquery)
        {
            return SingleCollection(classobject, "MapParameter", sqlquery);
        }
        public T SingleCollection<T>(T classobject,string classmethod, string sqlquery)
        {
            try
            {
                //_con.BeginTransection();
                IDataReader reader = null;
                reader = _con.ExecuteReader(sqlquery, reader);
                var Parameters = new object[] { reader };
                object obj = null;                
                while (reader.Read())
                {
                    MethodInfo methodInfo = classobject.GetType().GetMethod(classmethod);
                    obj = methodInfo.Invoke(classobject, Parameters);                   
                }
                //_con.CommitTransection();
                _con.CloseConnection();
                return (T)obj;
            }
            catch (Exception ex)
            {
                _con.RollBack();
                throw new Exception(ex.Message);

            }
        }
        private void QueryString<T>(List<T> obj)
        {

            try
            {
                Type testType = typeof(BaseClass);
                testType.GetType();
                foreach (var i in obj)
                {
                    string query = "";
                    string sqlquery = "";
                    object prma = ParmArry(i);
                    var saname = testType.GetField("SpName").GetValue(i);
                    object[] prmarry = prma as object[];
                    foreach (object j in prmarry)
                    {

                        if (j != null)
                        {
                            if (j.GetType() == typeof(Int32) || j.GetType() == typeof(Int64) || j.GetType() == typeof(Int16) || j.GetType() == typeof(bool) || j.GetType() == typeof(Nullable)||j.GetType()==typeof(decimal))
                            {
                                query += j + ",";
                            }
                            else
                            {
                                query += "'" + j + "',";
                            }
                        }
                        else
                        {                            
                            query +="null,";  
                           
                        }

                    }
                    query = query.TrimEnd(',');

                    sqlquery = saname + "  " + query;

                    _con.SaveData(sqlquery);

                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        private object ParmArry(object obj)
        {
            try
            {
                Type testType = typeof(BaseClass);
                MethodInfo methodInfo = testType.GetMethod("SetParameter");
                object[] Parameters = new object[] { };
                var prmarray = methodInfo.Invoke(obj, Parameters);
                return prmarray;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public Int64 PrimaryKey(object TableName)
        {
            _con.BeginTransection();
            return _con.PrimaryKey("SystemID", "[dbo].[spGenerateSystemID]", TableName);
        }

        public List<SelectListItem> PopulateComboBox(string sql, object value, object text, object initialtext)
        {
            try
            {
                _con.BeginTransection();
                IDataReader reader = null;
                reader = _con.ExecuteReader(sql, reader);
                var selectListItem = new List<SelectListItem> { new SelectListItem { Value = "0", Text = initialtext.ToString() } };
                while (reader.Read())
                {
                    selectListItem.Add(new SelectListItem()
                    {
                        //Value = reader.GetInt64(""+value+"").ToString(),                      
                        //Text = reader.GetToString("" + text + ""),

                        Value = reader["" + value + ""].ToString(),
                        Text = reader["" + text + ""].ToString(),
                        
                    });
                }
                return selectListItem;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int32 KeyForReport(string TableName)
        {
            _con.BeginTransection();
            return _con.ReportPrimaryKey("Key", "spGenerateKeyForReport", TableName);
        }

        public object GetDataSet(string sql, ref DataSet ds)
        {
            return _con.FillDataset(sql, ref ds);
        }

        public IDataReader ExecuteReader(String sqlString, IDbDataParameter[] objParam)
        {
            try
            {
                string query = "";
                string sqlquery = "";
                if (objParam != null)
                {
                    for (int i = 0; i < objParam.Count(); i++)
                    {
                        query += "@" + objParam[i].ParameterName + "='" + objParam[i].Value + "',";
                    }
                    query = query.TrimEnd(',');
                    sqlquery = sqlString + " " + query;
                }
                else
                {
                    sqlquery = sqlString;
                }
                
                _con.BeginTransection();
                IDataReader reader = null;
                reader = _con.ExecuteReader(sqlquery, reader);
                //_con.CommitTransection();
                return reader;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
