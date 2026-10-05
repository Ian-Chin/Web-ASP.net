<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberDashboard.aspx.cs" Inherits="WAPP.memberDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>My Dashboard</h1>
            <table>
                <tr>
                    <td><asp:Label ID="uname" runat="server" Text=""></asp:Label></td>
                    <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Lab9/editUserProfile.aspx">Edit Profile</asp:HyperLink></td>
                    <td><asp:LinkButton ID="LinkButton1" OnCommand="LinkButton1_Command" runat="server">Sign Out</asp:LinkButton></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
