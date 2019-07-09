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
    public partial class Notic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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

                objCmdusert.CommandText = String.Format("INSERT INTO [NOTIC] (日期,公告) values('{0}','{1}')"
                    , strYMD, this.TextBox1.Text);                  
                try
                {
                    objCmdusert.ExecuteNonQuery();
                    Response.Write("<script>alert('添加公告成功');window.close();</script>");
                }
                catch (Exception ex) 
                {
                 Response.Write("<script>alert('公告添加出错:"+ex.Message+"');window.close();</script>");
                }
                objConn2.Close(); 

        }
    }
}