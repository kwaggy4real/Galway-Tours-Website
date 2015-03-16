<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="View_Events.aspx.cs" Inherits="Account_Views_View_Events" %>
<%@ Import Namespace="WebSite3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<link rel="stylesheet" href="~/Content/Site.css" type="text/css"/>

 <% if (User.Identity.IsAuthenticated == false)
      {
          Response.Redirect("~/Account/Login.aspx");
      }
   %>


     <nav>
       <div class ="list-group">
        <a href="../Welcome_Page.aspx" class="list-group-item">Home</a>
        <a href="../Details.aspx" class="list-group-item">Upload Business/Hotels,etc...</a>
        <a href="../Events.aspx" class="list-group-item">Upload Event</a>
           <ul>  
             <li>
              <a href=# class="list-group-item">View Uploaded: </a>   
                   <ul>
                       <li><a href="View_Hotel.aspx" class="list-group-item">Hotels</a></li>
                       <li><a href="View_Hostels.aspx" class="list-group-item">Hostels</a></li>
                       <li><a href="View_Events.aspx" class="list-group-item">Events</a></li>
                       <li><a href="View_Restaur_Pub.aspx" class="list-group-item">Restaurant/Pub</a></li>
                       <li><a href="View_Attractions.aspx" class="list-group-item">Attractions</a>
                   </ul>
               </li>
           </ul>
    </div>
    </nav>

     <div id="upload_content">
                <p>The Home Page of the Galway Tours Website</p>
        <table>
             <tr>
                <td> <label>Select: </label>  <asp:DropDownList ID="buss_select" CssClass="droplist" runat="server" >
                    </asp:DropDownList>

                    <asp:Button runat="server" ID="select_buss" Text="Search" CssClass="btn btn-default" OnClick="Page_Load" />
                  <br /></td>
            </tr>
            <tr>
                <td> <label>Name:</label><%= getEventName().ToString() %><br /></td>
            </tr>
             <tr>
                <td> <label> Start Date:</label> <%= getStartDate().ToString() %><br /></td>
            </tr>
            <tr>
                <td> <label> End Date:</label> <%= getEndDate().ToString() %><br /></td>
            </tr>
            <tr>
                <td> <label> Location:</label> <%=getLocation().ToString() %><br /></td>
            </tr>
            <tr>
                <td> <label> Information:</label> <%= getInformation().ToString() %> <br /></td>
            </tr>            
        </table>
         <asp:Button Text="Delete Event" runat="server" CssClass="btn btn-default" OnClick="DeleteDetails_Click" />
        <p></p> <asp:Button Text="Edit Event" runat="server" CssClass="btn btn-default" OnClick="redirectEditDetails" /><br />
        
         <div><asp:FileUpload ID="FileUpload1" runat="server" />
          <p></p> <asp:Button ID="uploadImagebutton" Text="Upload Images" runat="server" CssClass="btn btn-default" OnClick="uploadImage" /><br /> 
             </div>                                       

         <div class="ImageGallery">
          <h3 style="font-style: italic; color: red; font-weight:300; margin-left: auto; margin-right: auto;">Photos</h3>
  <asp:ListView  runat="server"  ID="Repeater1"  GroupItemCount="5">

   <LayoutTemplate>
      <table>
         <tr>
            <td>
               <table border="0" cellpadding="5">
                  <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
               </table>
            </td>
         </tr>
      </table>
   </LayoutTemplate>

   <GroupTemplate>
      <tr>
         <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
      </tr>
   </GroupTemplate>

   <ItemTemplate>      
                     <td>                          
                     <img src='<%# "View_Events.aspx?ImageID=" + Eval("id") %>' id="Image_Display"/>
                          <asp:Panel ID="panel1" Visible="true" runat="server" >  
                          <asp:LinkButton ID="deleteButton" Text="Delete Image" OnCommand="deleteImage1" CssClass="btn btn-default" CommandName='<%# Eval("id") %>' runat="server"/>                            
                         </asp:Panel>
                     </td>
   </ItemTemplate>
</asp:ListView>   
             </div>         	
     </div>
</asp:Content>

