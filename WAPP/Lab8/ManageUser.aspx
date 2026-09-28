<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="WAPP.Lab8.ManageUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Member Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Manage Member Profile</h1>
        <asp:Label ID="svfName" runat="server" Text="Label"></asp:Label>
        <table>
            <tr>
                <td>UserName:</td>
                <td>
                    <asp:DropDownList ID="uname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="uname_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="fname" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td><asp:TextBox ID="lname" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:DropDownList ID="gender" runat="server" AutoPostBack="True" OnSelectedIndexChanged="gender_SelectedIndexChanged">
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
                <td>Password:</td>
                <td><asp:TextBox ID="pwd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" /></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Remove" OnClick="Button2_Click" />
                    <asp:Label ID="errMsg" runat="server"></asp:Label>
                    <asp:Label ID="usertype" runat="server" Text="member"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
