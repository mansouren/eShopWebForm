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
    public partial class ManageProductGroups : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdProductGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                int ProductGroupID = Convert.ToInt32(e.CommandArgument);

                ViewState["ProductGroupID"] = ProductGroupID;
                ViewState["EditMode"] = "Edit";

                DataTable dtProductGroups = DataLayer.ProductGroups.SelectRow(ProductGroupID).Tables["ProductGroups"];
                if (dtProductGroups.Rows.Count != 0)
                {
                    DataRow drProductGroup = dtProductGroups.Rows[0];

                    txtProductGroupTitle.Text = drProductGroup["ProductGroupTitle"].ToString();
                    ViewState["ProductGroupCurrentImageUrl"] = drProductGroup["ProductGroupImageUrl"].ToString();

                    mvProductGroups.SetActiveView(vwEdit);
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvProductGroups.SetActiveView(vwList);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ViewState["EditMode"] = "Insert";

            txtProductGroupTitle.Text = string.Empty;
            ViewState["ProductGroupCurrentImageUrl"] = string.Empty;

            mvProductGroups.SetActiveView(vwEdit);
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
                            if (fuProuctGroupImageUrl.HasFile)
                            {
                                string OriginalExtension = Path.GetExtension(fuProuctGroupImageUrl.PostedFile.FileName);
                                string NewFilename = Guid.NewGuid().ToString();
                                string RelativeFilename = string.Format("~/Uploads/ProductGroups/{0}{1}", NewFilename, OriginalExtension);
                                string PhysicalFilename = Server.MapPath(RelativeFilename);
                                fuProuctGroupImageUrl.PostedFile.SaveAs(PhysicalFilename);
                                CreateThumbnail(PhysicalFilename);

                                ViewState["ProductGroupCurrentImageUrl"] = RelativeFilename;
                            }
                            int pgid = DataLayer.ProductGroups.InsertRow(
                                txtProductGroupTitle.Text,
                                ViewState["ProductGroupCurrentImageUrl"].ToString()
                                );

                            grdProductGroups.DataBind();
                            mvProductGroups.SetActiveView(vwList);

                            break;
                        }
                    case "Edit":
                        {
                            int ProductGroupID = Convert.ToInt32(ViewState["ProductGroupID"]);

                            if (fuProuctGroupImageUrl.PostedFile.ContentLength != 0)
                            {
                                string OriginalExtension = Path.GetExtension(fuProuctGroupImageUrl.PostedFile.FileName);
                                string NewFilename = Guid.NewGuid().ToString();
                                string RelativeFilename = string.Format("~/Uploads/ProductGroups/{0}{1}", NewFilename, OriginalExtension);
                                string PhysicalFilename = Server.MapPath(RelativeFilename);
                                fuProuctGroupImageUrl.PostedFile.SaveAs(PhysicalFilename);
                                CreateThumbnail(PhysicalFilename);

                                if (ViewState["ProductGroupCurrentImageUrl"].ToString() != string.Empty)
                                {
                                    File.Delete(Server.MapPath(ViewState["ProductGroupCurrentImageUrl"].ToString()));
                                    File.Delete(Server.MapPath(GetThumbFilename(ViewState["ProductGroupCurrentImageUrl"].ToString())));
                                }
                                ViewState["ProductGroupCurrentImageUrl"] = RelativeFilename;
                            }

                            DataLayer.ProductGroups.UpdateRow(
                                ProductGroupID,
                                txtProductGroupTitle.Text,
                                ViewState["ProductGroupCurrentImageUrl"].ToString()
                                );

                            grdProductGroups.DataBind();
                            mvProductGroups.SetActiveView(vwList);

                            break;
                        }
                }
            }
        }
        private string imageUploadPath = "~/Uploads/ProductGroups/";

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