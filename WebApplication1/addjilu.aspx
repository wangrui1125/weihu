<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addjilu.aspx.cs" Inherits="WebApplication1.addjilu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


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










</asp:Content>
