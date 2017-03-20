using BGW.MANAGER.Settings.Variable;
using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Variable
{
    public class VariableManager
    {
        DBManager _objmanager = new DBManager();
        VariableModel vmodel = new VariableModel();

        public VariableModel GetAuthenticationMode(string variableId)
        {
            try
            {
                string Sql = string.Format("SELECT * FROM tblVariable WHERE IsActive=1 AND VariableID='{0}'", variableId);
                return _objmanager.SingleCollection(vmodel, Sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
