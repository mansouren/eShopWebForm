using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop
{
    public partial class ProcessOnlinePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OID"]))
            {
                int UniqeOrderID = Convert.ToInt32(Request.QueryString["OID"]);
                int OrderID =
                    Convert.ToInt32(
                        DataLayer.PaymentUniqueNumbers.SelectRow(UniqeOrderID).Tables["PaymentUniqueNumbers"].Rows[0][
                            "OrderID"]);

                int Amount = DataLayer.Orders.SelectSubTotal(OrderID);

                BankParsianPayment bpp = new BankParsianPayment();

                PaymentResponse pr = bpp.ProcessResponse(this, Amount, UniqeOrderID);


                DataLayer.PaymentLogs.InsertRow(
                                                OrderID,
                                                pr.Transaction_ID,
                                                pr.ResponseCode.ToString(),
                                                pr.ResponseMessage,
                                                pr.Successful, 
                                                DateTime.Now);

                lblMessage.Text = pr.ResponseMessage;
            }
            else
            {

                lblMessage.Text = "پارامتر ورودی صفحه نامشخص است";
            }
        }
    }
}