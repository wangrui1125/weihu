using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


namespace WebApplication1
{
    public partial class addjilu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.Calendar1.SelectedDate = DateTime.Now.Date;
                this.Label1.Text = Request.QueryString["type"];
                this.Label2.Text = this.Calendar1.SelectedDate.ToString();
                this.TextBox1.Text = "6";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oid = Request.QueryString["oid"];
            string type = Request.QueryString["type"];
            int i = 1;

            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");

            OleDbConnection objConn2 = new OleDbConnection(sConnectionString);
            // Open connection with the database.
            objConn2.Open();
            OleDbCommand objCmdusert = new OleDbCommand();
            objCmdusert.Connection = objConn2;
            DateTime jldate = this.Calendar1.SelectedDate;
            DateTime txdate = jldate.AddMonths(int.Parse(this.TextBox1.Text));

            objCmdusert.CommandText = String.Format("INSERT INTO [jilu] (日期,设备ID,操作类型,提醒日期) values('{0}','{1}','{2}','{3}')",
                jldate, oid, type, txdate);
            try
            {
                objCmdusert.ExecuteNonQuery();
                Response.Write("<script>alert('添加成功');window.document.location.href='stx.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('预约失败:" + ex.Message + "');window.document.location.href='stx.aspx';</script>");
            }
            objConn2.Close();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.Label2.Text = this.Calendar1.SelectedDate.ToString();
        }
    }
}