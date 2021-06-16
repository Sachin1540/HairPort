<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="Default2" Title="Order List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
        ForeColor="Blue"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1"
        runat="server" Text="Deliver Order" visible="false" 
        onclick="Button1_Click" Font-Bold="True" Font-Size="Large" ForeColor="#0066FF"/>
    <br />
    <br />
<asp:GridView ID="GridView2" runat="server" ForeColor="#333333" 
    GridLines="None" Width="438px" CellPadding="4">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
    GridLines="None" Width="438px" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
                
        <asp:BoundField DataField="Orderid" HeaderText="Orderid" 
            SortExpression="Orderid" />
     
        <asp:BoundField DataField="Booking_Date" HeaderText="Booking_Date" 
            SortExpression="Booking_Date" />
        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
               
                <asp:BoundField DataField="cid" HeaderText="cid" SortExpression="cid" />
                                <asp:BoundField DataField="Address" 
            HeaderText="Address" SortExpression="Address" />


    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:HairPortConnectionString %>" 
    
    
        SelectCommand="SELECT DISTINCT [Orderid], [Booking_Date], [email], [cid], [Address] FROM [Order] WHERE ordstatus='open' ORDER BY [Orderid]">
    <SelectParameters>
        <asp:Parameter DefaultValue="open" Name="ordstatus" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>
    

</center>
</asp:Content>

