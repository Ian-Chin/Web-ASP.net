<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WAPP.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login Page</h1>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Lab 6 - 7/memberRegistration.aspx">Not yet Register?</asp:HyperLink>
            </p>
            <table>
                <tr>
                    <td>Username:</td>
                    <td><asp:TextBox ID="username" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Sign In" OnClick="Button1_Click" /></td>
                    <td>
                        <asp:Label ID="errorMsg" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
