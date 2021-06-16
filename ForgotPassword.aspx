<%@ Page Language="C#" MasterPageFile="~/MasterBL.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Default2" Title="Forgot Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:MultiView ID="MultiForgotyourPass" runat="server" ActiveViewIndex="0">
        <asp:View ID="VSecurityQs" runat="server">
            <center>
                 <table style="width: 685px; height: 183px;">
                    <tr>
                      <td align="left" class="style2" colspan="2" style="font-weight: bold">
                           <asp:Label ID="Label5" runat="server" 
                               Text="Provide your Security Information to retrieve your password" 
                               ForeColor="Red"></asp:Label></td>
                     </tr>
                    <tr>
                        <td align="left" class="style7" style="height: 40px; font-weight: bold;" 
                            valign="top">
                            <asp:Label ID="Label6" runat="server" Text="Email-ID" ForeColor="Black"></asp:Label></td>
                        <td class="style8" style="height: 40px" valign="top">
                            <asp:TextBox ID="txtfemail" runat="server" Width="235px" ></asp:TextBox>
                            <br />
                            <asp:Label ID="lblfemail" runat="server" ForeColor="Red" Height="16px"></asp:Label>
                        </td>
                         <td align="left" class="style9" style="height: 40px">
                            <asp:RegularExpressionValidator ID="RegularExpValidator1" runat="server" 
                                 ErrorMessage="Invalid Email ID" ControlToValidate="txtfemail" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                 Display="None"></asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="RFVEmail" runat="server" 
                                 ControlToValidate="txtfemail" Display="None" 
                                 ErrorMessage="Enter email Id."></asp:RequiredFieldValidator>
                        </td>
                    </tr>
    
    
    <tr>
    <td align="left" class="style6" style="font-weight: bold" valign="top">
        <asp:Label ID="Label3" runat="server" Text="Security Question" 
            ForeColor="Black"></asp:Label></td>
    <td class="style3">
        <asp:DropDownList ID="DdlSecurityQuestion" runat="server" Height="22px" 
            Width="236px">
                  <asp:ListItem>Enter your Nick Name?</asp:ListItem>
                  <asp:ListItem>Enter Last 4 digits of your Debit Card?</asp:ListItem>
                  <asp:ListItem>Last hillstaion you visited?</asp:ListItem>
                  <asp:ListItem>Enter your Father born city?</asp:ListItem>
                  <asp:ListItem>Enter your first teacher name?</asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    
    <tr>
    <td align="left" class="style6" style="font-weight: bold" valign="top">
        <asp:Label ID="Label4" runat="server" Text="Answer" ForeColor="Black"></asp:Label></td>
    <td class="style3">
        <asp:TextBox ID="txtAnswer" runat="server" Width="235px"></asp:TextBox></td>
    <td align="left">
        <asp:RequiredFieldValidator ID="RFVAns" runat="server" 
            ErrorMessage="Enter your security answer." 
            ControlToValidate="txtAnswer" Display="None"></asp:RequiredFieldValidator></td>
    </tr>

    <tr>
    <td colspan="2" align="center" class="style1" style="height: 13px">
        <asp:ImageButton ID="btnSendSec_Question" runat="server" Height="49px" 
            ImageUrl="~/images/Submit.png" Width="114px" 
            onclick="btnSendSec_Question_Click" />
        </td>
            <td align="left" style="height: 13px">
                <asp:Label ID="lblfsend" runat="server" ForeColor="Red" Height="16px"></asp:Label>
        </td>
    </tr>    
    <tr>
    <td colspan="2" align="left">
        <asp:LinkButton ID="lbtnSendEmail" runat="server" 
            CommandName="SwitchViewByIndex" CommandArgument="1" 
            CausesValidation="False" >Click here to Retrieve Password By Email</asp:LinkButton></td>
    </tr>
</table>
</center>
            </asp:View>
            <asp:View ID="VEmail" runat="server">
                <center>
                    <table style="width: 691px">
                        <tr>
                            <td align="left" class="style2" colspan="2">
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                                    Text="Recover Password through Email" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style5" 
                                style="height: 36px; width: 142px; font-weight: bold;" valign="top">
                                <asp:Label ID="Label2" runat="server" Text="Email-ID" ForeColor="Black"></asp:Label>
                            </td>
                            <td class="style4" style="height: 36px; width: 293px" valign="top">
                                <asp:TextBox ID="txtEmailID" runat="server" Width="235px"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblEsend" runat="server" ForeColor="Red" Height="16px"></asp:Label>
                            </td>
                            <td align="left" class="style10" style="height: 36px">
                                <asp:RegularExpressionValidator ID="REVEmail" runat="server" 
                                    ControlToValidate="txtEmailID" Display="None" 
                                    ErrorMessage="Invalid Email ID" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFVEEmail" runat="server" 
                                    ControlToValidate="txtEmailID" Display="None" 
                                    ErrorMessage="Enter email Id."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style1" colspan="2" style="height: 59px">
                                <asp:ImageButton ID="btnSendMail" runat="server" Height="49px" 
                                    ImageUrl="~/images/Submit.png" Width="114px" onclick="btnSendMail_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandArgument="0" CommandName="SwitchViewByIndex">Click here to Retreive 
                                Password Security question</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </center>
        </asp:View>
        </asp:MultiView>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
         ShowMessageBox="True" ShowSummary="False" />
         <br />

     <script type="text/javascript" src="js/jquery.js"></script>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
         ShowMessageBox="True" ShowSummary="False" />
     
</asp:Content>

