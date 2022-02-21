using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

namespace eShop.Admin
{
    public partial class ManagePages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdPages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                int PageID = Convert.ToInt32(e.CommandArgument);

                ViewState["PageID"] = PageID;
                ViewState["EditMode"] = "Edit";

                DataTable dtPages = DataLayer.Pages.SelectRow(PageID).Tables["Pages"];
                if (dtPages.Rows.Count != 0)
                {
                    DataRow drPage = dtPages.Rows[0];

                    txtPageTitle.Text = drPage["PageTitle"].ToString();
                    txtPageText.Text = drPage["PageText"].ToString();

                    ddlPageGroup.SelectedValue = drPage["PageGroupID"].ToString();

                   mvPages.SetActiveView(vwEdit);
                }
                
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
                            DataLayer.Pages.InsertRow(
                                Convert.ToInt32(ddlPageGroup.SelectedValue),
                                Sanitizer.GetSafeHtmlFragment(txtPageTitle.Text),
                                txtPageText.Text,
                                DateTime.Now);

                            grdPages.DataBind();
                            mvPages.SetActiveView(vwList);

                            break;
                        }
                    case "Edit":
                        {
                            int PageID = Convert.ToInt32(ViewState["PageID"]);
                            DataLayer.Pages.UpdateRow(
                                PageID,
                                Convert.ToInt32(ddlPageGroup.SelectedValue),
                                Sanitizer.GetSafeHtmlFragment(txtPageTitle.Text),
                                txtPageText.Text,
                                DateTime.Now);

                            grdPages.DataBind();
                            mvPages.SetActiveView(vwList);

                            break;
                        }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvPages.SetActiveView(vwList);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ViewState["EditMode"] = "Insert";

            txtPageTitle.Text = string.Empty;
            txtPageText.Text = string.Empty;
            
            ddlPageGroup.SelectedIndex = -1;

            mvPages.SetActiveView(vwEdit);
        }
    }
}