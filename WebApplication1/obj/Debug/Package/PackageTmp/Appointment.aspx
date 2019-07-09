<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="WebApplication1.Appointment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 95px;
        }
        .style2
        {
            width: 213px;
            text-align: center;
        }
        .style3
        {
            width: 198px;
        }
        .style4
        {
            width: 255px;
            text-align: center;
        }
        .style5
        {
            width: 258px;
            text-align: center;
        }
    </style>
</head>
<body>
     <div class="ipadress">
           嗨，你的IP地址是：<asp:Label ID="Label3" ForeColor="Red" runat="server"></asp:Label>  
      </div>

    <form id="form1" runat="server">
    <div>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <table class="style1">
            <tr>
                <td class="style5">
                    密码</td>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="组别"></asp:Label>
                </td>
                <td class="style4">
                    项目</td>
                <td class="style3" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label>
                </td>
                <td class="style3" style="text-align: center">
                    联系电话</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:TextBox ID="TextBox5" runat="server" ontextchanged="TextBox5_TextChanged" 
                        style="text-align: center"></asp:TextBox>
                </td>
                <td class="style2">
                    <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
                        style="margin-right: 0px; text-align: center;" Width="165px" 
                        ></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:TextBox ID="TextBox4" runat="server" Width="169px" 
                        style="text-align: center"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server" Width="180px" 
                        style="text-align: center"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="TextBox3" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="Button2" runat="server" style="text-align: center" Text="预约VSM" 
                        Width="184px" onclick="Button2_Click" Height="24px" />
                </td>
                <td class="style3">
                    <asp:Button ID="Button3" runat="server" Text="预约PPMS" Width="181px" 
                        onclick="Button3_Click" Height="25px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
