<%@ Page Title="Delete Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="deleteAccount.aspx.cs" Inherits="Account_deleteAccount" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
<link rel="stylesheet" href="~/Content/Site.css" type="text/css"/>

       <% if (User.Identity.IsAuthenticated == false)
      {
          Response.Redirect("Login.aspx");
      }
   %>

    <nav>
       <div class ="list-group">
        <a href="Welcome_Page.aspx" class="list-group-item">Home</a>
        <a href="Details.aspx" class="list-group-item">Upload Business/Event</a>
           <ul>  
             <li>
              <a href=# class="list-group-item">View Uploaded: </a>   
                   <ul>
                       <li><a href="Views/View_Hotel.aspx" class="list-group-item">Hotels</a></li>
                       <li><a href="Views/View_Hostels.aspx" class="list-group-item">Hostels </a></li>
                       <li><a href="Views/View_Restaur_Pub.aspx" class="list-group-item">Restaurant/Pub</a></li>
                       <li><a href="View_Events.aspx" class="list-group-item">Events</a></li>
                       <li><a href="Views/View_Attractions.aspx" class="list-group-item">Attractions</a>
                   </ul>
               </li>
           </ul>
    </div>
    </nav>

   

     <div id="upload_content">
               
           <div>
               <p>Are you sure you want to Delete your account??</p><br />
                <p>All your Uploads will be deleted!!</p>
               <asp:Button Text="Yes" runat="server" CssClass="btn btn-default" OnClick="DeleteAccount_Click" /><br />
           </div>                                      
         </div>
</asp:Content>

