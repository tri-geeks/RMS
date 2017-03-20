using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Report
{
    public class PreViewReportModel
    {
        private string _ParmName;
        public string ParmName
        {
            get { return _ParmName; }
            set { _ParmName = value; }
        }
        private string _ParmVal;
        public string ParmVal
        {
            get { return _ParmVal; }
            set { _ParmVal = value; }
        }
    }
}
