<%@ Page Language="C#" MasterPageFile="~/MasterBL.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Default2" Title="Contact Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>Leave Us Message</h1><table>
    
    <tr><td><b>Name:</b></td><td>
    <asp:TextBox ID="txtname" onkeypress="return isCharKey(event)" runat="server" Width="210px"></asp:TextBox></td>
    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtname" ErrorMessage="Enter Your Name." Display="Dynamic"></asp:RequiredFieldValidator></td></tr>
    <br />
    <br />
    <tr><td style="height: 26px"><b>Mobile No:</b></td>
        <td style="height: 26px">
    <asp:TextBox ID="txtmobileno" onkeypress="return isNumberKey(event)" runat="server" Width="210px" MaxLength="10"></asp:TextBox></td><td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtmobileno" 
                ErrorMessage="Enter Only Numbers In Mobile Number " 
                ValidationExpression="\d+" Display="Dynamic"></asp:RegularExpressionValidator>
        </td></tr>
    <br />
    <br />
    <tr><td><b>Email:</b></td><td>  
    <asp:TextBox ID="txtemail" runat="server" Width="210px"></asp:TextBox></td>
   <td> 
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemail" 
    ErrorMessage="Invalid Email ID." 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
           Display="Dynamic"></asp:RegularExpressionValidator><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtemail" ErrorMessage="Enter Email ID." Display="Dynamic"></asp:RequiredFieldValidator></td></tr>
   
    <tr><td><b>Subject:</b></td><td>
    <asp:TextBox ID="txtsubject" runat="server" Width="210px" ></asp:TextBox></td><td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtsubject" ErrorMessage="Enter Subject." Display="Dynamic"></asp:RequiredFieldValidator></td></tr>
    <br />
    <br /><tr><td>
    <b>Message:</b></td><td>
    <asp:TextBox ID="txtmessage" runat="server" Height="54px" TextMode="MultiLine" 
        Width="210px" MaxLength="100"></asp:TextBox></td>
    &nbsp;<td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtmessage" 
        ErrorMessage="Enter Your Message." Display="Dynamic"></asp:RequiredFieldValidator>
    </td></tr><tr><td></td><td>
    <asp:ImageButton ID="ImageButton1" runat="server" Height="58px" 
        ImageUrl="~/images/Submit.png" Width="128px" 
        onclick="ImageButton1_Click" /></td><td></td></td></tr></table>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="false" ShowSummary="False" />
    <br />
    <br /><br />

</asp:Content>

