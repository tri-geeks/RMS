using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Payment
{
    public class PaymentInformationModel
    {
        [Required]
        [Browsable(true),DisplayName("Amount")]
        public decimal Amount { get; set; }
        [Required]
        [Browsable(true), DisplayName("Currency")]
        public string Currency { get; set; }
        [Browsable(true), DisplayName("Payment Discription")]
        public string Description { get; set; }
        
        public string SourceTokenOrExistingSourceId { get; set; }
    }
}
