<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Default2" Title="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <table>
        <tr>
            <td align="center">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/noitem.jpg" onclick="ImageButton1_Click" 
                    />
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" CellSpacing="1" 
                    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" 
                            SelectImageUrl="~/images/button_cancel.png" SelectText="Delete" 
                            ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
        <td align="center">
            <asp:Label ID="lbltotal" runat="server" Font-Underline="True" 
                ForeColor="Black" Font-Size="Medium"></asp:Label>
            <asp:Label ID="lbltotalamt" runat="server" Font-Underline="True" 
                ForeColor="Black" Font-Size="Medium"></asp:Label>
        </td>
      </tr><tr>
            <td align="center"><br />
                <asp:ImageButton ID="btnPayment" runat="server"  
                    ImageUrl="~/images/payment.png"  onclick="btnPayment_Click" 
                    Visible="False" />
          </td>
        </tr><tr><td align="center">                <asp:ImageButton ID="ImageButton2" runat="server"  
                    ImageUrl="~/images/contshop.png"  onclick="btnshop_Click" 
                    Visible="False" />
</td></tr>
   
   </table>
   
    
    
</asp:Content>


