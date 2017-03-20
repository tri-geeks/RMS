using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Report
{
    public class ReportViewManager
    {
        public static DataTable GetReportData(String sqlString, IDbDataParameter[] objParam)
        {
            var reportDataSet = new DataTable();
            DBManager _conManager = new DBManager();           
            using (var reader = _conManager.ExecuteReader(sqlString, objParam))
            {
                while (!reader.IsClosed)
                {
                    reportDataSet = DataReaderToDataTable(reader);
                }
            }
            return reportDataSet;
        }

        public static DataTable DataReaderToDataTable(IDataReader reader)
        {
            //var ds = new DataSet();
            DataTable table;
            do
            {
                int fieldCount = reader.FieldCount;
                table = new DataTable();
                for (int i = 0; i < fieldCount; i++)
                {
                    table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                }
                table.BeginLoadData();
                var values = new Object[fieldCount];
                while (reader.Read())
                {
                    reader.GetValues(values);
                    table.LoadDataRow(values, true);
                }
                table.EndLoadData();

                //ds.Tables.Add(table);

            } while (reader.NextResult());
            reader.Close();
            return table;
        }
    }
}
