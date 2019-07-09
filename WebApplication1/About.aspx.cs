using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Drawing;

namespace WebApplication1
{
    public partial class About : System.Web.UI.Page
    {
        DataSet objDataset1 = new DataSet();
        string ipadress = "";       
        //string ipkey = "159.226.37.34";
        //string ipkey= "10.60.2.182";
        string ipkey = "127.0.0.1";
        protected void Page_Load(object sender, EventArgs e)
        {            
            //获取ip地址
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result)) { result = request.ServerVariables["REMOTE_ADDR"]; }
            if (string.IsNullOrEmpty(result)) { result = request.UserHostAddress; }
            if (string.IsNullOrEmpty(result)) { result = "0.0.0.0"; }
            ipadress = result;
                //获取Excl
                // Create connection string variable. Modify the "Data Source"
                // parameter as appropriate for your environment.
                // String sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                //"Data Source=" + Server.MapPath("~/ExcelData.xlsx") + ";" +
                //"Extended  Properties='Excel 12.0; HDR=YES; IMEX=1'";
                 string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                // Create connection object by using the preceding connection string.
                OleDbConnection objConn = new OleDbConnection(sConnectionString);
                // Open connection with the database.
                objConn.Open();

                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [PPMS] order by id desc", objConn);             
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();                
                objAdapter1.SelectCommand = objCmdSelect;
                // Fill the DataSet with the information from the worksheet.
                objAdapter1.Fill(objDataset1, "XLData");

                //System.Data.DataTable dttale= objDataset1.Tables[0];
                foreach (DataRow dri in objDataset1.Tables[0].Rows)
                { 
                    if(dri[6].ToString()=="隐藏")
                    {
                        System.DateTime oldTime = new System.DateTime();
                        oldTime = (System.DateTime)dri[1];
                        System.DateTime currentTime = new System.DateTime();
                        currentTime = System.DateTime.Now;
                        TimeSpan times = currentTime - oldTime;
                        if (times.TotalDays>60)
                        {
                            dri.Delete();
                        }
                    }
                }
                objDataset1.Tables[0].AcceptChanges();
                //Notic 加载            
                objCmdSelect = new OleDbCommand("SELECT * FROM [NOTIC] order by id desc", objConn);
                objAdapter1 = new OleDbDataAdapter();
                objAdapter1.SelectCommand = objCmdSelect;
                DataSet objDatasetnotic = new DataSet();
                objAdapter1.Fill(objDatasetnotic, "XLData");
                DataRow drinotic = objDatasetnotic.Tables[0].Rows[0];
                System.DateTime notictime = (System.DateTime)drinotic[1];
                string noticstr = (string)drinotic[2];
           

                // Bind data to DataGrid control.
                if (!IsPostBack)
                {
                DataGrid1.DataSource = objDataset1.Tables[0].DefaultView;
                DataGrid1.DataBind();
                Label1.Text = "公告:" + notictime.ToString() + ":<span class=\"style1\">" + noticstr + "</span>";
                }

                
                // Clean up objects.
                objConn.Close();
           
           
        }

        //数据绑定
        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        { 
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                string[] options = {"等待中", "正在测试", "测试完成","选择不测","轮过一次" ,"隐藏"};
                DropDownList list = new DropDownList();
                list = (DropDownList)e.Item.FindControl("ItemDropDown");
                list.DataSource = options;
                list.DataBind();
                TableCell cell = list.Parent as TableCell;
                DataGridItem item = cell.Parent as DataGridItem;                            
                item.Cells[9].Text="";
           

                int index = item.ItemIndex;
                String state = item.Cells[8].Text;
                switch(state){
                    case "等待中":
                        {
                            list.SelectedIndex = 0;
                            break;
                        }
                    case "正在测试":
                        {    
                            list.SelectedIndex = 1;
                            item.BackColor = System.Drawing.ColorTranslator.FromHtml("Red"); 
                            break;
                        }
                    case "测试完成":
                        {
                            list.SelectedIndex = 2;
                            item.BackColor = System.Drawing.Color.Chocolate;
                            break;
                        }
                    case "选择不测":
                        {
                            list.SelectedIndex = 3;
                            item.BackColor = System.Drawing.Color.Chocolate;
                            break;  
                        }
                    case "轮过一次":
                       {
                             list.SelectedIndex = 4;
                            break;  
                       }
                    default:
                      {
                          list.SelectedIndex = 5;
                          break;
                      }
                }
           
            }
        }




        protected void DataGrid1_SelectedIndexChanged1(object sender, System.EventArgs e)
        {       
           
            
        }  
    
        //预约
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string url = "~/Appointment.aspx";
            //Response.Redirect("~/Appointment.aspx", true);
            //Response.Write("<script>window.open('Appointment.aspx','_blank')</script>");
            Response.Write("<script>window.open('Appointment.aspx','_blank')</script>");
        }

        //刷新
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", "0");
        }

        //上移
        protected void Button3_Click(object sender, EventArgs e)
        {
            //上移
            bool loged = false;
            if (User.Identity.IsAuthenticated)
            {
                string name = User.Identity.Name;
                if (name == "admin")
                {
                    loged = true;
                }
            }

            if (ipadress == ipkey || loged)
            {
                int index = DataGrid1.SelectedIndex;
                if (index == -1)
                {
                    Response.Write("<script>alert('请先选择一行')</script>");
                }
                else
                {
                    if (index >0)
                    {

                        int change = index - 1;
                        if (TextBox1.Text != "")
                        {
                            int temp = Int16.Parse(TextBox1.Text);
                            if (index > temp)
                            {
                                change = index - temp;
                            }
                            else
                            {
                                change = 0;
                            }
                        }


                        DataRow dr1 = objDataset1.Tables[0].Rows[index];
                        DataRow dr2 = objDataset1.Tables[0].Rows[change];
                        string idd1 = dr1[0].ToString();
                        string idd2 = dr2[0].ToString();

                        string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                        // Create connection object by using the preceding connection string.
                        OleDbConnection objConn = new OleDbConnection(sConnectionString);
                        // Open connection with the database.
                        objConn.Open();
                        OleDbCommand objCmdusert = new OleDbCommand();
                        objCmdusert.Connection = objConn;
                        //交换
                        objCmdusert.CommandText = String.Format("Update [PPMS] set 日期='{0}',组='{1}',名字='{2}',测试项目='{3}',电话='{4}',状态='{5}',IP='{6}' where ID like '{7}'",
                            dr2[1].ToString(), dr2[2].ToString(), dr2[3].ToString(), dr2[4].ToString(), dr2[5].ToString(), dr2[6].ToString(), dr2[7].ToString(), idd1);
                        try
                        {
                            objCmdusert.ExecuteNonQuery();
                        }
                        catch (Exception) { }

                        objCmdusert.CommandText = String.Format("Update [PPMS] set 日期='{0}',组='{1}',名字='{2}',测试项目='{3}',电话='{4}',状态='{5}',IP='{6}' where ID like '{7}'",
                            dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString(), dr1[4].ToString(), dr1[5].ToString(), dr1[6].ToString(), dr1[7].ToString(), idd2);
                        try
                        {
                            objCmdusert.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                        objConn.Close();
                        Response.AddHeader("Refresh", "0");
                    }

                }
            }
            else
            {
                Response.Write("<script>alert('对不起，您没有权限')</script>");
                Response.AddHeader("Refresh", "0");
            }
           
        }

        //下移
        protected void Button4_Click(object sender, EventArgs e)
        {
            //下移
            bool loged = false;
            if (User.Identity.IsAuthenticated)
            {
                string name = User.Identity.Name;
                if (name == "admin")
                {
                    loged = true;
                }
            }

            if (ipadress == ipkey || loged)
            {
                int index = DataGrid1.SelectedIndex;
                if (index == -1)
                {
                    Response.Write("<script>alert('请先选择一行')</script>");
                }
                else
                {
                    if (index < objDataset1.Tables[0].Rows.Count-1)
                    {                    
                        DataRow dr1 = objDataset1.Tables[0].Rows[index];
                        DataRow dr2 = objDataset1.Tables[0].Rows[index+1];
                        string idd1 = dr1[0].ToString();
                        string idd2 = dr2[0].ToString();

                        string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                        // Create connection object by using the preceding connection string.
                        OleDbConnection objConn = new OleDbConnection(sConnectionString);
                        // Open connection with the database.
                        objConn.Open();
                        OleDbCommand objCmdusert = new OleDbCommand();
                        objCmdusert.Connection = objConn;
                        //交换
                        objCmdusert.CommandText = String.Format("Update [PPMS] set 日期='{0}',组='{1}',名字='{2}',测试项目='{3}',电话='{4}',状态='{5}',IP='{6}' where ID like '{7}'", 
                            dr2[1].ToString(),dr2[2].ToString(),dr2[3].ToString(),dr2[4].ToString(),dr2[5].ToString(),dr2[6].ToString(),dr2[7].ToString(),idd1);
                        try
                        {
                            objCmdusert.ExecuteNonQuery();
                        }
                        catch (Exception) { }

                        objCmdusert.CommandText = String.Format("Update [PPMS] set 日期='{0}',组='{1}',名字='{2}',测试项目='{3}',电话='{4}',状态='{5}',IP='{6}' where ID like '{7}'",
                            dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString(), dr1[4].ToString(), dr1[5].ToString(), dr1[6].ToString(), dr1[7].ToString(), idd2);
                        try
                        {
                            objCmdusert.ExecuteNonQuery();
                        }
                        catch (Exception) { }
                        objConn.Close();
                        Response.AddHeader("Refresh", "0");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，您没有权限')</script>");
                Response.AddHeader("Refresh", "0");
            }
        }
       
         protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
         {
             DropDownList list = (DropDownList)sender;

             TableCell cell = list.Parent as TableCell;
             DataGridItem item = cell.Parent as DataGridItem;

             int index = item.ItemIndex;
             string content = item.Cells[2].Text;
             // DropDownList down = (DropDownList)item.FindControl("ItemDropDown");
             string checkState = list.SelectedValue.Trim();

             bool loged = false;
             if (User.Identity.IsAuthenticated)
             {
                 string name = User.Identity.Name;
                 if (name == "admin")
                 {
                     loged = true;
                 }
             }

             if (ipadress == ipkey || loged)
             {
                 ChangtheState(index, checkState);
             }
             else
             {
                 Response.Write("<script>alert('对不起，您没有权限')</script>");
                 Response.AddHeader("Refresh", "0");
             }             
         }
     
       


         void ChangtheState(int index, string chechState)
         {
             DataRow dr = objDataset1.Tables[0].Rows[index];
             string idd = dr[0].ToString();
             string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
             // Create connection object by using the preceding connection string.
             OleDbConnection objConn = new OleDbConnection(sConnectionString);
             // Open connection with the database.
             objConn.Open();
             OleDbCommand objCmdusert = new OleDbCommand();
             objCmdusert.Connection = objConn;
             objCmdusert.CommandText = String.Format("Update [PPMS] set 状态='{1}' where ID like '{0}'", idd, chechState);
             try
             {
                 objCmdusert.ExecuteNonQuery();
             }
             catch (Exception) { }

             //把其他的正在测试去掉
             if (chechState == "正在测试")
             {
                 int rowconunt = objDataset1.Tables[0].Rows.Count;
                 foreach (DataRow dri in objDataset1.Tables[0].Rows)
                 {
                     if (dri[6].ToString() == "正在测试")
                     {
                         OleDbCommand objCmdusert1 = new OleDbCommand();
                         objCmdusert1.Connection = objConn;
                         objCmdusert1.CommandText = String.Format("Update [PPMS] set 状态='{1}' where ID like '{0}'", dri[0].ToString(), "测试完成");
                         try
                         {
                             objCmdusert1.ExecuteNonQuery();
                         }
                         catch (Exception) { }
                     }
                 }
             }
             objConn.Close();
             Response.AddHeader("Refresh", "0");
         }

         //删除
         protected void Button5_Click(object sender, EventArgs e)
         { 
             
             bool loged = false;
             if (User.Identity.IsAuthenticated)
             {
                 string name = User.Identity.Name;
                 if (name == "admin")
                 {
                     loged = true;
                 }
             }

             if (ipadress == ipkey || loged)
             {
                 int index = DataGrid1.SelectedIndex;
                 if (index == -1)
                 {
                     Response.Write("<script>alert('请先选择一行')</script>");
                 }
                 else
                 {
                     DataRow dr1 = objDataset1.Tables[0].Rows[index];
                     DataRow dr2 = objDataset1.Tables[0].Rows[index + 1];
                     string idd1 = dr1[0].ToString();
                     string idd2 = dr2[0].ToString();

                     string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                     // Create connection object by using the preceding connection string.
                     OleDbConnection objConn = new OleDbConnection(sConnectionString);
                     // Open connection with the database.
                     objConn.Open();
                     OleDbCommand objCmdusert = new OleDbCommand();
                     objCmdusert.Connection = objConn;
                     //交换
                     objCmdusert.CommandText = String.Format("delete from [PPMS] where ID like '{0}'", idd1);

                     try
                     {
                         objCmdusert.ExecuteNonQuery();
                     }
                     catch (Exception) { }
                     objConn.Close();
                     Response.AddHeader("Refresh", "0");
                 }
             }
             else
             {
                 Response.Write("<script>alert('对不起，您没有权限')</script>");
                 Response.AddHeader("Refresh", "0");
             }

         }

         
     
    }
}
