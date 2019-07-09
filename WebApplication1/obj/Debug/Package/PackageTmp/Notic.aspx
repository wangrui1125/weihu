<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notic.aspx.cs" Inherits="WebApplication1.Notic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        请输入公告内容：<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="51px" 
            ontextchanged="TextBox1_TextChanged" style="margin-bottom: 0px" 
            TextMode="MultiLine" Width="399px"></asp:TextBox>
    
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="提交" />
    </form>
</body>
</html>
