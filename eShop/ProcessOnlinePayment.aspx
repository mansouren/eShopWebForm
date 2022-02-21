<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ProcessOnlinePayment.aspx.cs" Inherits="eShop.ProcessOnlinePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <p>
        پاسخ دروازه پرداخت:
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
    </p>
    <p>
        برای بازگشت به صفحه سفارشات&nbsp;
        <asp:HyperLink ID="hlOrders" runat="server" 
            NavigateUrl="~/Customers/ShowOrders.aspx">اینجا</asp:HyperLink>
&nbsp;را کلیک کنید</p>

</asp:Content>
