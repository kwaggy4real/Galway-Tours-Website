<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <link rel="stylesheet" href="~/Content/Site.css" type="text/css"/> 

       <% if (User.Identity.IsAuthenticated == true)
      {
          Response.Redirect("~/Account/Welcome_Page");
      }
   %>
  
         <!--    <div id="login_div"> <section id="loginForm">
                <fieldset>
                    <legend><em>Login</em></legend> 
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="Button1" runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" /><br />
                            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                             if you don't have an account with us.
                             
                        </div>
                    </div>  
                    </div>   
                    </fieldset> </div>        
            </section>-->

    <div id="carousel" >
    	<div class="row clearfix">
		<div class="col-md-12 column">
			<div class="carousel slide" id="carousel-528655">
				<ol class="carousel-indicators">
					<li data-slide-to="0" data-target="#carousel-528655" class="active">
					</li>
					<li data-slide-to="1" data-target="#carousel-528655">
					</li>
					<li data-slide-to="2" data-target="#carousel-528655" >
					</li>
                    <li data-slide-to="3" data-target="#carousel-528655">
					</li>
					<li data-slide-to="4" data-target="#carousel-528655">
					</li>
					<li data-slide-to="5" data-target="#carousel-528655" >
					</li>
				</ol>
				<div class="carousel-inner">
					<div class="item">
						<img  src="/Images/Background.jpg" style="height: 600px; width: 100%;">
						<div class="carousel-caption">
							<h4>
								First Thumbnail label
							</h4>
							<p>
								Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
							</p>
						</div>
					</div>                   
					<div class="item">
						<img alt="" style="height: 600px; width: 100%;" src="/Images/cathedral.jpg">
						<div class="carousel-caption">
							<h4>
								Second Thumbnail label
							</h4>
							<p>
								Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
							</p>
						</div>
					</div>
                    	<div class="item">
						<img alt="" style="height: 600px; width: 100%;" src="/Images/cliffs of moher.jpg">
						<div class="carousel-caption">
							<h4>
								Second Thumbnail label
							</h4>
							<p>
								Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
							</p>
						</div>
					</div>
                    	<div class="item">
						<img alt="" style="height: 600px; width: 100%;" src="/Images/eyre square.jpg">
						<div class="carousel-caption">
							<h4>
								Second Thumbnail label
							</h4>
							<p>
								Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
							</p>
						</div>
					</div>
                    	<div class="item">
						<img alt="" style="height: 600px; width: 100%;" src="/Images/the docks.jpg">
						<div class="carousel-caption">
							<h4>
								Second Thumbnail label
							</h4>
							<p>
								Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
							</p>
						</div>
					</div>
					<div class="item active">
						<img alt="" style="height: 600px; width: 100%;" src="/Images/nui galway.jpg">
						<div class="carousel-caption">
							<h4>
								Third Thumbnail label
							</h4>
							<p>
								Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
							</p>
						</div>
					</div>
				</div> <a class="left carousel-control" href="#carousel-528655" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a> <a class="right carousel-control" href="#carousel-528655" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
			  </div>
		</div>
	</div>
     </div>


     
        <div id="login_div">
            <section id="loginForm">
                 <fieldset>
                    <legend><em>Login</em></legend> 
        <asp:Login ID="Login1" runat="server">
            <LayoutTemplate>  
                <div class="form-group">           
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                
                <asp:TextBox ID="UserName" runat="server" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
               
                    </div>

                 <div class="form-group"> 
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                              
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                             
                     </div>

                 <div class="form-group">
                            <div class="checkbox">
                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." /> 
                    </div>
                     
                     </div>                         
                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                             
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="btn btn-default" ValidationGroup="Login1" />
               <br />
               <br /> <a href="Recover.aspx">Forgot your password?</a>         
            </LayoutTemplate>
        </asp:Login>
                     </fieldset>
                </section>
            </div>
       
   
        <!--
        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:openauthproviders runat="server" id="OpenAuthLogin" />
            </section>
        </div>-->
    
   
</asp:Content>

