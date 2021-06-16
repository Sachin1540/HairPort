<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Default2" Title="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <center>
    <table frame="box" style="color: #000000">
   <tr>
   <td align="left" style="font-weight: bold; height: 25px;" valign="top" 
           class="style8">Customer ID</td>
   <td style="height: 25px" valign="top"><asp:Label ID="lblcid" runat="server" 
           Font-Bold="True" ForeColor="Black"></asp:Label></td>
   </tr>
   
   <tr>
   <td align="left" style="font-weight: bold; height: 22px;" valign="top" 
           class="style8">Order ID</td>
   <td style="height: 22px"><asp:Label ID="lblorderid" runat="server" Font-Bold="True" 
           ForeColor="Black"></asp:Label></td>
   </tr>
   <tr>
   <td align="left" style="font-weight: bold; height: 24px;" valign="top" 
           class="style8">Total Amount</td>
   <td style="height: 24px" valign="top"><asp:Label ID="lbltotalamt" runat="server" 
           ForeColor="Black" Font-Bold="True"></asp:Label></td>
   </tr>
   <tr>
   <td align="left" style="font-weight: bold; height: 27px;" valign="top" 
           class="style9">Mode Of Payment</td>
   <td class="style10" style="height: 27px" valign="top">
       <asp:DropDownList ID="DdlMode" runat="server" AutoPostBack="True" 
           Height="25px" Width="131px">
           <asp:ListItem>Master Card</asp:ListItem>
           <asp:ListItem>VISA</asp:ListItem>
       </asp:DropDownList>
   </td>
   </tr>
   
   <tr>
   <td class="style8">
       <asp:Label ID="lblcardname" runat="server" Text="Card No:" 
           Font-Bold="True" ForeColor="Black"></asp:Label></td>
   <td align="left" valign="middle">
       <asp:TextBox ID="txtn1" runat="server" MaxLength="4" Width="80px" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;<asp:TextBox 
           ID="txtn2" runat="server" MaxLength="4" Width="80px" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;<asp:TextBox 
           ID="txtn3" runat="server" MaxLength="4" Width="80px" onkeypress="return isNumberKey(event)"></asp:TextBox>
       <asp:TextBox ID="txtn4" runat="server" MaxLength="4" Width="80px" onkeypress="return isNumberKey(event)"></asp:TextBox>&nbsp;</td></tr>
       <tr>
        <td>Expiry Date:
        </td>
        <td>
            <asp:DropDownList ID="Ddlmonth" runat="server" Height="25px" Width="64px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList> &nbsp;Month
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="Ddlyear" runat="server" Height="27px">
            </asp:DropDownList> &nbsp;Year
        </td>
       </tr>
     <tr>
     <td colspan="2"><asp:Label ID="lblerror" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td></tr>
   
     
     <tr align="center">
     <td align="center" valign="top">
         <asp:ImageButton ID="BtnBack" runat="server" 
             ImageUrl="~/images/backto cart.png" Width="191px" onclick="BtnBack_Click" 
              />
         
         </td>
         <td align="center">
         <asp:ImageButton ID="btnbook" runat="server"  
             ImageUrl="~/images/book now.png" Width="191px" onclick="btnbook_Click" />
         </td>
     </tr>
     </table></center>
    
    

</asp:Content>

