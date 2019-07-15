<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="jilutabel.aspx.cs" Inherits="WebApplication1.jilutabel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
             <br />
             <br />
             <br />
             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             <br />
             <asp:DataGrid ID="DataGrid1" runat="server" CellPadding="4" ForeColor="#333333" 
                 GridLines="None" Width="515px">
                 <AlternatingItemStyle BackColor="White" />
                 <EditItemStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <ItemStyle BackColor="#EFF3FB" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             </asp:DataGrid>
             <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="返回" />
             <br />
   



</asp:Content>
