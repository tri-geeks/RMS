using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BGW.MANAGER.Report
{
    public class SqlConnectionManager
    {
        public SqlConnection ObjSqlConnection = new SqlConnection(ConnectionString);
        private static string _connectionString;

        private static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["MAMS_DB"].ToString();
                }
                return _connectionString;
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (ObjSqlConnection.State == ConnectionState.Closed)
            {
                ObjSqlConnection.Open();
            }
            var transaction = ObjSqlConnection.BeginTransaction();
            return transaction;
        }
    }
}
