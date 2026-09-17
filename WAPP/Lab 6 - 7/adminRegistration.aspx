<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminRegistration.aspx.cs" Inherits="WAPP.adminRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin Registration Page</h1>
            <table>
                <tr>
                    <td>First Name:</td>
                    <td><asp:TextBox ID="fname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td><asp:TextBox ID="lname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:DropDownList ID="gender" runat="server">
                            <asp:ListItem>F</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Country:</td>
                    <td><asp:TextBox ID="country" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>UserName:</td>
                    <td><asp:TextBox ID="username" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" /></td>
                    <td class="auto-style1">
                        <asp:Label ID="errMsg" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <p>
                        <asp:Label ID="usertype" runat="server" Text="admin"></asp:Label>
                    </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
