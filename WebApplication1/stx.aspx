<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stx.aspx.cs" Inherits="WebApplication1.stx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
       <marquee>
           <asp:Label ID="Label0" runat="server" Text="Label"></asp:Label></marquee>
  
      
    
      
 
       
       <table class="auto-style1">
           <tr>
               <td>
                   <asp:Panel ID="Panel1" runat="server">
                   </asp:Panel>
               </td>
               <td>
                   <asp:Panel ID="Panel2" runat="server">
                   </asp:Panel>
               </td>
           </tr>
       </table>
  
      
    
      
 
       
 </asp:Content>
