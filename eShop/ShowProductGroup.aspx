<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true"
    CodeBehind="ShowProductGroup.aspx.cs" Inherits="eShop.ShowProductGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:SqlDataSource ID="dsProductsByGroups" runat="server" ConnectionString="<%$ ConnectionStrings:eShop_16 %>"
        SelectCommand="sp_Products_SelectAllByGroup" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="ProductGroupID" QueryStringField="ProductGroupID"
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="dlProducts" runat="server" DataKeyField="ProductID" DataSourceID="dsProductsByGroups"
        RepeatColumns="2" RepeatDirection="Horizontal" 
        onitemcommand="dlProducts_ItemCommand">
        <ItemTemplate>
            <h4>
                <asp:Label ID="ProductTitleLabel" runat="server" Text='<%# Eval("ProductTitle") %>' /></h4>
            <br />
            قیمت:
            <asp:Label ID="ProductPriceLabel" runat="server" Text='<%# Eval("ProductPrice") %>' />
            <br />
            <asp:HyperLink ID="hlProductImage" runat="server" CssClass="pimage" NavigateUrl='<%# Eval("ProductImageUrl") %>'>
                <asp:Image ID="ProductImage" runat="server" ImageUrl='<%# GetThumbFilename(Eval("ProductImageUrl").ToString()) %>' />
            </asp:HyperLink>
            <br />
            توضیحات:
            <asp:Label ID="ProductDescriptionLabel" runat="server" Text='<%# Eval("ProductDescription") %>' />
            <br />

            <asp:Button ID="btnAddToBasket" runat="server" Text="افزودن به سبد خرید" 
                CommandName="AddToBasket" 
                CommandArgument='<%# Eval("ProductID") %>'
                Enabled='<%# User.Identity.IsAuthenticated %>'
                ToolTip='<%# User.Identity.IsAuthenticated ? "برای افزودن این کالا به سبد خرید این دکمه را کلیک کنید" : "برای افزودن این کالا به سبد خرید ابتدا میبایست به عنوان کاربر وارد سیستم شوید" %>'
                />

            <br />
        </ItemTemplate>
    </asp:DataList>
    
    <script type="text/javascript">
        $(function () {
            $('.pimage').lightBox();
        });
    </script>
</asp:Content>
