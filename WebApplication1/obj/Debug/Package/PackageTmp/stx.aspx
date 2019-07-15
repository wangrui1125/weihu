<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stx.aspx.cs" Inherits="WebApplication1.stx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 97%;
            height: 150px;
        }
        .style1
        {
            width: 304px;
            height: 148px;
        }
        .style2
        {
            width: 305px;
            height: 148px;
        }
        .style3
        {
            width: 916px;
            height: 183px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
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
