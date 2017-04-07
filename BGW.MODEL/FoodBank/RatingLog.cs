using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.FoodBank
{
    public class RatingLog
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int RatingForId { get; set; }
        public string Email { get; set; }
        public int Vote { get; set; }
        public bool Active { get; set; }
        
    }
}
