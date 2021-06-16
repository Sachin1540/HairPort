<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Default2" Title="Services" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <font face="Times New Roman" size="3">
<table style="color: #000000">
        <tr>
            <td colspan="3" style="height: 39px; font-size: large; color: #0099FF;"><b>Enter Service Details</b></td>
        </tr>
        <tr style="width: 136px; height: 25px;">
            <td><b>ID:</b></td>
            <td style="height: 25px">
                <asp:Label ID="lblid" runat="server" Text=""></asp:Label></td>
            <td style="height: 25px; width: 146px;"></td>
        </tr>
        
        <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Service Name:</b></td>
            <td style="height: 17px">
                <asp:TextBox ID="txtname" runat="server" Width="250px" MaxLength="20" onkeypress="return isCharKey(event)"></asp:TextBox>
            </td>
            <td style="height: 17px; width: 146px">
                <asp:RequiredFieldValidator ID="RFVProName" runat="server" 
                    ErrorMessage="Enter Service Name." ControlToValidate="txtname" 
                    Display="None" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="width: 136px; ">
            <td valign="top">Description:</td>
            <td valign="top">
                <asp:TextBox ID="txtsummary" runat="server" TextMode="MultiLine" Height="145px" 
                    Width="250px" MaxLength="500"></asp:TextBox>
            </td>
<td></td>
</tr>
        <tr>
            <td>Cost:</td>
            <td>
                <asp:TextBox ID="txtcost"  runat="server" onkeypress="return isnumberKey(event)" MaxLength="10" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFVCostPrice" runat="server" 
                    ErrorMessage="Enter Cost." ControlToValidate="txtcost" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CVCost" runat="server" Display="None" 
                    ErrorMessage="Enter Cost Price in Numbers." 
                    ClientValidationFunction="CVCost_ServerValidate" ControlToValidate="txtcost" 
                    onservervalidate="CVCost_ServerValidate" ></asp:CustomValidator>
            </td>
        </tr>


        <tr>
            <td colspan="3" align="center">
                <asp:ImageButton ID="btnNew" runat="server" Height="80px" 
                    ImageUrl="~/images/new pro.png" onclick="btnNew_Click" Width="80px" 
                    CausesValidation="False" />
                    <asp:ImageButton ID="btnModify" runat="server" Height="80px" 
                    ImageUrl="~/images/modify pro.png" Width="80px" 
                    onclick="btnModify_Click" CausesValidation="False" />
                        <asp:ImageButton ID="btnSave" runat="server" Height="80px" 
                    ImageUrl="~/images/save pro.png" Width="80px" onclick="btnSave_Click" />
                            <asp:ImageButton ID="btnRemove" runat="server" Height="80px" 
                    ImageUrl="~/images/remove pro.png" Width="80px" 
                    onclick="btnRemove_Click" CausesValidation="False" />
                                <asp:ImageButton ID="btnCancel" runat="server" Height="80px" 
                    ImageUrl="~/images/cancel pro.png" onclick="btnCancel_Click" Width="80px" 
                    CausesValidation="False" />
            </td>
        </tr>
        
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="686px" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                    <ControlStyle BackColor="#0099FF" Font-Bold="True" ForeColor="White" />
                </asp:CommandField>
            </Columns>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            </td>
        </tr>
        
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
</table>
</font>

</asp:Content>

