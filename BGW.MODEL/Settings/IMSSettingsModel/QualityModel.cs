using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Settings.IMSSettingsModel
{
    public class QualityModel : BaseClass
    {


        private Int64? _QualityID;
        [Browsable(true), DisplayName("Quality Id")]
        public Int64? QualityID
        {
            get { return _QualityID; }
            set { _QualityID = value; }
        }
        private string _QualityName;
        [Required(ErrorMessage = "Quality Name is required")]
        [Browsable(true), DisplayName("Quality")]
        [MaxLength(50), MinLength(1)]
        public string QualityName
        {
            get { return _QualityName; }
            set { _QualityName = value; }
        }
        private string _QualityDescription;
        [Browsable(true), DisplayName("Description")]
        public string QualityDescription
        {
            get { return _QualityDescription; }
            set { _QualityDescription = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _QualityID, _QualityName, _QualityDescription };
                this.SpName = "[dbo].[spSavetblQuality]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _QualityID, _QualityName, _QualityDescription };
                this.SpName = "[dbo].[spUpdatetblQuality]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _QualityID };
                this.SpName = "[dbo].[spUpdatetblQuality]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new QualityModel
            {
                _QualityID = reader.GetInt64("QualityID"),
                _QualityName = reader.GetToString("QualityName"),
                _QualityDescription = reader.GetToString("QualityDescription"),
            };
        }
    }
}
