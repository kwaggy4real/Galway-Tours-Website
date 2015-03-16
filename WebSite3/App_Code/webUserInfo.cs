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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Collections;

/// <summary>
/// Summary description for webUserInfo
/// </summary>
/// 
namespace WebSite3
{
    public class webUserInfo : Page
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

        public webUserInfo()
        {

        }
        public webUserInfo(string attractionName, string addr, string Webaddr, string info, int tel, string cat, string email)
        {
            this.attractionName = attractionName;
            address = addr;
            WebAddress = Webaddr;
            information = info;
            tel_num = tel;
            category = cat;
            this.email = email;
        }

        public void readData()
        {
            string retrieveSql = "Select * from Users as e INNER JOIN Details as p on e.UserId = p.UserId Where e.UserId = p.UserId";

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
                    attractionName = (String)rdr["Comp_Name"];
                    Session["Name"] = attractionName;
 
                    address = (String)rdr["Address"];
                    Session["Address"] = address;

                    WebAddress = (String)rdr["Website"];
                    Session["WebSite"] = WebAddress;

                    information = (String)rdr["Information"];
                    Session["information"] = information;
                    //converts telephone numer fo integer
                    string tel = (String)rdr["Telephone_Number"];
                    tel_num = System.Int32.Parse(tel);
                    Session["Telephone"] = tel_num;

                    category = (String)rdr["Category"];
                    Session["Category"] = category;

                    email = (String)rdr["Email"];
                    Session["Email"] = email;

                    imageID = (String)rdr["Image_ID"];
                    Session["Image_ID"] = imageID;
                    webUserInfo user1 = new webUserInfo(attractionName, address, WebAddress, information, tel_num, category, email);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string getIDNumber()
        {
            return idnumber;
        }
        public string getAttractionName()
        {
            return attractionName;
        }
        public string getAddress()
        {
            return address;
        }
        public string getWebAddress()
        {
            return WebAddress;
        }
        public string getInformation()
        {
            return information;
        }
        public int getTel_num()
        {
            return tel_num;
        }
        public string getCategory()
        {
            return category;
        }
        public string getEmail()
        {
            return email;
        }
        public string getImageID()
        {
            return imageID;
        }
    }
}