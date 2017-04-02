using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRL.DAL
{
    class DBConnection
    {
        protected IDbTransaction transaction;
        protected OdbcTransaction odbctransaction;

        protected SqlConnection connection;
        //protected OdbcConnection odcConnection;

        //protected IDbConnection connection;
        IDataReader reader;
        OdbcDataReader odbcreader;
        IDataAdapter da;

        protected ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
        
        string connectionStr;
        private string ConnectionString()
        {  
            string sqlconnection = ConfigurationManager.ConnectionStrings["Arup"].ToString();
            return sqlconnection;
        }

        private void OpenConnection()
        {
            if (connections[1].ProviderName == "System.Data.SqlClient")
            {
                connection = new SqlConnection(ConnectionString());                
            }
            //else if (connections[1].ProviderName == "System.Data.Odbc")
            //{
            //    connection = new OdbcConnection(ConnectionString());
            //}
            connection.Open();
        }
        internal void CloseConnection()
        {
            if (connections[1].ProviderName == "System.Data.SqlClient")
                connection.Close();
            else if (connections[1].ProviderName == "System.Data.Odbc")
                connection.Close();
        }        
        protected internal void BeginTransection()
        {
            try
            {
                OpenConnection();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        protected internal void CommitTransection()
        {
            transaction.Commit();
            CloseConnection();
        }       
        protected internal void RollBack()
        {
            transaction.Rollback();
            CloseConnection();
        }



        public void SaveData(string sql)
        {

            IDbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.Transaction = transaction;
            try
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public IDataReader ExecuteReader(string sql, IDataReader reader)
        {
            try
            {
                OpenConnection();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = sql;
                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public object FillDataset(string sql, ref DataSet ds)
        {
            try
            {
                OpenConnection();
                if (connections[1].ProviderName == "System.Data.SqlClient"){
                    da = new SqlDataAdapter(sql, ConnectionString());
                }                   
                    
                else if (connections[1].ProviderName == "System.Data.Odbc")
                    da = new OdbcDataAdapter(sql, ConnectionString());               
                
                da.Fill(ds);
                CloseConnection();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Int64 PrimaryKey(object output, string spname, object prm)
        {
            return ExecuteScaler(output, spname, prm);
        }
        public Int32 ReportPrimaryKey(object output, string spname, object prm)
        {
            return ExecuteScalerInt32(output, spname, prm);
        }
        private Int64 ExecuteScaler(object output, string spname, object prm)
        {
            try
            {                
                OpenConnection();
                //IDbCommand idbcommand = connection.CreateCommand();

                //idbcommand.CommandType = CommandType.StoredProcedure;
                //idbcommand.CommandText = spname;

                //idbcommand.Parameters.Add(prm.ToString());                
                //idbcommand.Parameters.Add("@" + output + "="+ SqlDbType.BigInt);
                //idbcommand.Parameters["@" + output + ""] = ParameterDirection.Output;
                //reader = idbcommand.ExecuteReader();

                //Int64 outputValue = Convert.ToInt64(idbcommand.Parameters["@" + output + ""]);     

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spname;
                command.Parameters.AddWithValue("@TableName", prm.ToString());
                command.Parameters.Add("@" + output + "", SqlDbType.BigInt);
                command.Parameters["@" + output + ""].Direction = ParameterDirection.Output;

                reader = command.ExecuteReader();
                Int64 outputValue = Convert.ToInt64(command.Parameters["@" + output + ""].Value);                
                return outputValue;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    CloseConnection();
            }
        }

        private Int32 ExecuteScalerInt32(object output, string spname, object prm)
        {
            try
            {
                OpenConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spname;
                command.Parameters.AddWithValue("@TableName", prm.ToString());
                command.Parameters.Add("@" + output + "", SqlDbType.BigInt);
                command.Parameters["@" + output + ""].Direction = ParameterDirection.Output;

                reader = command.ExecuteReader();
                Int32 outputValue = Convert.ToInt32(command.Parameters["@" + output + ""].Value);
                return outputValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    CloseConnection();
            }
        }       

       
    }

    
}
