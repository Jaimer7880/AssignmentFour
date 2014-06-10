<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Enter New User Information</h2>
        <table>
            <tr>
                <td>Enter First Name</td>
                 <td>
                     <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </td>
            </tr>
             <tr>
                <td>Enter Last Name</td>
                 <td>
                     <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Required"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>Enter Email Address</td>
                 <td>
                     <asp:TextBox ID="txtEmail" runat="server">
                     </asp:TextBox><asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                     </td>
            </tr>
             <tr>
                <td>Enter Street Address</td>
                 <td>
                     <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Enter City</td>
                 <td>
                     <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Enter State</td>
                 <td>
                     <asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Enter Zip Code</td>
                 <td>
                     <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Zip Code Required"></asp:RequiredFieldValidator>
                 </td>
            </tr>
            <tr>
                <td>Enter Phone Number</td>
                 <td>
                     <asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox>
                    
                 </td>
            </tr>
             <tr>
                <td>Enter Password</td>
                 <td>
                     <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                 </td>
            </tr>
             <tr>
                <td>Confirm Password</td>
                 <td>
                     <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ControlToValidate="txtConfirmPass" ErrorMessage="Must Confirm Password"></asp:RequiredFieldValidator>
                     <asp:CompareValidator ID="cpvConfirmPass" runat="server" ControlToValidate="txtConfirmPass" ControlToCompare="txtPassword" ErrorMessage="Passwords must match"></asp:CompareValidator>
                 </td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Register User" OnClick="btnSubmit_Click" /></td>
                 <td><asp:Label ID="lblError" runat="server" Text=""></asp:Label></td>
            </tr>


        </table>
    
    </div>
    </form>
</body>
</html>
