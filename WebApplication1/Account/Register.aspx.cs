using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Drawing;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            string username = RegisterUser.UserName;
            string password1 = RegisterUser.Password;
            string password2 = RegisterUser.ConfirmPassword;
            string email = RegisterUser.Email;

        
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
            if (rowsnumber > 0)
            {
                Response.Write("<script>alert('对不起，用户名已经注册')</script>");
            }
            else
            {
                OleDbCommand objCmdusert = new OleDbCommand();
                objCmdusert.Connection = objConn;

                objCmdusert.CommandText = String.Format("INSERT INTO [log] (logname,logpassword,email,logstyle) values('{0}','{1}','{2}','{3}')"
                 , username,password1,email,2);
                try
                {
                    objCmdusert.ExecuteNonQuery();
                    Response.Write("<script>alert('注册成功');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('注册:" + ex.Message + "');window.close();</script>");
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = RegisterUser.UserName;
            //string password = this.LoginUser.Password;

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
            if (rowsnumber > 0)
            {
                Response.Write("<script>alert('对不起，用户名已经注册')</script>");
            }
            else
            {
                Response.Write("<script>alert('恭喜可以使用')</script>");
            }
        }

    }
}
