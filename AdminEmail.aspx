<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="AdminEmail.aspx.cs" Inherits="Default2" Title="Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td colspan="3" style="height: 27px">Enter Email below to send Email</td>
        </tr>
        
        <tr>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
      
        <tr>
            <td align="right" style="height: 27px">To:</td>
            <td colspan="2" style="height: 27px">
                <asp:TextBox ID="txtto" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
            <td align="right" style="height: 27px">Subject:</td>
            <td colspan="2" style="height: 27px">
                <asp:TextBox ID="txtsubject" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td align="right" style="height: 94px" valign="top">Message:</td>
            <td colspan="2" style="height: 94px" valign="top">
                <asp:TextBox ID="txtmsg" runat="server" TextMode="MultiLine" Height="85px" 
                    MaxLength="250" Width="200px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="images/Submit.png" 
                    Height="48px" Width="106px" onclick="btnSubmit_Click1" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

