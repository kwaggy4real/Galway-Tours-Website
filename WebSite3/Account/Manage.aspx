<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Account_Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    </div>
    </nav>

    <nav>
       <div class ="list-group">
         <a href="Welcome_Page.aspx" class="list-group-item">Home</a>
        <a href="Details.aspx" class="list-group-item">Upload Business/Hotels, etc</a>   
        <a href="Events.aspx" class="list-group-item">Upload Event</a>
           <ul>  
             <li>
              <a href=# class="list-group-item">View Uploaded: </a>   
                   <ul>
                       <li><a href="Views/View_Hotel.aspx" class="list-group-item">Hotels</a></li>
                       <li><a href="Views/View_Hostels.aspx" class="list-group-item">Hostels </a></li>
                       <li><a href="Views/View_Restaur_Pub.aspx" class="list-group-item">Restaurant/Pub</a></li>
                       <li><a href="Views/View_Events.aspx" class="list-group-item">Events</a></li>
                       <li><a href="Views/View_Attractions.aspx" class="list-group-item">Attractions</a>
                   </ul>
               </li>
           </ul>
    </div>
    </nav>   

     <div id="upload_content">
    <h2><%: Title %>.</h2>

            <section id="manage_div">         
                    <div class="form-horizontal">
                        <fieldset>
                    <legend><em>Change Password Form</em></legend>                         
                        <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Old Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="oldpassword" TextMode="Password"  CssClass="form-control"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password"
                                    CssClass="text-danger" ErrorMessage="The password field is required."
                                    Display="Dynamic" />
                                <asp:ModelErrorMessage ID="ModelErrorMessage2" runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>                        
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">New Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="password" TextMode="Password"  CssClass="form-control"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password"
                                    CssClass="text-danger" ErrorMessage="The password field is required."
                                    Display="Dynamic" ValidationGroup="SetPassword" />
                                <asp:ModelErrorMessage ID="ModelErrorMessage1" runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="confirmPassword" CssClass="col-md-2 control-label">Confirm New password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password"  CssClass="form-control"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="confirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                    ValidationGroup="SetPassword" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                    ValidationGroup="SetPassword" />
                            </div>
                        </div>
                     <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="Button2" runat="server" Text="Change password" OnClick="ChangePassword_Click" CssClass="btn btn-default" ValidationGroup="ChangePassword" />                              
                  </div>
                        </div> 
                 <p></p>   <a href="deleteAccount.aspx">Delete Account??</a>
                        </fieldset>
                    </div>    
                         
            </section>
         </div>
 
         

</asp:Content>
