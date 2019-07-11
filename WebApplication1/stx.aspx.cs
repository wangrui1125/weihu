using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Drawing; 

namespace WebApplication1
{
    public partial class stx : System.Web.UI.Page
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
                                   
                string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("~/dbMM.accdb");
                OleDbConnection objConn = new OleDbConnection(sConnectionString);
                objConn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [objects] where type =1", objConn);
                // Create new OleDbDataAdapter that is used to build a DataSet
                // based on the preceding SQL SELECT statement.
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                // Pass the Select command to the adapter.
                objAdapter1.SelectCommand = objCmdSelect;
                // Create new DataSet to hold information from the worksheet.
                DataSet objDataset1 = new DataSet();
                // Fill the DataSet with the information from the worksheet.
                objAdapter1.Fill(objDataset1, "XLData");

                int labelindex = 1;
                int panelindex = 1;
                int btindex = 1;

                foreach (DataRow dri in objDataset1.Tables[0].Rows)
                {
                    string sbID = dri[0].ToString();
                    Panel panel0 = new Panel();
                    panel0.ID = "Panal0" + panelindex.ToString();

                    string lastoprationdata = "";
                    string opration = "";
                    string alertdata = "";
                    bool redalert = false;

                    string sqlstr = "SELECT * FROM [jilu] where 设备ID =" + sbID + " order by id desc";
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
                        DateTime dt0 = (DateTime)dr[1];
                        lastoprationdata = dt0.ToString("yyyy-MM-dd");
                        opration = dr[3].ToString();
                        dt0 = (DateTime)dr[4];
                        if (dt0 < DateTime.Now.Date.AddDays(30))
                        {
                            redalert = true;
                        }


                        alertdata = dt0.ToString("yyyy-MM-dd");
                    }
                    catch (Exception ex)
                    {
                        ;
                    }

                    Label temp = new Label();
                    temp.Text = "Name: " + dri[1].ToString() + "<br />";
                    temp.ID = "Labelp" + labelindex.ToString();
                    labelindex += 1;
                    panel0.Controls.Add(temp);

                    Label temp1 = new Label();
                    temp1.Text = "Description: " + dri[3].ToString() + "<br />";
                    temp1.ID = "Labelp" + labelindex.ToString();
                    labelindex += 1;
                    panel0.Controls.Add(temp1);

                    Label temp2 = new Label();
                    temp2.Text = "LastOprationDate: " + lastoprationdata + "(" + opration + ")<br />";
                    temp2.ID = "Labelp" + labelindex.ToString();
                    labelindex += 1;
                    panel0.Controls.Add(temp2);

                    Label temp3 = new Label();
                    temp3.Text = "AlertDate: " + alertdata + "<br />";
                    temp3.ID = "Labelp" + labelindex.ToString();
                    if (redalert)
                    {
                        temp3.ForeColor = Color.Red;
                    }
                    labelindex += 1;
                    panel0.Controls.Add(temp3);

                    Button bt1 = new Button();
                    bt1.Text = "设置";
                    bt1.ID = "buttun0" + btindex.ToString();
                    bt1.Click += new EventHandler(setbutton_click);//使用事件函数句柄指向一个具体的函数

                    panel0.Controls.Add(bt1);
                    btindex = btindex + 1;
                   

                    Button bt2 = new Button();
                    bt2.Text = "再生";
                    bt2.ID = "buttun0" + btindex.ToString();
                    panel0.Controls.Add(bt2);
                    btindex = btindex + 1;                    
                    bt2.Click += new EventHandler(julubutton_click);//使用事件函数句柄指向一个具体的函数
                   

                    //bt2.Click += new EventHandler(this.julubutton_click);

                    Button bt3 = new Button();
                    bt3.Text = "洗气";
                    bt3.ID = "buttun0" + btindex.ToString();
                    panel0.Controls.Add(bt3);
                    btindex = btindex + 1;
                    bt3.Click += new EventHandler(julubutton_click);//使用事件函数句柄指向一个具体的函数
                    


                    Button bt4 = new Button();
                    bt4.Text = "记录";
                    bt4.ID = "buttun0" + btindex.ToString();
                    panel0.Controls.Add(bt4);
                    btindex = btindex + 1;
                  

                    panel0.BorderColor = Color.Blue;
                    panel0.BorderWidth = 3;
                    panel0.Font.Size = 15;

                    Label tempbr = new Label();
                    tempbr.Text = "<br />";
                    tempbr.ID = "Labelbr" + panelindex.ToString();

                    if (panelindex % 2 == 1)
                    {
                        this.Panel1.Controls.Add(panel0);
                        this.Panel1.Controls.Add(tempbr);
                    }
                    else
                    {
                        this.Panel2.Controls.Add(panel0);
                        this.Panel2.Controls.Add(tempbr);
                    }

                    panelindex += 1;
                }

           

        }

        protected void julubutton_click(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;

            string[] ids = btn.ID.Split('0');

            int ind = int.Parse(ids[1])/4+1;

            string oid = ind.ToString();


            string str = "<script>window.open('addjilu.aspx?oid=" +
                oid + "&type=" + btn.Text +
                "','_blank')</script>";
            Response.Write(str);

        }


        protected void setbutton_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string[] ids = btn.ID.Split('0');

            int ind = int.Parse(ids[1]) / 4 + 1;

            string oid = ind.ToString();


            string str = "<script>window.open('setobject.aspx?oid=" +
                oid+"','_blank')</script>";
            Response.Write(str);

        }




    }
}