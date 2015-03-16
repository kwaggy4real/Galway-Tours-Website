using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebSite3;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class Account_Edit_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Name1 = "";
        string address1 = "";
        string WebAddress1 = "";
        string information1 = "";
        string tel_num1 = "";
        string category = "";
        string email1 = "";
        SqlCommand cmd;

        if (!IsPostBack)
        {
            string retrieveSql = @"Select * from Details  Where UserId =" + "'" + Context.User.Identity.GetUserName() + "' and Comp_Name =" + "'" + Session["Name"] + "'";
            // string retrieveSql = @"Select * from Users Where UserName ='kwaggy4real'";
            //To read from the table
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
                SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

                SqlDataReader rdr = null;
                conn.Open();
                myCommand.ExecuteNonQuery();
                rdr = myCommand.ExecuteReader();

                while (rdr.Read())
                {
                    Name1 = (String)rdr["Comp_Name"];

                    address1 = (String)rdr["Address"];

                    WebAddress1 = (String)rdr["Website"];

                    information1 = (String)rdr["Information"];

                    //converts telephone numer fo integer
                    tel_num1 = (String)rdr["Telephone_Number"];
                    //tel_num = System.Int32.Parse(tel);
                    
                    email1 = (String)rdr["Email"];
                }
                conn.Close();

            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }

            populateFields( address1, WebAddress1, information1, tel_num1, email1);
        }
    }
    protected void populateFields(string addr, string web, string info, string telnum, string email)
    {
        Address.Text = addr;
        webAddress.Text = web;
        Information.Text = info;
        Telephone_Number.Text = telnum;
        emailbox1.Text = email;

    }
    protected void Update(object sender, EventArgs e)
    {

        string addr = Address.Text;
        string web = webAddress.Text;
        string info = Information.Text;
        string tel_num = Telephone_Number.Text;
        string email = emailbox1.Text;
        SqlCommand cmd;

        try
        {

            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            
            //put back userId
          
            string updateString = @"UPDATE Details SET Address ='" + addr.ToString() + "',Website ='" + web.ToString() + "',Information ='" + info.ToString() + "',Telephone_Number ='" + tel_num.ToString() + "',Email ='" + email.ToString() + "' WHERE UserId='" + Context.User.Identity.GetUserName() + "' and Comp_Name ='" + Session["Name"] + "'";
          
            //Uploads to Database
            cmd = new SqlCommand(updateString);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
           // Response.Redirect("~/Account/Welcome_Page.aspx");
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Account/Details.aspx");
            Console.WriteLine(ex.Message);
        }

        Response.Redirect("~/Account/Welcome_Page.aspx");
  
    }
  }
