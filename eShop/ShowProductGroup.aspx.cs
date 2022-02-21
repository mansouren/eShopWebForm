using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop
{
    public partial class ShowProductGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string imageUploadPath = "~/Uploads/Products/";
        
        protected string GetThumbFilename(string OriginalFilename)
        {
            string thumbfilename =
                    Path.GetFileNameWithoutExtension(OriginalFilename)
                    + "_Thumb"
                    + Path.GetExtension(OriginalFilename);

            return imageUploadPath + thumbfilename;
        }

        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToBasket")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);

                DataLayer.Orders.AddProduct(
                    Convert.ToInt32(User.Identity.Name),
                    DateTime.Now,
                    ProductID,
                    1);

                Control ctlCartContents = this.Master.FindControl("lvCartContents").FindControl("grdCartContents");
                if(ctlCartContents != null)
                {
                    GridView grdCartContents = (GridView) ctlCartContents;
                    grdCartContents.DataBind();
                }

            }
        }

        protected bool CanEnableAddToBasketButton()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}