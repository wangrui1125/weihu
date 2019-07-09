<%@ Page Title="PPMS预约" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">   

  <style type="text/css">         
       .cssstyle    
       {  
           display:none;  
       }  
      .style1
      {
          color: #FF3300;
          font-size: medium;
      }
      .style2
      {
          font-size: medium;
      }
  </style>

<script language="javascript">
    function preview() {
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        window.print();
    }
    function deletelog(){
     var result = window.confirm("确定删除吗");
     if (result) 
     {
         document.getElementById("<%=Button6.ClientID %>").click();
       }
    }
  </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      <h2>
          &nbsp;</h2>
    <p>
        欢迎预约<span class="style1"><strong>PPMS</strong></span></p>
      <p>
       <marquee>
           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></marquee>


          &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="预约" />
          <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="刷新" />
          <input type="button" name="print" value="打印表格" onclick="preview()"></p>
     <!--startprint-->    
    <div  id="divdgr" style="Height:500px;Width:auto;OVERFLOW: auto" >
        


            <asp:DataGrid ID="DataGrid1" runat="server" 
                 onselectedindexchanged="DataGrid1_SelectedIndexChanged1" 
            Width="800px"  CellPadding="4" ForeColor="#333333" 
                 GridLines="None" onitemdatabound="DataGrid1_ItemDataBound" 
                  HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" BackColor="#EFF3FB"></ItemStyle>
                                <EditItemStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" 
                                    BackColor="#507CD1"></HeaderStyle>
                                <AlternatingItemStyle BackColor="White" />
                                <Columns>
     <asp:ButtonColumn CommandName="Select" Text="选择"></asp:ButtonColumn>
     <asp:templatecolumn HeaderText="状态">
        <itemtemplate>
            <asp:DropDownList  id="ItemDropDown" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1" ClientIDMode="AutoID">
                </asp:DropDownList>
        </itemtemplate>
    </asp:TemplateColumn>    
    </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
</asp:datagrid>
 </div>    
   <!--endprint-->
     <p>
        &nbsp;<asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="上移" />
         <asp:TextBox ID="TextBox1" runat="server" Width="33px"></asp:TextBox>
         <span class="style2">行&nbsp;&nbsp;&nbsp; </span>
         <asp:Button ID="Button4" runat="server" Text="下移" onclick="Button4_Click" />
         <input type="button" name="delete" value="删除" onclick="deletelog()">
         <asp:Button ID="Button6" runat="server" onclick="Button5_Click" Text="Button" CssClass="cssstyle"/>

    </p>
    <p>
        您还可以找到 <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="MSDN ASP.NET 文档">MSDN 上有关 ASP.NET 的文档</a>。
    </p>      
</asp:Content>
