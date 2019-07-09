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

namespace WebApplication1
{
    public partial class Appointment : System.Web.UI.Page
    {
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            HttpRequest request = HttpContext.Current.Request; 
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result)) { result = request.ServerVariables["REMOTE_ADDR"]; } 
            if (string.IsNullOrEmpty(result)) { result = request.UserHostAddress; } 
            if (string.IsNullOrEmpty(result)) { result = "0.0.0.0"; } 
            this.Label3.Text = result;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String keyword = "abc";
            string ipaddress = this.Label3.Text;
            if (this.TextBox5.Text == keyword)
            {
                string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                // Create connection object by using the preceding connection string.
                /* 
                 * OleDbConnection objConn = new OleDbConnection(sConnectionString);
                // Open connection with the database.
                objConn.Open();
               
                OleDbCommand objCmdSelect = new OleDbCommand("select 序号 from [VSM]", objConn);
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                // Pass the Select command to the adapter.
                objAdapter1.SelectCommand = objCmdSelect;
                // Create new DataSet to hold information from the worksheet.
                DataSet objDataset1 = new DataSet();
                // Fill the DataSet with the information from the worksheet.
                objAdapter1.Fill(objDataset1, "XLData");
                int count = 0;
                foreach (DataRow dr in objDataset1.Tables[0].Rows)
                {
                    count++;
                }
                string idmaxnow = objDataset1.Tables[0].Rows[count - 1][0].ToString();
                int id = int.Parse(idmaxnow) + 1;
                objConn.Close();
                */
                OleDbConnection objConn2 = new OleDbConnection(sConnectionString);
                // Open connection with the database.
                objConn2.Open();
                OleDbCommand objCmdusert = new OleDbCommand();
                objCmdusert.Connection = objConn2;

                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string strYMD = currentTime.ToString("d");

                objCmdusert.CommandText = String.Format("INSERT INTO [VSM] (日期,组,名字,测试项目,电话,状态,IP) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                    , strYMD, this.TextBox1.Text, this.TextBox2.Text, this.TextBox4.Text, this.TextBox3.Text, "等待中", ipaddress);                  
                try
                {
                    objCmdusert.ExecuteNonQuery();
                    Response.Write("<script>alert('预约成功,请点刷新观察预约结果');window.close();</script>");
                }
                catch (Exception ex) 
                {
                 Response.Write("<script>alert('预约失败:"+ex.Message+"');window.close();</script>");
                }
                objConn2.Close();               
            }
            else
            {
                Response.Write("<script>alert('请输入正确的密码，谢谢！');</script>");            
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            String keyword = "abc";
            string ipaddress = this.Label3.Text;
            if (this.TextBox5.Text == keyword)
            {
                string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                // Create connection object by using the preceding connection string.
                

                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string strYMD = currentTime.ToString("d");

                OleDbConnection objConn2 = new OleDbConnection(sConnectionString);
                // Open connection with the database.
                objConn2.Open();
                OleDbCommand objCmdusert = new OleDbCommand();
                objCmdusert.Connection = objConn2;
                objCmdusert.CommandText = String.Format("INSERT INTO [PPMS] (日期,组,名字,测试项目,电话,状态,IP) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                , strYMD, this.TextBox1.Text, this.TextBox2.Text, this.TextBox4.Text, this.TextBox3.Text, "等待中", ipaddress);
                 try
                {
                    objCmdusert.ExecuteNonQuery();
                    Response.Write("<script>alert('预约成功,请点刷新观察预约结果');window.close();</script>");
                }
                catch (Exception ex) 
                {
                 Response.Write("<script>alert('预约失败:"+ex.Message+"');window.close();</script>");
                }
                objConn2.Close();               
            }
            else
            {
                Response.Write("<script>alert('请输入正确的密码，谢谢！');</script>");            
            }

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}