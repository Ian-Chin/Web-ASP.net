<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="db_connections.aspx.cs" Inherits="WAPP.db_connections" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Table]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
