<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="setobject.aspx.cs" Inherits="WebApplication1.setobject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #TextArea1
        {
            height: 87px;
            width: 210px;
        }
    </style>   
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   


       <div style="height: 264px">
            <br />
            <br />
            <br />
            设备名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            
            设备描述：<br />
            <asp:TextBox ID="TextBox2" runat="server" Height="75px" 
                ontextchanged="TextBox2_TextChanged" TextMode="MultiLine" Width="196px"></asp:TextBox>
            <br />


            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />


      </div>




    
   





</asp:Content>
