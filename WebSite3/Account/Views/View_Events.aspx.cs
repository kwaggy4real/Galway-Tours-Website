using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.AspNet.Identity;
using WebSite3;
using System.IO;


public partial class Account_Views_View_Events : System.Web.UI.Page
{
    string eventId;
    string eventName;
    string location;
    DateTime startDate;
    string start_Date;
    string end_Date;
    DateTime endDate;
    string information;
    SqlCommand cmd;
    string imageID;

    //creates new list of image ID's
    List<String> IM_ID = new List<String>();


    public Account_Views_View_Events()
    {

    }
    public Account_Views_View_Events(string eventname, string loc, DateTime start, DateTime end, string info)
    {
        this.eventName = eventname;
        location = loc;
        startDate = start;
        endDate = end;
        this.information = info;
    }

    public List<String> getList()
    {

        return IM_ID;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        this.DataBind();
        if (!IsPostBack)
        {

            string retrieveSql = @"Select Event_Name from Events_Table  Where UserId =" + "'" + Context.User.Identity.GetUserName() + "'";
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

            //SqlDataReader rdr = null;
            conn.Open();
            buss_select.DataSource = myCommand.ExecuteReader();
            buss_select.DataTextField = "Event_Name";
            buss_select.DataValueField = "Event_Name";
            buss_select.DataBind();
        }

        selectData();
       
        DataSet data = getImagesID();
        Repeater1.DataSource = data;
        Repeater1.DataBind();
        Repeater1.DataBind();

        string a = Request.QueryString["ImageID"];
        if (Request.QueryString["ImageID"] != null)
        {

            string strQuery = "select Name, Data from Image_1 where id=@id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@id", Request.QueryString["ImageID"]);
            DataTable dt = GetData(cmd);
            // SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            if (dt != null)
            {

                Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = dt.Rows[0]["ContentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Name"].ToString());
                Response.BinaryWrite(bytes);

                Response.Flush();
                Response.End();
                i += 1;
            }
            i = 0;
        }
        
    }

    public void selectData()
    {
        if (buss_select.Items.Count == 0)
        {
            select_buss.Visible = false;
            buss_select.Items.Add("(Empty)");
            uploadImagebutton.Enabled = false;
        }
        else
        {
            string buss_1 = buss_select.SelectedItem.Text;

            string retrieveSql = @"Select * from Events_Table  Where UserId =" + "'" + Context.User.Identity.GetUserName() + "' and Event_Name =" + "'" + buss_1 + "'";
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
                    eventId = (String)rdr["Event_Id"];
                    eventName = (String)rdr["Event_Name"];

                    location = (String)rdr["Location"];


                    startDate = (DateTime)rdr["Start_Date"];
                    endDate = (DateTime)rdr["End_Date"];
                    information = (String)rdr["Information"];

                    imageID = (String)rdr["Image_ID"];
                    if (imageID != "")
                    {
                        Session["Image_ID"] = imageID;
                    }

                    Account_Views_View_Events user1 = new Account_Views_View_Events(eventName, location, startDate, endDate, information);
                }

            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }
        }
    }


    public string getIDNumber()
    {
        return eventId;
    }
    public string getEventName()
    {
        if (eventName == null)
        {
            return "";
        }
        else
        {
            return eventName;
        }
    }
    public string getLocation()
    {
        if (location == null)
        {
            return "";
        }
        else
        {
            return location;
        }
    }
    public string getStartDate()
    {
        if (startDate == new DateTime(1753, 01, 01) || endDate == new DateTime(0001, 01, 01))
        {
            return ""; 
        }
        else
        {
            return startDate.ToShortDateString();
        }
    }
    public string getEndDate()
    {
        if (endDate == new DateTime(1754, 01, 01) || endDate == new DateTime(0001,01,01))
        {
            return "";
        }
        else
        {
            return endDate.ToShortDateString();
        }
    }

    public string getInformation()
    {
        if (information == null)
        {
            return "";
        }
        else
        {
            return information;
        }
    }

    public string getImageID()
    {

        if (imageID == null)
        {
            return "";
        }
        else
        {

            return imageID;

        }
    }

    public void DeleteDetails_Click(object sender, EventArgs e)
    {
        string retrieveSql = @"Delete from Events_Table Where Event_Name =" + "'" + eventName + "'" + "and UserId =" + "'" + Context.User.Identity.GetUserName() + "'";

        //To read from the table
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

            SqlDataReader rdr = null;
            conn.Open();
            myCommand.ExecuteNonQuery();
            rdr = myCommand.ExecuteReader();

            Response.Redirect("~/Account/Views/View_Events.aspx");

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

    protected void uploadImage(object sender, EventArgs e)
    {
        string Id = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12);
        string Image_ID = getImageID();
        DateTime End_Date = DateTime.Now;
        string filePath = FileUpload1.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename);
        string contenttype = String.Empty;

        switch (ext)
        {
            case ".doc":
                contenttype = "application/vnd.ms-word";
                break;
            case ".docx":
                contenttype = "application/vnd.ms-word";
                break;
            case ".xls":
                contenttype = "application/vnd.ms-excel";
                break;
            case ".xlsx":
                contenttype = "application/vnd.ms-excel";
                break;
            case ".jpg":
                contenttype = "image/jpg";
                break;
            case ".png":
                contenttype = "image/png";
                break;
            case ".gif":
                contenttype = "image/gif";
                break;
            case ".pdf":
                contenttype = "application/pdf";
                break;
        }

        if (contenttype != String.Empty)
        {
            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            string strQuery = "Insert into Image_1(Id, Image_ID, Name,Data,dateUploaded)" + " values (@Id, @Image_ID, @Name,@Data,@dateUploaded)";


            SqlCommand cmd;


            try
            {

                SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");


                //put back userId
                cmd = new SqlCommand(strQuery, conn);

                //Student Permits
                cmd.Parameters.Add("@Id", Id.ToString());
                cmd.Parameters.Add("@Image_ID", Image_ID.ToString());
                cmd.Parameters.Add("@Name", filename.ToString());
                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.Add("@dateUploaded", End_Date);

                //Uploads to Database
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("~/Account/Views/View_Events.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    protected DataSet getImagesID()
    {
        SqlDataReader rdr = null;
        string readString = @"SELECT id FROM Image_1 where Image_ID= " + "'" + getImageID() + "'";

        SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
        SqlDataAdapter read = new SqlDataAdapter(readString, conn);
        DataSet ds = new DataSet();
        read.Fill(ds);
        return ds;
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        //SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
        SqlConnection con = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");

        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }

    public void deleteImage1(object sender, CommandEventArgs e)
    {
        string id = e.CommandName;

        string deleteSql = @"Delete  from Image_1  Where id =" + "'" + id + "'";

        //To read from the table
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(deleteSql, conn);

            SqlDataReader rdr = null;
            conn.Open();
            myCommand.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("~/Account/Views/View_Hotel.aspx");

        }
        catch (Exception es)
        {
            Console.WriteLine(es.Message);
        }
    }
}