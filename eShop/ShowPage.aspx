<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true"
    CodeBehind="ShowPage.aspx.cs" Inherits="eShop.ShowPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:SqlDataSource ID="dsPage" runat="server" ConnectionString="<%$ ConnectionStrings:eShop_16 %>"
        SelectCommand="sp_Pages_SelectRow" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="PageID" QueryStringField="PageID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DataList ID="dlPage" runat="server" DataKeyField="PageID" DataSourceID="dsPage">
        <ItemTemplate>
            گروه صفحه:
            <asp:Label ID="PageGroupTitleLabel" runat="server" Text='<%# Eval("PageGroupTitle") %>' />
            <br />
            عنوان صفحه:
            <asp:Label ID="PageTitleLabel" runat="server" Text='<%# Eval("PageTitle") %>' />
            <br />
            تاریخ:
            <asp:Label ID="PageDateLabel" runat="server" Text='<%# Eval("PageDate","<span dir=ltr>{0:yyyy/MM/dd}</span>") %>' />
            <br />
            متن صفحه:
            <br />
            <asp:Label ID="PageTextLabel" runat="server" Text='<%# Eval("PageText") %>' />
            <br />
        </ItemTemplate>
    </asp:DataList>
    </asp:Content>
