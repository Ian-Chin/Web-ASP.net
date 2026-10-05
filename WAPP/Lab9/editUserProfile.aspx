<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editUserProfile.aspx.cs" Inherits="WAPP.Lab9.editUserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>My Profile</h1>
        <table>
            <tr>
                <td><asp:Label ID="uname" runat="server" Text=""></asp:Label></td>
                <td><asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command">Sign Out</asp:LinkButton></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
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
                            <td>Gender</td>
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
                            <td>Password:</td>
                            <td><asp:TextBox ID="pwd" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" /></td>
                            <td>
                                <asp:Label ID="errMsg" runat="server"></asp:Label>
                                <asp:Label ID="usertype" runat="server" Text="member" Visible="false"></asp:Label>
                                <asp:Label ID="img" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top; padding-left: 40px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" accept="image/*" /><br />
                    <asp:Image ID="Image1" runat="server" Width="211px" Height="233px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
