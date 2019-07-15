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
    public partial class addobject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

            //string[] types = new[] { "其他", "手套箱" ,"分子泵"};


            string objectname = TextBox1.Text;
            string objectdes = TextBox2.Text;
            //string type = types[DropDownList1.SelectedIndex];



            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();
            string oid = Request.QueryString["oid"];

            OleDbCommand objCmdusert = new OleDbCommand();
            objCmdusert.Connection = objConn;


            objCmdusert.CommandText = String.Format("Insert into [objects] (name,description,type) values('{0}','{1}',{2})", objectname,
                objectdes, DropDownList1.SelectedIndex);

            string otype = DropDownList1.SelectedIndex.ToString();
            string backweb = "";
            switch (otype)
            {
                case "1":
                    backweb = "stx";
                    break;
                case "2":
                    backweb = "fzb";
                    break;
                case "0":
                    backweb = "qt";
                    break;

            }





            try
            {
                objCmdusert.ExecuteNonQuery();


                Response.Write("<script>alert('添加成功');window.document.location.href='"+ backweb +".aspx';</script>");



            }
            catch (Exception) { }

            objConn.Close();








        }
    }
}