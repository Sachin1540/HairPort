<%@ Page Language="C#" MasterPageFile="~/MasterBL.master" AutoEventWireup="true" CodeFile="VerifyAccount.aspx.cs" Inherits="Default2" Title="Verify Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2><font face="Tempus Sans ITC" color="black" style="font-weight: bold">Congratulations ! </font></h2>Your account is created <br />
    Verify your account by entering <b>verfication</b> number below.<br />
    Check mail for the Verification number.<br /> <br />
    
    <table>
    <tr>
        <td style="width: 173px">
            <b>Verification number : </b>
        </td>
        <td>
            <asp:TextBox ID="txtVerify" runat="server" Width="150px" ></asp:TextBox>
        </td>
        <td style="width: 195px">
            <asp:Label ID="lblverify" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    
    <tr>
        <td colspan="2" align="center" valign="middle">
            <asp:ImageButton ID="btnProceed" runat="server" Height="58px" 
        ImageUrl="~/images/Proceed.png" Width="128px" onclick="btnProceed_Click" />
        </td>
        <td style="width: 195px">
            &nbsp;
        </td>
    </tr>
    
    </table>
    <br />      
        <br /> <br />
    <b>Note:</b><br />If you are not verifying your account your account will not be created.
    <br /><br />
</asp:Content>

