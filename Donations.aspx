<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Donations.aspx.cs" Inherits="Donations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>Thanks for your Donations!</header>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdDonations" runat="server" AutoGenerateColumns="True">
        </asp:GridView>
       
        <asp:Label ID="lblHello" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnDonateMore" runat="server" Text="Donate" OnClick="btnDonateMore_Click" />
    </div>

    </form>
</body>
</html>
