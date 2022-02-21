using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                DataLayer.Users.InsertRow(
                    2, // مشتری
                    txtUsername.Text,
                    txtPassword.Text,
                    txtFullName.Text,
                    txtEmail.Text,
                    txtPhone.Text,
                    txtAddress.Text
                    );
                mvRegister.SetActiveView(vwMessage);
            }
        }
    }
}