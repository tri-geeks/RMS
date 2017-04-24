using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BGW.MODEL.Payment;
using Stripe;

namespace TG.RMSCLIENT.WEB.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult MakePayment(Int64 bookingId,string email)
        {
            TempData["bookingId"] = bookingId;
            TempData["email"] = email;
            return View();
        }
        [HttpPost]
        public RedirectResult MakePaymentC(CreditCardModel creditModel,PaymentInformationModel paymentModel)
        {
            var chargeId = BuySign(creditModel, paymentModel);
            if (chargeId != null)
                return Redirect("");
            else
                return Redirect("");
        }

        public async Task<string> BuySign(CreditCardModel creditModel, PaymentInformationModel paymentModel)
        {
            var errorMessage = string.Empty;
            var validationError = string.Empty;
            object chargeId = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    var tokenId = await GetTokenId(creditModel);
                    chargeId = await ChargeCustomer(tokenId.ToString(), paymentModel);
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
            }
            return chargeId.ToString();


        }

        public static async Task<string> GetTokenId(CreditCardModel creditModel)
        {
            StripeTokenCreateOptions myToken = new StripeTokenCreateOptions();
            myToken.Card = new StripeCreditCardOptions()
            {
                // set these properties if passing full card details (do not
                // set these properties if you set TokenId)
                Number = creditModel.Number,
                ExpirationYear = creditModel.ExpirationYear,
                ExpirationMonth = creditModel.ExpirationMonth,
                AddressCountry = creditModel.AddressCountry,            // optional
                AddressLine1 = creditModel.AddressLine1,               // optional
                AddressLine2 = creditModel.AddressLine2,              // optional
                AddressCity = "",                                    // optional
                AddressState = creditModel.AddressState,            // optional
                AddressZip = creditModel.AddressZip,               // optional
                Name = creditModel.Name,                          // optional
                Cvc = creditModel.Cvc                            // optional
            };
            var tokenService = new StripeTokenService();
            StripeToken stripeToken = tokenService.Create(myToken);
            return stripeToken.Id;
        }


        private static async Task<object> ChargeCustomer(string tokenId, PaymentInformationModel paymentModel)
        {
            
            return await System.Threading.Tasks.Task.Run(() =>
            {
                var myCharge = new StripeChargeCreateOptions
                {
                    Amount = Convert.ToInt32(paymentModel.Amount),
                    Currency = paymentModel.Currency,
                    Description = paymentModel.Description,
                    SourceTokenOrExistingSourceId = tokenId
                };

                var chargeService = new StripeChargeService();
                var stripeCharge = chargeService.Create(myCharge);                
                return stripeCharge.Id;
            });
        }

    }
}
