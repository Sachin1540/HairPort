<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Default2" Title="Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center> <table frame="box" style="color: #000000">
     <tr>
        <td style="width: 127px">
            <asp:Label ID="Label1" runat="server" Text="Select Category" ForeColor="Black"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DdlBrand" runat="server" Width="182px" 
                onselectedindexchanged="DdlBrand_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem>All</asp:ListItem>
 <asp:ListItem>Maybelline</asp:ListItem>
                <asp:ListItem>Lakme</asp:ListItem>
                <asp:ListItem>MAC</asp:ListItem>
                <asp:ListItem>Loreal</asp:ListItem>
                <asp:ListItem>Kaya</asp:ListItem>
                <asp:ListItem>Nivea</asp:ListItem>
                <asp:ListItem>Revolution</asp:ListItem>
                <asp:ListItem>Colorbar</asp:ListItem>
                <asp:ListItem>Estee Lauder</asp:ListItem>
                <asp:ListItem>Tresemme</asp:ListItem>
                <asp:ListItem>Braun</asp:ListItem>
                <asp:ListItem>Vaseline</asp:ListItem>
                <asp:ListItem>The Face Shop</asp:ListItem>
                
                <asp:ListItem>Other</asp:ListItem>
          
                    
            </asp:DropDownList>
        </td>  
     </tr>
     
     <tr>
        <td colspan="2">&nbsp;
            
        </td>
     </tr>
     
     <tr>
        <td align="left" colspan="2">
            <asp:Label ID="lbldisply" runat="server" Text=""></asp:Label>
        </td>
     </tr>
     </table>  </center> 
  

</asp:Content>

