using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;


namespace WebApplication1
{
    public partial class setobject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                OleDbConnection objConn = new OleDbConnection(sConnectionString);
                objConn.Open();

                string oid = Request.QueryString["oid"];


                string sqlstr = "SELECT * FROM [objects] where ID =" + oid + " order by id desc";
                OleDbCommand objCmdSelect2 = new OleDbCommand(sqlstr, objConn);
                // Create new OleDbDataAdapter that is used to build a DataSet
                // based on the preceding SQL SELECT statement.
                OleDbDataAdapter objAdapter2 = new OleDbDataAdapter();
                // Pass the Select command to the adapter.
                objAdapter2.SelectCommand = objCmdSelect2;
                // Create new DataSet to hold information from the worksheet.
                DataSet objDataset2 = new DataSet();
                // Fill the DataSet with the information from the worksheet.
                objAdapter2.Fill(objDataset2, "XLData");
                try
                {
                    DataRow dr = objDataset2.Tables[0].Rows[0];
                    TextBox1.Text = dr[1].ToString();
                    TextBox2.Text = dr[3].ToString();

                }
                catch (Exception ex)
                {
                    ;
                }
                objConn.Close();
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string objectname = TextBox1.Text;
            string objectdes = TextBox2.Text;

            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();
            string oid = Request.QueryString["oid"];

            OleDbCommand objCmdusert = new OleDbCommand();
            objCmdusert.Connection = objConn;
           

            objCmdusert.CommandText = String.Format("Update [objects] set name='{0}',description='{1}' where ID like '{2}'",
                           objectname, objectdes, oid);
            try
            {
                objCmdusert.ExecuteNonQuery();
                Response.Write("<script>alert('设置成功');window.document.location.href='stx.aspx';</script>");
            }
            catch (Exception) { }
          
            objConn.Close();







        }
    }
}