<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TPaspx.aspx.cs" Inherits="TPaspx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <aspAjax:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
            DelimiterCharacters="" Enabled="True" ServiceMethod="GetListofProducts" MinimumPrefixLength="1" EnableCaching="true" TargetControlID="TextBox1">
        </aspAjax:AutoCompleteExtender>
    </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Proceed.png" OnClick="ImageButton1_Click" />
    </form>
</body>
</html>
