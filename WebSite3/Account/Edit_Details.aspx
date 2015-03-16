<%@ Page Title="Edit Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Edit_Details.aspx.cs" Inherits="Account_Edit_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
        <h2><%: Title %></h2>
    <h3>Only Fill Out Necessary Fields</h3>
   <div><label>Business Name: </label> <% Response.Write(Session["Name"]); %> </div><br />
    <div><label>Address: </label><asp:TextBox id="Address" runat="server" CssClass="form-control" Placeholder="e.g. 8 Moyola Park, ...." />   </div> <br />
    <div><label>Website: </label><asp:TextBox id="webAddress" runat="server" CssClass="form-control" Placeholder="e.g. www.blueskies.com" />  </div>  <br />
    <div><label>Information: </label><asp:TextBox id="Information" required="Please Enter some Information" runat="server" CssClass="form-control" TextMode="multiline" Placeholder="e.g. Description, faliclities, etc" /></div><br />
    <div><label>Telephone Number: </label><asp:TextBox id="Telephone_Number" runat="server" CssClass="form-control" Placeholder="098767663" /></div><br />
     <div><label>Category: </label><asp:DropDownList id="drop1" runat="server">
        <asp:ListItem>Hotel</asp:ListItem>
        <asp:ListItem>Attractions</asp:ListItem>
        <asp:ListItem>Hostels</asp:ListItem>
        <asp:ListItem>Restaurants/Pubs</asp:ListItem>
        </asp:DropDownList></div><br />
     <div><label>Email: </label><asp:TextBox id="emailbox1" runat="server" CssClass="form-control" Placeholder="email@email.com" /></div><br />
   <p>  </p> <asp:Button ID="submitdetails"  OnClick="Update" Text="Save" runat="server" />
         </div>
</asp:Content>

