using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShop.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                ViewState["UserID"] = UserID;
                ViewState["EditMode"] = "Edit";

                DataTable dtUsers = DataLayer.Users.SelectRow(UserID).Tables["Users"];
                if (dtUsers.Rows.Count != 0)
                {
                    DataRow drUser = dtUsers.Rows[0];

                    txtUsername.Text = drUser["Username"].ToString();
                    txtPassword.Text = drUser["Password"].ToString();
                    txtFullName.Text = drUser["Fullname"].ToString();
                    txtPhone.Text = drUser["Phone"].ToString();
                    txtEmail.Text = drUser["Email"].ToString();
                    txtAddress.Text = drUser["Address"].ToString();

                    ddlRoles.SelectedValue = drUser["RoleID"].ToString();

                   mvUsers.SetActiveView(vwEdit);
                }
                
            }
            if (e.CommandName == "2Arguments")
            {
                string[] args = e.CommandArgument.ToString().Split(new char[] {','});
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string EditMode = ViewState["EditMode"].ToString();
                switch (EditMode)
                {
                    case "Insert":
                        {
                            DataLayer.Users.InsertRow(
                                Convert.ToInt32(ddlRoles.SelectedValue),
                                txtUsername.Text,
                                txtPassword.Text,
                                txtFullName.Text,
                                txtEmail.Text,
                                txtPhone.Text,
                                txtAddress.Text);

                            grdUsers.DataBind();
                            mvUsers.SetActiveView(vwList);

                            break;
                        }
                    case "Edit":
                        {
                            int UserID = Convert.ToInt32(ViewState["UserID"]);
                            DataLayer.Users.UpdateRow(
                                UserID,
                                Convert.ToInt32(ddlRoles.SelectedValue),
                                txtUsername.Text,
                                txtPassword.Text,
                                txtFullName.Text,
                                txtEmail.Text,
                                txtPhone.Text,
                                txtAddress.Text);

                            grdUsers.DataBind();
                            mvUsers.SetActiveView(vwList);

                            break;
                        }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvUsers.SetActiveView(vwList);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ViewState["EditMode"] = "Insert";

            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;

            ddlRoles.SelectedIndex = -1;

            mvUsers.SetActiveView(vwEdit);
        }
    }
}