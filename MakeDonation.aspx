<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeDonation.aspx.cs" Inherits="MakeDonation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


         <table>

            <tr>
                <td>How much would you like to donate?</td>
                <td>
                    <asp:Label ID="lblHello" runat="server" Text="Thank you for your generosity!"></asp:Label></td>

            </tr>

             <tr>
                <td>Enter Your Donation</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Enter your Donation Amount:"></asp:Label>
                     <asp:TextBox ID="txtMakeDonation" runat="server"></asp:TextBox></td>
               

            </tr>
            <tr>
                
                <td>
                    <asp:Button ID="btnDonateSubmit" runat="server" Text="Button" OnClick="btnDonateSubmit_Click" />  </td>
                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            </tr>
           
        </table>

        </div>


    </form>
</body>
</html>
