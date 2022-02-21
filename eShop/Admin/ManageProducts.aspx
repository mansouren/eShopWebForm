<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true"
    CodeBehind="ManageProducts.aspx.cs" Inherits="eShop.Admin.ManageProducts" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 400px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:MultiView ID="mvProducts" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnAddNew" runat="server" Text="افزودن صفحه جدید" OnClick="btnAddNew_Click" />
            <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="ProductID" DataSourceID="dsProducts" ForeColor="#333333" GridLines="None"
                Width="500px" OnRowCommand="grdProducts_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ProductTitle" HeaderText="عنوان محصول" SortExpression="ProductTitle" />
                    <asp:BoundField DataField="ProductGroupTitle" HeaderText="گروه محصول" SortExpression="ProductGroupTitle" />
                    <asp:BoundField DataField="ProductPrice" HeaderText="قیمت" SortExpression="ProductPrice" />
                    <asp:TemplateField HeaderText="تصویر گروه">
                        <ItemTemplate>
                            <asp:Image ID="imgIcon" runat="server" ImageUrl='<%# GetThumbFilename(Eval("ProductImageUrl").ToString()) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="دستورات">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("ProductID") %>'
                                CommandName="DoEdit">ویرایش</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:eShop_16 %>"
                SelectCommand="sp_Products_SelectAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </asp:View>
        <asp:View ID="vwEdit" runat="server">
            <table class="style2">
                <tr>
                    <td>
                        عنوان محصول:
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProductTitle" runat="server" ControlToValidate="txtProductTitle"
                            Display="Dynamic" ErrorMessage="لطفا عنوان محصول را وارد کنید" 
                            ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        گروه محصول:</td>
                    <td>
                        <asp:DropDownList ID="ddlProductGroup" runat="server" 
                            DataSourceID="dsProductGroups" DataTextField="ProductGroupTitle" 
                            DataValueField="ProductGroupID" Width="128px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsProductGroups" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:eShop_16 %>" 
                            SelectCommand="sp_ProductGroups_SelectAll" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        تصویر محصول:
                    </td>
                    <td>
                        <asp:FileUpload ID="fuProuctImageUrl" runat="server" Width="250px" />
                        <asp:CustomValidator ID="cvUploadedFileSize" runat="server" ErrorMessage="سایز فایل Upload شده نمی تواند بیش از 100 کیلوبایت باشد"
                            ForeColor="Red" OnServerValidate="cvUploadedFileSize_ServerValidate">→</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        قیمت:</td>
                    <td>
                        <telerik:RadNumericTextBox ID="txtPrice" Runat="server" Width="128px" 
                            Culture="fa-IR" DataType="System.Int32">
                            <NumberFormat AllowRounding="False" DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" 
                            ControlToValidate="txtPrice" Display="Dynamic" 
                            ErrorMessage="لطفا قیمت را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        شرح محصول:</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Height="150px" 
                            TextMode="MultiLine" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" 
                            ControlToValidate="txtDescription" Display="Dynamic" 
                            ErrorMessage="لطفا شرح محصول را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="ثبت" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click"
                            Text="انصراف" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vsProducts" runat="server" ForeColor="Red" />
            <script type="text/javascript">
                tinyMCE.init({
                    // General options
                    mode: "textareas",
                    theme: "advanced",
                    plugins: "autolink,lists,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",

                    // Theme options
                    theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
                    theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
                    theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,ltr,rtl,|,fullscreen",
                    theme_advanced_buttons4: "insertlayer,moveforward,movebackward,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
                    theme_advanced_toolbar_location: "top",
                    theme_advanced_toolbar_align: "left",
                    theme_advanced_statusbar_location: "bottom",
                    theme_advanced_resizing: true,

                    // Skin options
                    skin: "o2k7",
                    skin_variant: "silver",

                    // Example content CSS (should be your site CSS)
                    content_css: "css/example.css",

                    // Drop lists for link/image/media/template dialogs
                    template_external_list_url: "js/template_list.js",
                    external_link_list_url: "js/link_list.js",
                    external_image_list_url: "js/image_list.js",
                    media_external_list_url: "js/media_list.js",

                    // Replace values for the template plugin
                    template_replace_values: {
                        username: "Some User",
                        staffid: "991234"
                    }
                });
            </script>
        </asp:View>
    </asp:MultiView>
</asp:Content>
