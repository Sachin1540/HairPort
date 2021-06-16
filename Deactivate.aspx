<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="Deactivate.aspx.cs" Inherits="Default2" Title="Close Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
<center>
    <font style="font-family: Calibri; font-size: medium; font-style: italic;">
        Do You Really Want To Close Your Account?<br/>
        If You Do This You Can't Access Your Account.<br/>
        All Your Details Will Be Lost.</center>
<br />
        <center>
        <table>
            <tr align="center">
                <td>
        <asp:ImageButton ID="IMGYES" runat="server" 
                ImageUrl="~/images/yes.png" Height="50px" Width="100px" onclick="IMGYES_Click" />
        &nbsp;&nbsp;
        <asp:ImageButton ID="IMGNO" runat="server" 
            ImageUrl="~/images/no.png" CausesValidation="False" 
            PostBackUrl="~/Products.aspx" Height="50px" Width="100px" onclick="IMGNO_Click" />
                </td>
            </tr>
        </table>
        </center>
        
        

    

    </font></asp:Content>

