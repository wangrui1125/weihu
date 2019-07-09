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

namespace WebApplication1.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void loginbutton_onclick(object sender, EventArgs e)
        {
            string username = this.LoginUser.UserName;
            string password = this.LoginUser.Password;

            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();

            String slqstr = String.Format("SELECT logpassword FROM [log] where logname like '{0}'", username);
            OleDbCommand objCmdSelect = new OleDbCommand(slqstr, objConn);

            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objCmdSelect;

            DataSet objDataset1 = new DataSet();
            objDataset1 = new DataSet();
            // Fill the DataSet with the information from the worksheet.
            objAdapter1.Fill(objDataset1, "XLData");
            int rowsnumber = objDataset1.Tables[0].Rows.Count;
            if (rowsnumber == 0)
            {
                Response.Write("<script>alert('对不起，您没有注册')</script>");
            }
            else if (rowsnumber == 1)
            {
                DataRow dr = objDataset1.Tables[0].Rows[0];
                string keywords1 = dr[0].ToString();
                if (keywords1 == password)
                {
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(username, false);
                }
                else
                {
                    Response.Write("<script>alert('密码错误')</script>");
                }
            }
            objConn.Close();

        }
    }
}
