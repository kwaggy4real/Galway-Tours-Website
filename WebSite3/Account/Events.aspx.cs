using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;



public partial class Account_Events : System.Web.UI.Page
{
    static bool param;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (param == true)
        {
            Label lbl = new Label();
            lbl.Text = "*Invalid Date Entry*";
            lbl.Visible = true;
            div2.Controls.Add(lbl);
        }
        else { param = false; }
        
    }
    
    protected void submitEvent(object sender, EventArgs e)
    {
        string eventID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12);
        string eventName = Event_Name.Text;
        string Location = location.Text;
        string start_day = Start_Day.Text;
        string start_month = Start_Month.Text;
        string start_year = Start_Year.Text;
        string end_day = End_Day.Text;
        string end_month = End_Month.Text;
        string end_year = End_Year.Text;
        DateTime Start_Date = new DateTime();
        DateTime End_Date = new DateTime();
        param = false;

        if (start_day != "" && start_month != "" && start_year != "")
        {
             Start_Date = new DateTime(System.Int32.Parse(start_year), System.Int32.Parse(start_month), System.Int32.Parse(start_day));
             int val = Start_Date.CompareTo(DateTime.Now);
             if (val < 0)
             {
                 param = true;
                 Response.Redirect("~/Account/Events.aspx");
             }
        }       
        else
        {
            if(start_day != "" || start_month != "" || start_year != "")
            {
                param = true;
                Response.Redirect("~/Account/Events.aspx");
            }
            Start_Date = new DateTime(1753,01,01);
          
        }


        //submits end Date
        if(end_day != "" && end_month != "" && end_year != "")
        {
            End_Date = new DateTime(System.Int32.Parse(end_year), System.Int32.Parse(end_month), System.Int32.Parse(end_day));
            int val = Start_Date.CompareTo(End_Date);
            if (val > 0)
            {
                param = true;
                Response.Redirect("~/Account/Events.aspx");              
            }
        }        
        else
        {
            if (end_day != "" || end_month != "" || end_year != "")
            {
                param = true;
                Response.Redirect("~/Account/Events.aspx");
            }
            End_Date =  new DateTime(1754,01,01);
        }

        string Information = information.Text;
        SqlCommand cmd;
        string imageID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);

        try
        {
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");


            //put back userId
            cmd = new SqlCommand("INSERT INTO Events_Table(Event_Id,Event_Name, Location, Start_Date,End_Date, Information, UserId,Image_Id) VALUES (@Event_Id,@Event_Name, @Location, @Start_Date,@End_Date, @Information, @UserId,@Image_Id);", conn);

            //Student Permits
            cmd.Parameters.Add("@Event_Id", eventID.ToString());
            cmd.Parameters.Add("@Event_Name", eventName.ToString());
            cmd.Parameters.Add("@Location", Location.ToString());
            cmd.Parameters.Add("@Start_Date", Start_Date);
            cmd.Parameters.Add("@End_Date", End_Date);
            cmd.Parameters.Add("@Information", Information.ToString());
            cmd.Parameters.Add("@UserId", Context.User.Identity.GetUserName().ToString());
            cmd.Parameters.Add("@Image_Id", imageID.ToString());

            //Uploads to Database
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("~/Account/Views/View_Events.aspx");
            
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Account/Events.aspx");
            Console.WriteLine(ex.Message);
        }
        finally
        {
           
        }
    }


}