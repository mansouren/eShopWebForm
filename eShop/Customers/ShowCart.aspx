<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="ShowCart.aspx.cs" Inherits="eShop.Customers.ShowCart" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:SqlDataSource ID="dsUserOrders" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eShop_16 %>" 
        SelectCommand="sp_Orders_SelectAllByUser" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="UserID" Type="Int32" />
            <asp:Parameter DefaultValue="False" Name="Finalized" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsOrderDetails" runat="server" 
        ConnectionString="<%$ ConnectionStrings:eShop_16 %>" 
        SelectCommand="sp_OrderDetails_SelectAllByOrder" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="OrderID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <telerik:RadGrid ID="grdOrders" runat="server" AutoGenerateColumns="False" 
        CellSpacing="0" DataSourceID="dsUserOrders" GridLines="None" 
        onitemcommand="grdOrders_ItemCommand" Skin="Outlook">
<MasterTableView datakeynames="OrderID" datasourceid="dsUserOrders" dir="RTL">
    <DetailTables>
        <telerik:GridTableView runat="server" DataKeyNames="OrderDetailID" 
            DataSourceID="dsOrderDetails" Dir="RTL">
            <ParentTableRelation>
                <telerik:GridRelationFields DetailKeyField="OrderID" MasterKeyField="OrderID" />
            </ParentTableRelation>
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="ProductTitle" 
                    FilterControlAltText="Filter ProductTitle column" HeaderText="نام محصول" 
                    SortExpression="ProductTitle" UniqueName="ProductTitle">
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ProductCount" 
                    FilterControlAltText="Filter ProductCount column" HeaderText="تعداد" 
                    SortExpression="ProductCount" UniqueName="ProductCount">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ProductPrice" 
                    DataFormatString="{0:#,0 ریال}" 
                    FilterControlAltText="Filter ProductPrice column" HeaderText="قیمت" 
                    SortExpression="ProductPrice" UniqueName="ProductPrice">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Total" DataFormatString="{0:#,0 ریال}" 
                    FilterControlAltText="Filter Total column" HeaderText="جمع" 
                    SortExpression="Total" UniqueName="Total">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter Commands column" 
                    HeaderText="دستورات" UniqueName="Commands">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDeleteDetail" runat="server" 
                            CommandArgument='<%# Eval("OrderDetailID") %>' CommandName="DeleteDetail">حذف این ردیف</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </telerik:GridTableView>
    </DetailTables>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
        visible="True">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="OrderID" DataType="System.Int32" 
            FilterControlAltText="Filter OrderID column" HeaderText="شماره فاکتور" 
            ReadOnly="True" SortExpression="OrderID" UniqueName="OrderID">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="OrderDate" 
            DataFormatString="{0:yyyy/MM/dd}" DataType="System.DateTime" 
            FilterControlAltText="Filter OrderDate column" HeaderText="تاریخ" 
            SortExpression="OrderDate" UniqueName="OrderDate">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="SubTotal" DataFormatString="{0:#,0 ریال}" 
            DataType="System.Int32" FilterControlAltText="Filter SubTotal column" 
            HeaderText="جمع کل" ReadOnly="True" SortExpression="SubTotal" 
            UniqueName="SubTotal">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            HeaderText="دستورات" UniqueName="TemplateColumn">
            <ItemTemplate>
                <asp:LinkButton ID="lbFinalize" runat="server" 
                    CommandArgument='<%# Eval("OrderID") %>' CommandName="Finalize">بستن فاکتور و تسویه حساب</asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
    </telerik:RadGrid>
</asp:Content>
