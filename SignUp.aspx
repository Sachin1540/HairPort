<%@ Page Language="C#" MasterPageFile="~/MasterBL.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="Default2" Title="Sign Up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="color:Black;font-size:small">
            <tr>
                <td style="width: 183px"> <b>Email:</b></td>
                <td style="width: 206px">  <asp:TextBox ID="txtemail" runat="server" Width="170px" MaxLength="30"></asp:TextBox></td>
                <td>  <asp:RequiredFieldValidator ID="RFVEmail" runat="server" 
                  ErrorMessage="Enter your Email ID." ControlToValidate="txtemail" 
                  Display="None"></asp:RequiredFieldValidator>
                  
                  <asp:RegularExpressionValidator ID="REVEmail" runat="server" 
                  ErrorMessage="Invalid Email ID." ControlToValidate="txtemail" 
                  Display="None" 
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  
                  <asp:Label ID="lblemail" runat="server" Font-Bold="False" Font-Size="Small" 
                  ForeColor="Red"></asp:Label></td>
            </tr>
            
            <tr>
                <td style="width: 183px"><b>Password:</b></td>
                <td style="width: 206px">  <asp:TextBox ID="txtpassword" runat="server" 
                  Width="170px" MaxLength="15" TextMode="Password"></asp:TextBox></td>
                <td> <asp:RequiredFieldValidator ID="RFVPass" runat="server" 
                  ErrorMessage="Enter your Password." ControlToValidate="txtpassword" 
                  Display="None" EnableViewState="False"></asp:RequiredFieldValidator>
                
            </tr>
            
            <tr>
                <td style="width: 183px"><b>Re-type Password:</b></td>
                <td style="width: 206px"> <asp:TextBox ID="txtretypepassword" runat="server" 
                  Width="170px" MaxLength="15" TextMode="Password"></asp:TextBox></td>
                <td>   
                  <asp:RequiredFieldValidator ID="RFVRePass" runat="server" 
                  ErrorMessage="Re-Enter your Password." ControlToValidate="txtretypepassword" 
                  Display="None" EnableViewState="False"></asp:RequiredFieldValidator>
                 
                  <asp:CompareValidator ID="CVRePass" runat="server" 
                  ErrorMessage="Password does not Match." ControlToCompare="txtpassword" 
                  ControlToValidate="txtretypepassword" Display="None"></asp:CompareValidator></td>
            </tr>
            
            <tr>
                <td style="width: 183px"><b>Security Question: </b></td>
                <td style="width: 206px"> <asp:DropDownList ID="DdlQuestion" runat="server" Height="18px" Width="172px">
                  <asp:ListItem>Enter your Nick Name?</asp:ListItem>
                  <asp:ListItem>Enter Last 4 digits of your Debit Card?</asp:ListItem>
                  <asp:ListItem>Last hillstaion you visited?</asp:ListItem>
                  <asp:ListItem>Enter your Father born city?</asp:ListItem>
                  <asp:ListItem>Enter your first teacher name?</asp:ListItem>
                  </asp:DropDownList></td>
                <td> <asp:RequiredFieldValidator ID="RFVSec" runat="server" 
                  ControlToValidate="DdlQuestion" Display="None" 
                  ErrorMessage="Select Security Question."></asp:RequiredFieldValidator></td>
            </tr>
            
            <tr>
                <td style="width: 183px"> <b>Security Answer:</b></td>
                <td style="width: 206px"> <asp:TextBox ID="txtans" runat="server" 
                  Width="170px" MaxLength="15"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RFVAns" runat="server" 
                  ControlToValidate="txtans" Display="None" 
                  ErrorMessage="Enter your security Answer."></asp:RequiredFieldValidator></td>
            </tr>
            </table>
            <center>
            <table>
            <tr>
                <td style="width: 183px" align="left">
                <asp:ImageButton ID="btnRegister" runat="server" Height="58px" ImageUrl="~/images/register.png" Width="128px" onclick="btnRegister_Click" />       
               </td><td> <asp:ImageButton ID="btnreset" runat="server" CausesValidation="False" Height="58px" ImageUrl="~/images/reset.png" Width="128px" onclick="btnreset_Click" />      
                </td>
            </tr>
            
            
        </table> 
        </center>               
             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                  HeaderText="Errors in Form" ShowMessageBox="True" ShowSummary="False" />  
		  

</asp:Content>

