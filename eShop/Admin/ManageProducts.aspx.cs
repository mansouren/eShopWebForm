using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using apocryph.BitmapManip;
using Microsoft.Security.Application;

namespace eShop.Admin
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);

                ViewState["ProductID"] = ProductID;
                ViewState["EditMode"] = "Edit";

                DataTable dtProducts = DataLayer.Products.SelectRow(ProductID).Tables["Products"];
                if (dtProducts.Rows.Count != 0)
                {
                    DataRow drProduct = dtProducts.Rows[0];

                    txtProductTitle.Text = drProduct["ProductTitle"].ToString();
                    txtPrice.Value = Convert.ToDouble(drProduct["ProductPrice"]);
                    txtDescription.Text = drProduct["ProductDescription"].ToString();

                    ddlProductGroup.SelectedValue = drProduct["ProductGroupID"].ToString();

                    ViewState["ProductCurrentImageUrl"] = drProduct["ProductImageUrl"].ToString();

                    mvProducts.SetActiveView(vwEdit);
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvProducts.SetActiveView(vwList);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ViewState["EditMode"] = "Insert";

            txtProductTitle.Text = string.Empty;

            txtPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;

            ddlProductGroup.SelectedIndex = -1;

            ViewState["ProductCurrentImageUrl"] = string.Empty;

            mvProducts.SetActiveView(vwEdit);
        }

        protected void cvUploadedFileSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
          //  args.IsValid = fuProuctGroupImageUrl.PostedFile.ContentLength <= 70000;
            args.IsValid = true;
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
                            if (fuProuctImageUrl.HasFile)
                            {
                                string OriginalExtension = Path.GetExtension(fuProuctImageUrl.PostedFile.FileName);
                                string NewFilename = Guid.NewGuid().ToString();
                                string RelativeFilename = string.Format("~/Uploads/Products/{0}{1}", NewFilename, OriginalExtension);
                                string PhysicalFilename = Server.MapPath(RelativeFilename);
                                fuProuctImageUrl.PostedFile.SaveAs(PhysicalFilename);
                                CreateThumbnail(PhysicalFilename);

                                ViewState["ProductCurrentImageUrl"] = RelativeFilename;
                            }
                            DataLayer.Products.InsertRow(
                                Convert.ToInt32(ddlProductGroup.SelectedValue),
                                txtProductTitle.Text,
                                (int)txtPrice.Value,
                                ViewState["ProductCurrentImageUrl"].ToString(),
                                txtDescription.Text
                                );

                            grdProducts.DataBind();
                            mvProducts.SetActiveView(vwList);

                            break;
                        }
                    case "Edit":
                        {
                            int ProductID = Convert.ToInt32(ViewState["ProductID"]);

                            if (fuProuctImageUrl.PostedFile.ContentLength != 0)
                            {
                                string OriginalExtension = Path.GetExtension(fuProuctImageUrl.PostedFile.FileName);
                                string NewFilename = Guid.NewGuid().ToString();
                                string RelativeFilename = string.Format("~/Uploads/Products/{0}{1}", NewFilename, OriginalExtension);
                                string PhysicalFilename = Server.MapPath(RelativeFilename);
                                fuProuctImageUrl.PostedFile.SaveAs(PhysicalFilename);
                                CreateThumbnail(PhysicalFilename);

                                if (ViewState["ProductCurrentImageUrl"].ToString() != string.Empty)
                                {
                                    File.Delete(Server.MapPath(ViewState["ProductCurrentImageUrl"].ToString()));
                                    File.Delete(Server.MapPath(GetThumbFilename(ViewState["ProductCurrentImageUrl"].ToString())));
                                }
                                ViewState["ProductCurrentImageUrl"] = RelativeFilename;
                            }

                            DataLayer.Products.UpdateRow(
                                ProductID,
                                Convert.ToInt32(ddlProductGroup.SelectedValue),
                                txtProductTitle.Text,
                                (int)txtPrice.Value,
                                ViewState["ProductCurrentImageUrl"].ToString(),
                                txtDescription.Text
                                );

                            grdProducts.DataBind();
                            mvProducts.SetActiveView(vwList);

                            break;
                        }
                }
            }
        }
        
        private string imageUploadPath = "~/Uploads/Products/";

        private string CreateThumbnail(string OriginalFileFullPath)
        {
            string filename = string.Empty;

            if (File.Exists(OriginalFileFullPath))
            {
                System.Drawing.Image img = Bitmap.FromFile(OriginalFileFullPath);
                Bitmap bmp = new Bitmap(img);

                bmp = BitmapManipulator.ThumbnailBitmap(bmp, 100, 100);

                string thumbfilename = Path.GetFileNameWithoutExtension(OriginalFileFullPath) + "_Thumb" + Path.GetExtension(OriginalFileFullPath);

                string thumb_file_relative_path = imageUploadPath + thumbfilename;

                bmp.Save(Server.MapPath(thumb_file_relative_path), System.Drawing.Imaging.ImageFormat.Jpeg);

                filename = thumb_file_relative_path;
            }
            return filename;
        }

        protected string GetThumbFilename(string OriginalFilename)
        {
            string thumbfilename =
                    Path.GetFileNameWithoutExtension(OriginalFilename)
                    + "_Thumb"
                    + Path.GetExtension(OriginalFilename);

            return imageUploadPath + thumbfilename;
        }

    }
}