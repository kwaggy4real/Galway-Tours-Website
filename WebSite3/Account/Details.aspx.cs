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

public partial class Account_Details : Page
{

    protected void Submit(object sender, EventArgs e)
    {
       
                    string idnumber = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12);                    
                    string attractionName = Attraction_Name.Text;
                    string address = Address.Text;
                    string WebAddress = webAddress.Text;
                    string information = Information.Text;
                    string tel_num = Telephone_Number.Text;
                    string category = drop1.Text;
                    string email = emailbox1.Text;
                    SqlCommand cmd;
                    string imageID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
        
                    try
                    {
                        
                        SqlConnection conn = new SqlConnection("Data Source=LUGH3.it.nuigalway.ie;Initial Catalog=msdb1343;User ID=msdb1343;Password=msdb1343DA");

                        
                        //put back userId
                        cmd = new SqlCommand("INSERT INTO Details(IDNumber, UserId,Comp_Name, Address, Website,Information, Rating, Telephone_Number,Category,Email,Image_ID) VALUES (@IDNumber,@UserId,@Comp_Name, @Address, @Website,@Information, @Rating, @Telephone_Number,@Category,@Email,@Image_ID);", conn);

                        //Student Permits
                        cmd.Parameters.Add("@IDNumber", idnumber);
                        cmd.Parameters.Add("@UserId", Context.User.Identity.GetUserName());
                        cmd.Parameters.Add("@Comp_Name", attractionName);
                        cmd.Parameters.Add("@Address", address);
                        cmd.Parameters.Add("@Website", WebAddress);
                        cmd.Parameters.Add("@Information", information);
                        cmd.Parameters.Add("@Telephone_Number", tel_num);
                        cmd.Parameters.Add("@Category", category.ToString());
                        cmd.Parameters.Add("@Email", email);
                        cmd.Parameters.Add("@Rating","");
                        cmd.Parameters.Add("@Image_ID", imageID);


                        //Uploads to Database
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        switch(category.ToString())
                        {
                            case "Attractions":
                                Response.Redirect("~/Account/View_Attractions.aspx");
                                break;
                            case "Hotels":
                                Response.Redirect("~/Account/View_Hotel.aspx");
                                break;
                            case "Hostels":
                                Response.Redirect("~/Account/View_Hostels.aspx");
                                break;
                            case "Restaurants/Pubs":
                                Response.Redirect("~/Account/View_Restaur_Pub.aspx");
                                break;
                        }
                      }
                    catch (Exception ex)
                    {
                        Response.Redirect("~/Account/Details.aspx");
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

   
