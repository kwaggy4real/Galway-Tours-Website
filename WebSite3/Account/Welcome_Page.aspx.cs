using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite3;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.AspNet.Identity;


public partial class Welcome_Page : System.Web.UI.Page
{
    string idnumber;
    string attractionName;
    string address;
    string WebAddress;
    string information;
    int tel_num;
    string category;
    string email;
    SqlCommand cmd;
    string imageID;

    List<Welcome_Page> pg1 = new List<Welcome_Page>();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DataBind();
        if (!IsPostBack)
        {

            string retrieveSql = @"Select Comp_Name from Details  Where UserId =" + "'" + Context.User.Identity.GetUserName() + "'";
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

        }
    }


        public Welcome_Page()
        {
            
        }
        public Welcome_Page(string attractionName, string addr, string Webaddr, string info, int tel, string cat, string email)
        {
            this.attractionName = attractionName;
            address = addr;
            WebAddress = Webaddr;
            information = info;
            tel_num = tel;
            category = cat;
            this.email = email;
        }     

        protected void redirectHome(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Welcome_Page.aspx");
        }
        protected void redirectDetails(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Details.aspx");
        }
        protected void redirectEditDetails(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Edit_Details.aspx");
        }
    }

