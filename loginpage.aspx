<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginpage.aspx.cs" Inherits="loginpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    .loginp{
    text-align:center;
    
    
    }
        .auto-style1 {
            width: 158px;
            height: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginp">
    
       <h1 style="color:white;">
           <img class="auto-style1" src="download.png" /></h1>
        <h1 style="color:lightgreen;">LOGIN</h1>
        <br />
        &nbsp;&nbsp;&nbsp; Email:- <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Email" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <br />
        Password:-<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" TextMode="Password" Width="151px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Password" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
&nbsp;<br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forgot Password?</asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="27px" ImageUrl="~/images/Login.jpg" OnClick="ImageButton1_Click" Width="117px" />
        &nbsp;</div>
    </form>
</body>
</html>
