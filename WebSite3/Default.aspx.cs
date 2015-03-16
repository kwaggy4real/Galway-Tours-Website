using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      /*  if(User.Identity.IsAuthenticated == true)
        {
            Response.Redirect("Welcome_Page");
        }
        else
        {
            Response.Redirect("Default");
        }*/
    }

    public void Loginredirect(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Login.aspx");
    }

    public void Registerredirect(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Register.aspx");
    }
}