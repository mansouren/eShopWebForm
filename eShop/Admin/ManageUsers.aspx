<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="eShop.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style2
        {
            width: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:MultiView ID="mvUsers" runat="server" ActiveViewIndex="0">        
        <asp:View ID="vwList" runat="server">
        <asp:Button ID="btnAddNew" runat="server" Text="افزودن کاربر جدید" 
                onclick="btnAddNew_Click" />
            <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="UserID" DataSourceID="dsUsers" 
                ForeColor="#333333" GridLines="None" Width="700px" 
                onrowcommand="grdUsers_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="شناسه کاربر" 
                        SortExpression="Username" />
                    <asp:BoundField DataField="RoleTitle" HeaderText="نوع کاربر" 
                        SortExpression="RoleTitle" />
                    <asp:BoundField DataField="FullName" HeaderText="نام و نام خانوادگی" 
                        SortExpression="FullName" />
                    <asp:BoundField DataField="Email" HeaderText="ایمیل" SortExpression="Email" />
                    <asp:BoundField DataField="Phone" HeaderText="شماره تماس" 
                        SortExpression="Phone" />
                    <asp:TemplateField HeaderText="دستورات">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" 
                                CommandArgument='<%# Eval("UserID") %>' 
                                CommandName="DoEdit">ویرایش</asp:LinkButton>
                            
                            <%--&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                                CommandArgument='<%# string.Format("{0},{1}",Eval("RoleID"),Eval("RoleName")) %>' 
                                CommandName="2Arguments">یکی بخر، 2 تا ببر</asp:LinkButton>--%>
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
            <asp:SqlDataSource ID="dsUsers" runat="server" 
                ConnectionString="<%$ ConnectionStrings:eShop_16 %>" 
                SelectCommand="sp_Users_SelectAll" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
        </asp:View>
        <asp:View ID="vwEdit" runat="server">
            <table class="style2">
                <tr>
                    <td>
                        نوع کاربر:</td>
                    <td>
                        <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="dsRoles" 
                            DataTextField="RoleTitle" DataValueField="RoleID" Width="128px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsRoles" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:eShop_16 %>" 
                            SelectCommand="sp_Roles_SelectAll" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        نام کاربر:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                            ControlToValidate="txtUsername" Display="Dynamic" 
                            ErrorMessage="لطفا نام کاربر را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        کلمه عبور:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                            ControlToValidate="txtPassword" Display="Dynamic" 
                            ErrorMessage="لطفا کلمه عبور را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        نام و نام خانوادگی:</td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFullName" runat="server" 
                            ControlToValidate="txtFullName" Display="Dynamic" 
                            ErrorMessage="لطفا نام و نام خانوادگی را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        شماره تماس:</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" 
                            ControlToValidate="txtPhone" Display="Dynamic" 
                            ErrorMessage="لطفا شماره تماس را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        آدرس ایمیل:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                            ControlToValidate="txtPhone" Display="Dynamic" 
                            ErrorMessage="لطفا آدرس ایمیل را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" 
                            ErrorMessage="آدرس ایمیل وارد شده صحیح نیست" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">→</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        آدرس پستی:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                            ControlToValidate="txtAddress" Display="Dynamic" 
                            ErrorMessage="لطفا آدرس پستی را وارد کنید" ForeColor="Red">→</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="ثبت" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                            onclick="btnCancel_Click" Text="انصراف" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vsUsers" runat="server" ForeColor="Red" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
