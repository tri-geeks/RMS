using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRL.DAL
{
    public static class ExtensionMethod 
    {
        public static String GetToString(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          null : reader.GetString(reader.GetOrdinal(columnName));
        }
        public static Int32 GetInt32(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          0 : reader.GetInt32(reader.GetOrdinal(columnName));
        }
        public static Int64 GetInt64(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          0 : reader.GetInt64(reader.GetOrdinal(columnName));
        }

        public static Decimal GetDecimal(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          0 : reader.GetDecimal(reader.GetOrdinal(columnName));
        }
        public static Boolean GetBoolean(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          false : reader.GetBoolean(reader.GetOrdinal(columnName));
        }
        public static DateTime GetDateTime(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        public static object GetObject(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          (object)DBNull.Value : reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        public static Byte[] GetByteArray(this IDataReader reader, String columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ?
                          new Byte[0] : (Byte[])reader.GetValue(reader.GetOrdinal(columnName));
        }
    }
}
