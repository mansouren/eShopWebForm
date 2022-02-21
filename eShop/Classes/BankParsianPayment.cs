using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eShop.BankParsian;
using System.Configuration;



namespace eShop
{
    public class BankParsianPayment 
    {
        #region IPaymentInterface Members
        

        public bool ProcessPayment(Page sourcePage, int Amount,int OrderID)
        {            
            long authority = 0;
            byte status = 0;

            string MerchantID = ConfigurationManager.AppSettings["BankParsianMerchantID"].ToString();


            string returnPageURL = GetReturnPageUrl(sourcePage, OrderID);

            var service = new EShopServiceSoapClient();

            //service.Url = "https://www.pec24.com/pecpaymentgateway/EShopService.asmx";
            service.PinPaymentRequest(MerchantID, Amount, OrderID, returnPageURL, ref authority, ref status);

            if (status == 0)
            {
                sourcePage.Response.Redirect("https://www.pec24.com/pecpaymentgateway/default.aspx?au=" + authority.ToString(), true);
            }

            return true;
        }

        public PaymentResponse ProcessResponse(Page sourcePage, int Amount,int Order_ID)
        {
            string merchantID = ConfigurationManager.AppSettings["BankParsianMerchantID"].ToString();

            string statusmessage = string.Empty;
            PaymentResponse paymentResponse = new PaymentResponse();

            
            string authorityStr = sourcePage.Request.Params["au"];
            string response = sourcePage.Request.Params["rs"];

            try
            {
                var service = new EShopServiceSoapClient();
                //service.Url = "https://www.pec24.com/pecpaymentgateway/EShopService.asmx";



                // if response is succesful, eShops have to check it again
                if (response == "0" && authorityStr != null)
                {
                    long authority = long.Parse(authorityStr);

                    byte status = 0;
                    service.PinPaymentEnquiry(merchantID, authority, ref status);

                    // if this method failed, eShop has to call the following method
                    // service.Reversal(authority, ref status);
                    // to be sure about payment reversal


                    paymentResponse.ResponseMessage = "موفقیت آمیز";
                    paymentResponse.ResponseCode = status;
                    paymentResponse.Successful = true;
                    paymentResponse.Transaction_ID = authorityStr;
                }
                else
                {
                    paymentResponse.ResponseMessage = "خطا در پرداخت";
                    paymentResponse.ResponseCode = int.Parse(response);
                    paymentResponse.Successful = false;
                    paymentResponse.Transaction_ID = authorityStr;
                }
            }
            catch (Exception err)
            {
                paymentResponse.ResponseMessage = err.Message;
                paymentResponse.ResponseCode = int.Parse(response);
                paymentResponse.Successful = false;
                paymentResponse.Transaction_ID = authorityStr;

            }
            return paymentResponse;
        }

        #endregion

        private string GetReturnPageUrl(Page sourcePage, int Order_ID)
        {
            string domainName =
                HttpContext.Current.Request.Url.AbsoluteUri.Remove(
                    HttpContext.Current.Request.Url.AbsoluteUri.IndexOf(HttpContext.Current.Request.Url.AbsolutePath));
            string pageURL = sourcePage.ResolveUrl("~/ProcessOnlinePayment.aspx") + "?OID=" + Order_ID;
            return domainName + pageURL;
        }
    }

    public class PaymentResponse
    {
        public int ResponseCode;
        public string ResponseMessage;
        public bool Successful;
        public string Transaction_ID;
    }

}
