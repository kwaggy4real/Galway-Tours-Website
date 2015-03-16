<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"  >
<link rel="stylesheet" href="~/Content/Site.css" type="text/css"/> 
<link href="~/Content/bootstrap.min.css" rel="stylesheet">
<link href="~/Content/style.css" rel="stylesheet">
    
    <% if (User.Identity.IsAuthenticated == true)
       {
           Response.Redirect("Account/Welcome_Page.aspx");
       } %>

    <script type="text/javascript">
        var imagecount = 1;
        var totalimages = 5;

        window.setInterval(function slide(x) {
            var Image = document.getElementById('img');
            Image.src = "Images/Image" + imagecount + ".png";
            imagecount = imagecount + 1;

            if (imagecount > 5) {
                imagecount = 1;
            }
            if (imagecount < 1) {
                imagecount = 5;
            }
        }, 2000);

     
</script>

      <div id="defaultPage_div">
         
         <!--<img src="Images/Image1.png" id="img"/>  -->           
      <div id="div_extra" >
       Welcome to Galway City Tours and Guide!! <br />
       Join Us, and share what you have to offer!!<br />
       
      <asp:LinkButton ID="submitdetails" OnClick="Loginredirect" CssClass="btn btn-default" Text="Login" runat="server" />    
      <asp:LinkButton ID="registerbutton" OnClick="Registerredirect" CssClass="btn btn-default" Text="Register" runat="server" />    
      </div>
    </div>
<!--
    	<div class="row clearfix">
		<div class="col-md-12 column">
			<div class="carousel slide" id="carousel-528655">
				<ol class="carousel-indicators">
					<li data-slide-to="0" data-target="#carousel-528655">
					</li>
					<li data-slide-to="1" data-target="#carousel-528655">
					</li>
					<li data-slide-to="2" data-target="#carousel-528655" class="active">
					</li>
				</ol>
				<div class="carousel-inner">
					<div class="item">
						<img alt="" src="Images/Background.jpg">
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
						<img alt="" src="http://lorempixel.com/1600/500/sports/2">
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
						<img alt="" src="http://lorempixel.com/1600/500/sports/3">
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
    -->
</asp:Content>
