using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Data;



namespace WebApplication1
{
    public partial class jilutabel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string oid = Request.QueryString["oid"];


            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            //objConn.Open();

            //DataTable userTbl = new DataTable();
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [PPMS]", objConn);
            //da.Fill(userTbl);

            // string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/ExcelData1.xlsx") + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=0'";  　　    
            //  OleDbConnection objConn = new OleDbConnection(sConnectionString);

            objConn.Open();
            // The code to follow uses a SQL SELECT command to display the data from the worksheet.
            // Create new OleDbCommand to return data from worksheet.
            OleDbCommand objCmdSelect = new OleDbCommand(string.Format("SELECT * FROM [jilu] where 设备ID={0} order by id desc",oid), objConn);
            // Create new OleDbDataAdapter that is used to build a DataSet
            // based on the preceding SQL SELECT statement.
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            // Pass the Select command to the adapter.
            objAdapter1.SelectCommand = objCmdSelect;
            // Create new DataSet to hold information from the worksheet.
            DataSet objDataset1 = new DataSet();
            // Fill the DataSet with the information from the worksheet.
            objAdapter1.Fill(objDataset1, "XLData");
            

            objCmdSelect = new OleDbCommand(string.Format("SELECT name FROM [objects] where ID={0} order by id desc",oid), objConn);          
            objAdapter1.SelectCommand = objCmdSelect;
            // Create new DataSet to hold information from the worksheet.
            DataSet objDataset2 = new DataSet();
            // Fill the DataSet with the information from the worksheet.
            objAdapter1.Fill(objDataset2, "XLData");
            

            objConn.Close();

            if (!IsPostBack)
            {
                DataGrid1.DataSource = objDataset1.Tables[0].DefaultView;
                DataGrid1.DataBind();

                Label1.Text = "设备名称：" + objDataset2.Tables[0].Rows[0][0].ToString();
            } 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string otype = Request.QueryString["otype"];

            string backweb = "";
            switch (otype)
            { 
                case "1" :
                    backweb = "stx";
                    break;
                case "2":
                    backweb = "fzb";
                    break;
                case "0":
                    backweb = "qt";
                    break;

            }

            Response.Write("<script> window.document.location.href='" + backweb + ".aspx';</script>");





        }
    }
}