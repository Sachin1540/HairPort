<%@ Page Language="C#" MasterPageFile="~/MasterAL.master" AutoEventWireup="true" CodeFile="Appointments.aspx.cs" Inherits="Default2" Title="Book Appointment" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1>Fill/Update Profile Then Go TO Appointment</h1>
        <table style="color:Black;"  style="color: #000000">
          <tr>
            <td colspan="3" style="height: 39px; font-size: large; color: #0099FF;"><b>Select Appointment Slot</b></td>
        </tr>
        <tr style="width: 136px; height: 25px;">
            <td><b>Appointment No:</b></td>
            <td style="height: 25px">
                <asp:Label ID="lblid" runat="server" Text=""></asp:Label></td>
            <td style="height: 25px; width: 146px;"></td>
        </tr>
      <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Name:</b></td>
            <td style="height: 17px">
                <asp:TextBox ID="txtname" runat="server" Width="250px" MaxLength="20" 
                    onkeypress="return isCharKey(event)" Enabled="False"></asp:TextBox>
            </td>
            <td style="height: 17px; width: 146px">
                <asp:RequiredFieldValidator ID="RFVProName" runat="server" 
                    ErrorMessage="Enter Name." ControlToValidate="txtname" 
                    Display="None" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Email:</b></td>
            <td style="height: 17px">
                <asp:TextBox ID="txtemail" Enabled=False runat="server" Width="250px" 
                    MaxLength="200"></asp:TextBox>
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
      <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Contact No:</b></td>
            <td style="height: 17px">
                <asp:TextBox ID="txtno" runat="server" Width="250px" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
            </td>
            <td style="height: 17px; width: 146px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Enter Contact No." ControlToValidate="txtno" 
                    Display="None" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Select Emp/Barber:</b></td>
            <td style="height: 17px">
                <asp:DropDownList ID="ddlemp" runat="server" Width="130px">
                </asp:DropDownList>             
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
 
   <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Select Date:</b></td>
            <td style="height: 17px">
                <asp:Calendar ID="Calendar1" runat="server" Height="180px" Width="22px" 
                    ondayrender="Calendar1_DayRender" 
                    onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
 <table style="color:Black;" frame="box" style="color: #000000">
 
  <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Select Service:</b></td>
            <td style="height: 17px">
                <asp:DropDownList ID="ddlservice" runat="server" Width="130px" 
                    AutoPostBack="True" onselectedindexchanged="ddlservice_SelectedIndexChanged">
                </asp:DropDownList>             
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
 <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Service Cost(Estimated):</b></td>
            <td style="height: 17px">
                <asp:TextBox ID="txtcost" runat="server" Enabled=false></asp:TextBox>
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
 
 <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Select Time Slot:</b></td>
            <td style="height: 17px">
                <asp:DropDownList ID="ddltime" runat="server" Width="130px">
                </asp:DropDownList>             
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
        
 
        
                 
 <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b></b></td>
            <td style="height: 17px">
                <asp:Button ID="btnadd" runat="server" Text="Add More" onclick="btnadd_Click" />
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
        
        
        
        
        
       </table>

              
 <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"><b>Total Cost:</b></td>
            <td style="height: 17px">
                <asp:Label ID="lblTotal" runat="server" Text="" ForeColor=Red></asp:Label>
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
         
 <tr style="width: 136px; "> 
            <td style="width: 136px; height: 17px;"></td>
            <td style="height: 17px">
                <br />
                <asp:ImageButton ID="btnSave" runat="server" Height="80px" 
                    ImageUrl="~/images/save pro.png" Width="80px" onclick="btnSave_Click" />
                        
                   
            </td>
            <td style="height: 17px; width: 146px">
                
            </td>
        </tr>
        
        
        
</table>
</asp:Content>

