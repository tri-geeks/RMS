using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.MODEL.Payment
{
    public class CreditCardModel
    {
        [Required]
        [Browsable(true), DisplayName("Card Number")]
        public string Number { get; set; }
        [Required]
        [Browsable(true), DisplayName("Expiration Year")]
        public string ExpirationYear { get; set; }
        [Required]
        [Browsable(true), DisplayName("Expiration Month")]
        public string ExpirationMonth { get; set; }
        public string AddressCountry { get; set; }          // optional
        public string AddressLine1 { get; set; }            // optional
        public string AddressLine2 { get; set; }            // optional
        public string AddressCity { get; set; }             // optional
        public string AddressState { get; set; }            // optional
        public string AddressZip { get; set; }              // optional
        [Required]
        [Browsable(true), DisplayName("Name")]
        public string Name { get; set; }                    // optional
        [Required]
        [Browsable(true), DisplayName("CVC")]
        public string Cvc { get; set; }   
    }
}
