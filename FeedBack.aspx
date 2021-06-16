<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Default2" Title="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <font style="font-family: Calibri; font-size: medium">
 <centre>   <table>
        <tr>
            <td colspan="2">Please Complete This Short Survey To Give Us Feedback Of Website.</td>   
        </tr>
        <tr>
            <td colspan="2"><br />How Offen Do You Visit Our Website?*</td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="rdbVisit" runat="server" 
                    onselectedindexchanged="rdbVisit_SelectedIndexChanged">
                    <asp:ListItem>Daily</asp:ListItem>
                    <asp:ListItem>Several Times Each Week</asp:ListItem>
                    <asp:ListItem>Once A Week</asp:ListItem>
                    <asp:ListItem>Several Times Each Month</asp:ListItem>
                    <asp:ListItem>Once A Month</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="rdbVisit" Display="Dynamic" 
                    ErrorMessage="Select Any One Option."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2"><br />Please Rate Your Overall Satisfaction With Our Website.*</td>
        </tr>
        <tr>
            <td>
            <asp:RadioButtonList ID="rdbRatings" runat="server" 
                    onselectedindexchanged="rdbRatings_SelectedIndexChanged" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:RadioButtonList>
                Like: 
                <br />
                Very Satisfied: <b>&quot;5&quot;</b>
                <br />
                Very Dissatisfied: <b>&quot;1&quot;</b>
            </td>
            <td valign="top">
    
    <font style="font-family: Calibri; font-size: medium">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="rdbRatings" Display="Dynamic" 
                    ErrorMessage="Select Any One Option."></asp:RequiredFieldValidator>
    </font>  
            </td>
        </tr>
        <tr>
            <td>
                <br />Optional:<br />How Can We Improve Our Website?
            </td>
             <td>
                <br />&nbsp;&nbsp;Optional:<br />&nbsp; What Would You Like To See More On Our Website?
            </td>
        </tr>
        <tr>
            <td>
                 <asp:TextBox ID="txtimprove" runat="server" TextMode="MultiLine" Width="300px" 
                     Height="80px"></asp:TextBox>
            </td>
             <td>
                 &nbsp;&nbsp;<asp:TextBox ID="txtmore" runat="server" TextMode="MultiLine" 
                     Height="80px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/images/Submit.png" 
                    Height="58px" onclick="btnSubmit_Click" Width="140px" />
            </td>
        </tr>
    </table></centre>
    </font>

</asp:Content>

