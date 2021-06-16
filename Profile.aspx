<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Default2" Title="Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <center><h1>Fill/Update Profile Then Go TO Products</h1>
        <table style="color:Black;" frame="box" style="color: #FF6699">
            <tr>
                <td colspan="3" align="right">
                    <asp:LinkButton ID="lblOrder" runat="server" ForeColor="Lime" 
                        PostBackUrl="~/OrderHistory.aspx">OrderHistory</asp:LinkButton>
                </td>
            </tr>
            
            <tr>
                <td>
                    <b>Title:</b>
                </td>
                <td align="left">
                    <asp:DropDownList ID="Ddltitle" runat="server" Height="20px">
                         <asp:ListItem>Mrs</asp:ListItem>
                         <asp:ListItem>Miss</asp:ListItem>
                         <asp:ListItem Selected="True">Mr</asp:ListItem>
                     </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            
            <tr>
                <td>
                    <b>First Name:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtfname" onkeypress="return isCharKey(event)" runat="server" Width="170px" MaxLength="15"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtfname" Display="Dynamic" ErrorMessage="Enter Your Name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td><b> Last Name:</b></td>
                <td> <asp:TextBox ID="txtlname" runat="server" Width="170px" onkeypress="return isCharKey(event)" MaxLength="15"></asp:TextBox></td>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="txtlname" Display="Dynamic" 
                        ErrorMessage="Enter Your Surname."></asp:RequiredFieldValidator></td>
            </tr>
            
             <tr>
                <td> <b> Middle Name:</b></td>
                <td> <asp:TextBox ID="txtmname" runat="server" onkeypress="return isCharKey(event)"
                  Width="170px" MaxLength="15"></asp:TextBox></td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtmname" Display="Dynamic" 
                  ErrorMessage="Enter Your Middle Name."></asp:RequiredFieldValidator>
                </td>
            </tr>
            
             <tr>
                <td> <b>Gender:</b></td>
                <td align="left">
                     <asp:DropDownList ID="DdlGender" runat="server" Height="20px">
                  <asp:ListItem>Male</asp:ListItem>
                  <asp:ListItem>Female</asp:ListItem>
              </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            
             <tr>
                <td><b>Address:</b></td>
                <td> <asp:TextBox ID="txtaddress" runat="server" Width="170px" Height="50px" 
                  TextMode="MultiLine" MaxLength="250" 
                ontextchanged="txtaddress_TextChanged" AutoPostBack="True"></asp:TextBox></td>
                <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="txtaddress" Display="Dynamic" 
                  ErrorMessage="Enter Your Address."></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td><b>Pincode:</b></td>
                <td>
                    <asp:TextBox ID="txtpincode" runat="server" onkeypress="return isNumberKey(event)"
                  Width="170px" MaxLength="6"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                     ControlToValidate="txtpincode" Display="Dynamic" ErrorMessage="Enter Pincode."></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td>
                <b>Shipping Address:</b>
                </td>
                
                <td>
                     <asp:TextBox ID="txtshipingadd" runat="server" Width="170px" Height="50px" 
                  TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                </td>
                
                <td align="left"><asp:CheckBox ID="ChkAddress" runat="server" 
                  Text=" Same as above" oncheckedchanged="ChkAddress_CheckedChanged" 
                AutoPostBack="True" />
                    <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                  ControlToValidate="txtshipingadd" Display="Dynamic" 
                  ErrorMessage="Enter Shipping Address."></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        </center>
        <center>
        <table>
        <tr>
            <td>
            <asp:ImageButton ID="btnSave" runat="server" Height="65px" 
                  ImageUrl="~/images/save.png" Width="124px" onclick="btnSave_Click" />
              <asp:ImageButton ID="btnReset" runat="server" Height="65px" 
                  ImageUrl="~/images/reset.png" Width="124px" CausesValidation="False" 
                onclick="btnReset_Click" />
            </td>
        </tr>
        </table>
		</center>      
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                  HeaderText="Errors in Login" ShowMessageBox="false" ShowSummary="False" /> 
		  </div>
</asp:Content>


