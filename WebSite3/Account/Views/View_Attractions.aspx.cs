﻿using System;
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

public partial class Account_Views_View_Attractions : System.Web.UI.Page
{
        string idnumber;
        string Attractions;
        string address;
        string WebAddress;
        string information;
        string tel_num;
        string category;
        string email;
        SqlCommand cmd;
        string imageID;

    
        public Account_Views_View_Attractions()
        {
            
        }
        public Account_Views_View_Attractions(string attractionName, string addr, string Webaddr, string info, string tel, string cat, string email)
        {
            this.Attractions = attractionName;
            address = addr;
            WebAddress = Webaddr;
            information = info;
            tel_num = tel;
            category = cat;
            this.email = email;
        }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        this.DataBind();
        if (!IsPostBack)
        {         

            string retrieveSql = @"Select Comp_Name from Details  Where UserId =" + "'" + Context.User.Identity.GetUserName() + "'" + " and Category = 'Attractions'";;
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

            //SqlDataReader rdr = null;
            conn.Open();
            buss_select.DataSource = myCommand.ExecuteReader();
            buss_select.DataTextField = "Comp_Name";
            buss_select.DataValueField = "Comp_Name";
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

            string retrieveSql = @"Select * from Details  Where UserId =" + "'" + Context.User.Identity.GetUserName() + "' and Comp_Name =" + "'" + buss_1 + "'";
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
                    Attractions = (String)rdr["Comp_Name"];

                    address = (String)rdr["Address"];

                    WebAddress = (String)rdr["Website"];

                    information = (String)rdr["Information"];

                    //converts telephone numer fo integer
                     tel_num = (String)rdr["Telephone_Number"];
                  //  tel_num = System.Int32.Parse(tel);

                    category = (String)rdr["Category"];

                    email = (String)rdr["Email"];

                    imageID = (String)rdr["Image_ID"];
                 //   Session["Image_ID"] = imageID;

                    Account_Views_View_Attractions user1 = new Account_Views_View_Attractions(Attractions, address, WebAddress, information, tel_num, category, email);
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
        return idnumber;
    }
    public string getAttractions()
    {
        if (Attractions == null)
        {
            return "";
        }
        else
        {
            return Attractions;
        }
    }
    public string getAddress()
    {
        if (address == null)
        {
            return "";
        }
        else
        {
            return address;
        }
    }
    public string getWebAddress()
    {
        if (WebAddress == null)
        {
            return "";
        }
        else
        {
            return WebAddress;
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
    public string getTel_num()
    {
        if (tel_num == null || tel_num.ToString() == "")
        {
            return "";
        }
        else
        {
            return tel_num;
        }
    }
    public string getCategory()
    {
        if (category == null)
        {
            return "";
        }
        else
        {
            return category;
        }
    }
    public string getEmail()
    {
        if (email == null)
        {
            return "";
        }
        else
        {
            return email;
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
        string retrieveSql = @"Delete from Details Where Comp_Name =" + "'" + Attractions + "'" + "and UserId =" + "'" + Context.User.Identity.GetUserName() + "'";

        //To read from the table
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");
            SqlCommand myCommand = new SqlCommand(retrieveSql, conn);

            SqlDataReader rdr = null;
            conn.Open();
            myCommand.ExecuteNonQuery();
            rdr = myCommand.ExecuteReader();

            Response.Redirect("~/Account/Views/View_Attractions.aspx");

        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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
                Response.Redirect("~/Account/Views/View_Attractions.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        Session["Name"] = getAttractions();
        Response.Redirect("~/Account/Edit_Details.aspx");
       
    }


    protected void redirectUploadImage(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/upload_Image.aspx");
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