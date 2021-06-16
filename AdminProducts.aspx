<%@ Page Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="Default2" Title="Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <font face="Times New Roman" size="3">
<table style="color: #000000">
        <tr>
            <td colspan="3" style="height: 39px; font-size: large; color: #0099FF;"><b>Enter Products Details</b></td>
        </tr>
        
        <tr style="width: 136px; height: 25px;">
            <td><b>Product ID:</b></td>
            <td style="height: 25px">
                <asp:Label ID="lblid" runat="server" Text=""></asp:Label></td>
            <td style="height: 25px; width: 146px;"></td>
        </tr>
        
        <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Product Name:</b></td>
            <td style="height: 17px">
                <asp:TextBox ID="txtname" runat="server" Width="250px" MaxLength="500" onkeypress="return isCharKey(event)"></asp:TextBox>
            </td>
            <td style="height: 17px; width: 146px">
                <asp:RequiredFieldValidator ID="RFVProName" runat="server" 
                    ErrorMessage="Enter Product Name." ControlToValidate="txtname" 
                    Display="None" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr style="width: 136px; ">
            <td style="width: 136px; height: 21px;"><b>Brand:</b></td>
            <td style="height: 21px">
                <asp:DropDownList ID="DdlBrand" runat="server" Width="180px">
                                    <asp:ListItem>Maybelline</asp:ListItem>
                <asp:ListItem>Lakme</asp:ListItem>
                <asp:ListItem>MAC</asp:ListItem>
                <asp:ListItem>Loreal</asp:ListItem>
                <asp:ListItem>Kaya</asp:ListItem>
                <asp:ListItem>Nivea</asp:ListItem>
                <asp:ListItem>Revolution</asp:ListItem>
                <asp:ListItem>Colorbar</asp:ListItem>
                <asp:ListItem>Estee Lauder</asp:ListItem>
                <asp:ListItem>Tresemme</asp:ListItem>
                <asp:ListItem>Braun</asp:ListItem>
                <asp:ListItem>Vaseline</asp:ListItem>
                <asp:ListItem>The Face Shop</asp:ListItem>
                
                <asp:ListItem>Other</asp:ListItem>

                </asp:DropDownList>
            </td>
            <td style="width: 146px; height: 21px">
                 <font face="Times New Roman" size="3"><asp:Label ID="lblbrand" runat="server" 
                     ForeColor="#FF3300"></asp:Label></font>
            </td>
        </tr>

        <tr style="width: 136px; ">
            <td style="width: 136px; height: 21px;"><b>Category:</b></td>
            <td style="height: 21px">
                <asp:DropDownList ID="ddlcategory" runat="server" Width="180px">
                                                 <asp:ListItem>Make Up</asp:ListItem>
                <asp:ListItem>Skin</asp:ListItem>
                <asp:ListItem>Hair</asp:ListItem>
                <asp:ListItem>Personal Care</asp:ListItem>
                <asp:ListItem>Natural</asp:ListItem>
                <asp:ListItem>Baby</asp:ListItem>
                <asp:ListItem>Wellness</asp:ListItem>
                <asp:ListItem>Men</asp:ListItem>
                <asp:ListItem>Fragnance</asp:ListItem>
                <asp:ListItem>Luxe</asp:ListItem>                

                </asp:DropDownList>
            </td>
            <td style="width: 146px; height: 21px">
                 <font face="Times New Roman" size="3"><asp:Label ID="Label1" runat="server" 
                     ForeColor="#FF3300"></asp:Label></font>
            </td>
        </tr>
        

        
        <tr style="width: 136px; ">
            <td valign="top">Summary:</td>
            <td valign="top">
                <asp:TextBox ID="txtsummary" runat="server" TextMode="MultiLine" Height="145px" 
                    Width="250px" MaxLength="1000"></asp:TextBox>
            </td>
            <td valign="top" align="center">       
                <asp:Image ID="Image1" runat="server" Height="220px" Width="200px" 
                    AlternateText="No Image" ForeColor="Red" 
                    ImageUrl="~/images/products/NAvail.jpg"/>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        
        <tr>
            <td>Cost Price:</td>
            <td>
                <asp:TextBox ID="txtcost"  runat="server" onkeypress="return isnumberKey(event)" MaxLength="10" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFVCostPrice" runat="server" 
                    ErrorMessage="Enter Cost Price." ControlToValidate="txtcost" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CVCost" runat="server" Display="None" 
                    ErrorMessage="Enter Cost Price in Numbers." 
                    ClientValidationFunction="CVCost_ServerValidate" ControlToValidate="txtcost" 
                    onservervalidate="CVCost_ServerValidate" ></asp:CustomValidator>
            </td>
        </tr>
        
        <tr>
            <td>Sell Price:</td>
            <td>
                <asp:TextBox ID="txtsell" runat="server"  MaxLength="10" Width="250px" onkeypress="return isnumberKey(event)"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFVSellPrice" runat="server" 
                    ErrorMessage="Enter sell price." ControlToValidate="txtsell" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CVSell" runat="server" 
                    ClientValidationFunction="CVSell_ServerValidate" ControlToValidate="txtsell" 
                    Display="None" ErrorMessage="Enter Sell Price in Numbers." 
                    onservervalidate="CVSell_ServerValidate"></asp:CustomValidator>
            </td>                        
        </tr>
        
        <tr>
            <td>Quantity:</td>
            <td>
                <asp:TextBox ID="txtqty" runat="server" MaxLength="10" Width="250px" onkeypress="return isnumberKey(event)"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RFVQty" runat="server" 
                    ErrorMessage="Enter product quantity." ControlToValidate="txtqty" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvqty" runat="server" 
                    ClientValidationFunction="CVqty_ServerValidate" ControlToValidate="txtqty" 
                    Display="None" ErrorMessage="Enter Quantity in Numbers only." 
                    onservervalidate="cvqty_ServerValidate"></asp:CustomValidator>
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

