<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="OrderHistory.aspx.cs" Inherits="Default2" Title="Order History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center> <asp:ImageButton ID="ImageButton1" runat="server" 
    ImageUrl="~/images/Capture.PNG" onclick="ImageButton1_Click" Visible=false />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" CellSpacing="1" 
        ForeColor="#333333" GridLines="None" 
        >
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </center>

</asp:Content>

