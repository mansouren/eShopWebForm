using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop.Customers
{
    public partial class ShowCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dsUserOrders.SelectParameters["UserID"].DefaultValue = User.Identity.Name;

        }

        protected void grdOrders_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName == "Finalize")
            {
                int OrderID = Convert.ToInt32(e.CommandArgument);

                DataLayer.Orders.Finalize(OrderID);

                Response.Redirect("~/Customers/ShowOrders.aspx");
            }

            if(e.CommandName == "DeleteDetail")
            {
                int OrderDetailID = Convert.ToInt32(e.CommandArgument);

                DataLayer.OrderDetails.DeleteRow(OrderDetailID);
                e.Item.OwnerTableView.DataBind();
            }
        }
    }
}