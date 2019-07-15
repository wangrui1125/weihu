<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addobject.aspx.cs" Inherits="WebApplication1.addobject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <div style="height: 264px">
            <br />
            <br />
            设备类型：<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>其他</asp:ListItem>
                <asp:ListItem>手套箱</asp:ListItem>
                <asp:ListItem>分子泵</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            设备名称：
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            
            设备描述：<br />
            <asp:TextBox ID="TextBox2" runat="server" CausesValidation="False" 
                TextMode="MultiLine" Height="103px" Width="212px"></asp:TextBox>
            <br />


            <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />


            <br />
            <br />


      </div>








</asp:Content>
