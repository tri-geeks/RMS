using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRL.DAL
{
    public static class StaticInfo
    {
        private static Int64 _UserID;
        public static Int64 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private static String _UserName;
        public static String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
    }
}
