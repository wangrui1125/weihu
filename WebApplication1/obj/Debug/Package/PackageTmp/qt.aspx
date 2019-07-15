<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="qt.aspx.cs" Inherits="WebApplication1.qt" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     
     <marquee>
           <asp:Label ID="Label0" runat="server" Text="Label"></asp:Label></marquee>  
       
         <asp:Button ID="Button1" runat="server" Text="添加设备" onclick="Button1_Click" />


       <table class="style3">
           <tr>
               <td class="style1" dir="ltr">
                   <asp:Panel ID="Panel1" runat="server" Width="250px" >
                   </asp:Panel>
               </td>
               <td class="style2">
                   <asp:Panel ID="Panel2" runat="server" Width="250px" >
                   </asp:Panel>
               </td>
               <td class="style2">
                   <asp:Panel ID="Panel3" runat="server" Width="250px">
                   </asp:Panel>
               </td>
           </tr>
       </table>





</asp:Content>
