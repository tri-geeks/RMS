using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MANAGER.Email
{
    public class EmailCriteriaVM
    {
        [DataType(DataType.EmailAddress)]
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }       
        
        //[UIHint("tinymce_jquery_full"), System.Web.Mvc.AllowHtml]
        public string Content { get; set; }

    }
}
