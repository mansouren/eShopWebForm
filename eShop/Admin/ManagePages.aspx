<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true"
    CodeBehind="ManagePages.aspx.cs" Inherits="eShop.Admin.ManagePages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 400px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    
    <asp:MultiView ID="mvPages" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwList" runat="server">
            <asp:Button ID="btnAddNew" runat="server" Text="افزودن صفحه جدید" OnClick="btnAddNew_Click" />
            <asp:GridView ID="grdPages" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="PageID" DataSourceID="dsPages" ForeColor="#333333" GridLines="None"
                Width="500px" OnRowCommand="grdPages_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="PageTitle" HeaderText="عنوان صفحه" SortExpression="PageTitle" />
                    <asp:BoundField DataField="PageGroupTitle" HeaderText="گروه صفحه" SortExpression="PageGroupTitle" />
                    <asp:BoundField DataField="PageDate" HeaderText="تاریخ ایجاد" SortExpression="PageDate"
                        DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:TemplateField HeaderText="دستورات">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("PageID") %>'
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
            <asp:SqlDataSource ID="dsPages" runat="server" ConnectionString="<%$ ConnectionStrings:eShop_16 %>"
                SelectCommand="sp_Pages_SelectAll" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </asp:View>
        <asp:View ID="vwEdit" runat="server">
            <table class="style2">
                <tr>
                    <td>
                        گروه صفحه:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPageGroup" runat="server" DataSourceID="dsPageGroups" DataTextField="PageGroupTitle"
                            DataValueField="PageGroupID" Width="128px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsPageGroups" runat="server" ConnectionString="<%$ ConnectionStrings:eShop_16 %>"
                            SelectCommand="sp_PageGroups_SelectAll" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        عنوان صفحه:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPageTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPageTitle" runat="server" ControlToValidate="txtPageTitle"
                            Display="Dynamic" ErrorMessage="لطفا عنوان صفحه را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        متن صفحه:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPageText" runat="server" Height="200px" TextMode="MultiLine"
                            Width="400px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPageText" runat="server" ControlToValidate="txtPageText"
                            Display="Dynamic" ErrorMessage="لطفا متن صفحه را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
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
            <asp:ValidationSummary ID="vsPages" runat="server" ForeColor="Red" />
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
