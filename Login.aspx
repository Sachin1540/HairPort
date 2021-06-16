<%@ Page Language="C#" MasterPageFile="~/MasterBL.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default2" Title="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <center>
        <table style="color:Black;font-size:small">
		        <tr>
		        <td style="width: 112px; height: 4px; font-size: medium;" valign="top">
		                <b>Email:</b>
		            </td>
		            <td style="height: 4px" valign="top">
		                 <asp:TextBox ID="txtemail" runat="server" Width="170px" MaxLength="30"></asp:TextBox>
                         &nbsp;<asp:RequiredFieldValidator ID="RFVEmail" runat="server" 
                  ErrorMessage="Enter your Email ID." ControlToValidate="txtemail" 
                  Display="None"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="REVEmail" runat="server" 
                  ErrorMessage="Invalid Email ID." ControlToValidate="txtemail" 
                  Display="None" 
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
		            </td>
		        </tr>
		    <tr>
		            <td valign="top" style="font-size: medium">
		                <b>Password:</b>   
		            </td>
		            <td valign="top">
		                <asp:TextBox ID="txtpassword" runat="server" 
                  Width="170px" MaxLength="15" TextMode="Password"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RFVPass" runat="server" 
                  ErrorMessage="Enter your Password." ControlToValidate="txtpassword" 
                  Display="None" EnableViewState="False"></asp:RequiredFieldValidator>
		            </td>
		        </tr>
		        
		        <tr>
		            <td colspan="2">
		                <asp:HyperLink ID="lnkForgotPassword" runat="server" Font-Bold="True" 
                        Font-Underline="True" ForeColor="#0099FF" 
                        NavigateUrl="~/ForgotPassword.aspx" Font-Size="Medium">Forgot your Password?</asp:HyperLink>
		            </td>
		        </tr>
		        
		        <tr>
		            <td colspan="2" align="center" style="height: 18px">
		                <asp:ImageButton ID="btnLogin" runat="server" AlternateText="Login" 
                        Height="58px" ImageUrl="~/images/SignIn.png" Width="128px" 
                        onclick="btnLogin_Click" />
		            </td>
		        </tr>
		        
		        <tr>
		            <td colspan="2" style="font-size: medium">
		                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        HeaderText="Errors in Login" ShowMessageBox="True" ShowSummary="False" />
		            </td>
		        </tr>
		    </table>
		    </center>
    </asp:Content>

