using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop.Customers
{
    public partial class ShowOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dsUserOrders.SelectParameters["UserID"].DefaultValue = User.Identity.Name;

        }

        protected void grdOrders_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName == "DoPayment")
            {
                int OrderID = Convert.ToInt32(e.CommandArgument);

                int UniqueOrderID = DataLayer.PaymentUniqueNumbers.InsertRow(OrderID);

                int Amount = DataLayer.Orders.SelectSubTotal(OrderID);

                BankParsianPayment bpp = new BankParsianPayment();

                bpp.ProcessPayment(this, Amount, UniqueOrderID);
            }
        }
    }
}