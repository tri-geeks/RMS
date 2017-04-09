using SSRL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Reservation
{
    public class RatingModel:BaseClass
    {

        private string _EmailId;
        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private bool _Star1;
        public bool Star1
        {
            get { return _Star1; }
            set { _Star1 = value; }
        }
        private bool _Star2;
        public bool Star2
        {
            get { return _Star2; }
            set { _Star2 = value; }
        }
        private bool _Star3;
        public bool Star3
        {
            get { return _Star3; }
            set { _Star3 = value; }
        }
        private bool _Star4;
        public bool Star4
        {
            get { return _Star4; }
            set { _Star4 = value; }
        }
        private bool _Star5;
        public bool Star5
        {
            get { return _Star5; }
            set { _Star5 = value; }
        }



        public override object[] SetParameter()
        {
            object[] arr = { };
            if (this.SetAdded)
            {
                arr = new object[] { _EmailId, _Name, _Subject, _Phone, _Message, _Star1, _Star2, _Star3, _Star4, _Star5 };
                this.SpName = "[dbo].[spSaveRatings]";
            }
            else if (this.SetUpdated)
            {
                arr = new object[] { _EmailId, _Name, _Subject, _Phone, _Message, _Star1, _Star2, _Star3, _Star4, _Star5 };
                this.SpName = "[dbo].[spUpdateRatings]";
            }
            else if (this.SetDeleted)
            {
                arr = new object[] { _EmailId };
                this.SpName = "[dbo].[spUpdateRatings]";
            }
            return arr;
        }



        public override object MapParameter(IDataReader reader)
        {
            return new RatingModel
            {
                _EmailId = reader.GetToString("EmailId"),
                _Name = reader.GetToString("Name"),
                _Subject = reader.GetToString("Subject"),
                _Phone = reader.GetToString("Phone"),
                _Message = reader.GetToString("Message"),
                _Star1 = reader.GetBoolean("Star1"),
                _Star2 = reader.GetBoolean("Star2"),
                _Star3 = reader.GetBoolean("Star3"),
                _Star4 = reader.GetBoolean("Star4"),
                _Star5 = reader.GetBoolean("Star5")

            };
        }
    }
}
