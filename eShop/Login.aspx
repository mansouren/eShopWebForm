<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="eShop.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h3>
        ورود به سایت</h3>
    <table class="style2">
        <tr>
            <td>
                نام کاربر:
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    Display="Dynamic" ErrorMessage="لطفا نام کاربر را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                کلمه عبور:
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="لطفا کلمه عبور را وارد کنید" 
                    ForeColor="Red" Display="Dynamic">→</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvLogin" runat="server" Display="Dynamic" 
                    ErrorMessage="نام کاربر یا کلمه عبور صحیح نیست" ForeColor="Red" 
                    onservervalidate="cvLogin_ServerValidate">→</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:CheckBox ID="chkRember" runat="server" Text="مشخصات من را به خاطر بسپار" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                
                <asp:Button ID="btnLogin" runat="server" Text="ورود به سیستم" 
                    onclick="btnLogin_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="vsLogin" runat="server" ForeColor="Red" />
</asp:Content>
