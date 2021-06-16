<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="AdminChangePassword.aspx.cs" Inherits="Default2" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <center style="font-weight: bold">
    <table style="height: 83px; width: 600px">
    
    <tr align="left">
    <td class="style4" style="width: 204px; font-weight: bold; height: 25px;"><asp:Label ID="Label1" 
            runat="server" Text="Old Password" ForeColor="Black"></asp:Label></td>
    <td class="style2" valign="top" style="height: 25px">
        <asp:TextBox ID="txtOldPass" runat="server" Width="170px" 
            TextMode="Password"></asp:TextBox></td>
    <td style="height: 25px">
        <asp:RequiredFieldValidator ID="RfvOldPass" runat="server" 
            ControlToValidate="txtOldPass" 
          ErrorMessage="Enter Your Old Password"></asp:RequiredFieldValidator></td>
    </tr>
    
    <tr align="left">
    <td class="style4" style="width: 204px; height: 24px; font-weight: bold;">
        <asp:Label ID="Label2" runat="server" Text="New Password" ForeColor="Black"></asp:Label></td>
    <td class="style2" style="height: 24px" valign="top"><asp:TextBox ID="txtNewPass" 
            runat="server" Width="170px" 
            TextMode="Password"></asp:TextBox></td>
    <td style="height: 24px">
        <asp:RequiredFieldValidator ID="RfvNewPass" runat="server" 
            ControlToValidate="txtNewPass" 
            ErrorMessage="Enter Your New Password"></asp:RequiredFieldValidator>
              <asp:CustomValidator ID="CVPass" runat="server" 
                ClientValidationFunction="CVPass_ServerValidate" 
                ControlToValidate="txtNewPass" 
                ErrorMessage="Password Must Be Of 6 Characters Or More" 
                onservervalidate="CVPass_ServerValidate"></asp:CustomValidator>
              </td>
    </tr>
    
    <tr align="left">
    <td class="style4" style="width: 204px; font-weight: bold;"><asp:Label ID="Label3" 
            runat="server" Text="Re-Enter Password" ForeColor="Black"></asp:Label></td>
    <td class="style2" valign="top">
        <asp:TextBox ID="txtRetypePass" runat="server" Width="170px" 
            TextMode="Password"></asp:TextBox></td>
    <td> <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtNewPass" ControlToValidate="txtRetypePass" 
            ErrorMessage="Password Does Not Match."></asp:CompareValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtRetypePass" Display="Dynamic" 
            ErrorMessage="Re-Type Password"></asp:RequiredFieldValidator>
        </td>
    </tr>
    </table>
    
    <table style="height: 89px; width: 600px">
    <tr align="center">
    <td style="height: 59px; width: 379px">
        <asp:ImageButton ID="ImgChangePass" runat="server" Height="55px" 
            Width="125px" ImageAlign="Middle" ImageUrl="~/images/Submit.png" 
            onclick="ImgChangePass_Click" /></td>
    <td align="Left" style="height: 59px"><asp:Label ID="lblPassword" runat="server" ForeColor="#33CC33" 
            Text="Password Changed Successfully" Visible="False" Font-Bold="True"></asp:Label></td>       
    </tr>
    <tr align="left">
    <td colspan="3"><asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    </table>
    </center>
    

</asp:Content>

