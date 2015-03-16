using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using WebSite3;
using System.Web.Security;

public partial class Account_deleteAccount : System.Web.UI.Page
{

    protected void DeleteAccount_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Create the local login info and link the local account to the user
            if (Membership.DeleteUser(User.Identity.Name, true))
            {
                deleteDetailsTable();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }

        }
    }

    //Delets information from details table when the user deletes their account.
    public void deleteDetailsTable()
    {
        
        string retrieveSql = @"Delete from Details Where UserId =" + "'" + Context.User.Identity.GetUserName() + "'";

        //To read from the table
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

            SqlDataReader rdr = null;
            conn.Open();
            myCommand.ExecuteNonQuery();
            rdr = myCommand.ExecuteReader();
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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