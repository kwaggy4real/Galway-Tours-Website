<%@ Page Title="Welcome Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Welcome_Page.aspx.cs" Inherits="Welcome_Page" %>
 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">   
  
    <link rel="stylesheet" href="~/Content/Site.css" type="text/css"/> 

        <% if (User.Identity.IsAuthenticated == false)
      {
          Response.Redirect("Login.aspx");

          Welcome_Page userdetails1 = new Welcome_Page();                         
         // userdetails1.readData(); 
      }
   %>
   
    <nav>
       <div class ="list-group">
        <a href="Welcome_Page.aspx" class="list-group-item">Home</a>
        <a href="Details.aspx" class="list-group-item">Upload Business/Hotels,etc.</a>  
        <a href="Events.aspx" class="list-group-item">Upload Event</a>              
       
       
           <ul>  
             <li>
              <a href=# class="list-group-item">View Uploaded: </a>   
                   <ul>
                       <li><a href="Views/View_Hotel.aspx" class="list-group-item">Hotels</a></li>
                       <li><a href="Views/View_Hostels.aspx" class="list-group-item">Hostels </a></li>
                        <li><a href="Views/View_Events.aspx" class="list-group-item">Events</a></li>
                       <li><a href="Views/View_Restaur_Pub.aspx" class="list-group-item">Restaurant/Pub</a></li>
                       <li><a href="Views/View_Attractions.aspx" class="list-group-item">Attractions</a>
                   </ul>
               </li>
           </ul>
         </div>
    </nav>


    <div id="upload_content">        
        <div id="info_div">
            <h2> Welcome <% Context.User.Identity.GetUserName().ToString(); %></h2>
            <table>
             
            <tr>
                <td> <label> Number of Hotels:</label><br /></td>
            </tr>
             <tr>
                <td> <label>  Number of Hostels:</label> <br /></td>
            </tr>
            <tr>
                <td> <label>  Number of Restaurants/Pubs:</label> <br /></td>
            </tr>
            <tr>
                <td> <label> Number of Events:</label> <br /></td>
            </tr>
            <tr>
                <td> <label>   Number of Tourist Attractions:</label> <br /></td>
            </tr>
            <tr>
                <td> <label> Average Upload Ratings:</label><br /></td>
            </tr>
                     
        </table>
         </div>

          <div id="live_feed">
              <h1>Live feed will be placed here!!!</h1>
          </div>

 
    </div>               
</asp:Content>
