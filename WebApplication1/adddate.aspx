<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adddate.aspx.cs" Inherits="WebApplication1.adddate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            添加记录类型：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            添加记录日期：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <br />
        提醒周期（月）：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加记录" />
    </form>
</body>
</html>
