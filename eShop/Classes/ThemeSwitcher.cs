using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ThemeSwitcher_CS
{
    public class ThemeSwitcher : DropDownList
    {
        // Methods
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ID = "lbThemeSwitcher";
            if (!this.Page.IsPostBack)
            {
                this.AutoPostBack = true;
                if (this.AllowNoTheme)
                {
                    this.Items.Add(new ListItem(this.NoThemeText, "0"));
                }
                if (Directory.Exists(this.Page.MapPath("~/App_Themes")))
                {
                    foreach (string str in Directory.GetDirectories(this.Page.MapPath("~/App_Themes")))
                    {
                        DirectoryInfo info = new DirectoryInfo(str);
                        this.Items.Add(info.Name);
                    }
                }
            }
            this.SelectedIndex = -1;
            if ((this.Page.Theme == null) || (this.Page.Theme == ""))
            {
                this.SelectedIndex = 0;
            }
            else
            {
                ListItem item = this.Items.FindByValue(this.Page.Theme);
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }

        // Properties
        [Description("Allow the user to choose no theme at all."), DefaultValue("False")]
        public bool AllowNoTheme
        {
            get
            {
                object objectValue = RuntimeHelpers.GetObjectValue(this.ViewState["AllowNoTheme"]);
                return ((objectValue != null) && (bool)objectValue);
            }
            set
            {
                this.ViewState["AllowNoTheme"] = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataMember
        {
            get
            {
                return base.DataMember;
            }
            set
            {
                base.DataMember = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataSourceID
        {
            get
            {
                return base.DataSourceID;
            }
            set
            {
                base.DataSourceID = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string DataTextField
        {
            get
            {
                return base.DataTextField;
            }
            set
            {
                base.DataTextField = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataTextFormatString
        {
            get
            {
                return base.DataTextFormatString;
            }
            set
            {
                base.DataTextFormatString = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataValueField
        {
            get
            {
                return base.DataValueField;
            }
            set
            {
                base.DataValueField = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListItemCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        [DefaultValue("none"), Description("Show this text as the first option when AllowNoTheme is true")]
        public string NoThemeText
        {
            get
            {
                object objectValue = RuntimeHelpers.GetObjectValue(this.ViewState["NoThemeText"]);
                if (objectValue != null)
                {
                    return objectValue.ToString();
                }
                return "none";
            }
            set
            {
                this.ViewState["NoThemeText"] = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ListSelectionMode SelectionMode
        {
            get
            {
                return ListSelectionMode.Single;
            }
        }
    }
}
