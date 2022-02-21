using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace eShop
{
    public partial class Root : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dsCartContents.SelectParameters["UserID"].DefaultValue = HttpContext.Current.User.Identity.Name;
            


            lblDateTime.Text = DateTime.Now.ToString("تاریخ yyyy/MM/dd و زمان HH:mm:ss");
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (Session["Fullname"] == null)
                {
                    DataTable dtUsers = DataLayer.Users.SelectRow(Convert.ToInt32(HttpContext.Current.User.Identity.Name)).Tables["Users"];
                    if (dtUsers.Rows.Count != 0)
                    {
                        DataRow drUser = dtUsers.Rows[0];

                        Session["Fullname"] = drUser["Fullname"].ToString();

                        lblUsername.Text = drUser["Fullname"].ToString();
                    }
                }
                else
                {
                    lblUsername.Text = Session["Fullname"].ToString();
                }
            }
            else
            {
                lblUsername.Text = "بازدید کننده";
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}