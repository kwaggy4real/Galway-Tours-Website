<%@ Page Title="Upload Event" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Account_Events" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <style>
      html, body, #map-canvas {
        height: 100%;
        margin: 0px;
        padding: 0px
      }
      .controls {
        margin-top: 16px;
        border: 1px solid transparent;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        height: 32px;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
      }

      #pac-input {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 400px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

      .pac-container {
        font-family: Roboto;
      }

      #type-selector {
        color: #fff;
        background-color: #4d90fe;
        padding: 5px 11px 0px 11px;
      }

      #type-selector label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }

    </style>
    <title>Places search box</title>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&signed_in=true&libraries=places"></script>
    <script>
        // This example adds a search box to a map, using the Google Place Autocomplete
        // feature. People can enter geographical searches. The search box will return a
        // pick list containing a mix of places and predicted search terms.

        function initialize() {

            var markers = [];
            var map = new google.maps.Map(document.getElementById('map_content'), {
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var defaultBounds = new google.maps.LatLngBounds(
                new google.maps.LatLng(-33.8902, 151.1759),
                new google.maps.LatLng(-33.8474, 151.2631));
            map.fitBounds(defaultBounds);

            // Create the search box and link it to the UI element.
            var input = /** @type {HTMLInputElement} */(
                document.getElementById('pac-input'));
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

            var searchBox = new google.maps.places.SearchBox(
              /** @type {HTMLInputElement} */(input));

            // [START region_getplaces]
            // Listen for the event fired when the user selects an item from the
            // pick list. Retrieve the matching places for that item.
            google.maps.event.addListener(searchBox, 'places_changed', function (event) {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }
                for (var i = 0, marker; marker = markers[i]; i++) {
                    marker.setMap(null);
                }

                // For each place, get the icon, place name, and location.
                markers = [];
                var bounds = new google.maps.LatLngBounds();
                for (var i = 0, place; place = places[i]; i++) {
                    var image = {
                        url: place.icon,
                        size: new google.maps.Size(71, 71),
                        origin: new google.maps.Point(0, 0),
                        anchor: new google.maps.Point(17, 34),
                        scaledSize: new google.maps.Size(25, 25)
                    };

                    // Create a marker for each place.
                    var marker = new google.maps.Marker({
                        map: map,
                        icon: image,
                        title: place.name,
                        position: place.geometry.location
                    });
                    console.log(marker.getPosition());
                    var lat = marker.getPosition().lat();
                    var lng = marker.getPosition().lng();
                    document.getElementById('<%=latitude.ClientID%>').value = lat;
                    document.getElementById('<%=longitude.ClientID%>').value = lng;
                    markers.push(marker);

                    bounds.extend(place.geometry.location);
                }

                map.fitBounds(bounds);
            });
            // [END region_getplaces]

            // Bias the SearchBox results towards places that are within the bounds of the
            // current map's viewport.
            google.maps.event.addListener(map, 'bounds_changed', function () {
                var bounds = map.getBounds();
                searchBox.setBounds(bounds);

            });
        }



        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
    <style>
      #target {
        width: 345px;
      }
    </style>

     <link rel="stylesheet" href="~/Content/Site.css" type="text/css"/> 

        <% if (User.Identity.IsAuthenticated == false)
      {
          Response.Redirect("Login.aspx");           
      }
   %>

    <nav>
       <div class ="list-group">
        <a href="Welcome_Page.aspx" class="list-group-item">Home</a>
        <a href="Details.aspx" class="list-group-item">Upload Business/Hostels,etc.</a>
        <a href="Edit_Details.aspx" class="list-group-item">Edit Business/Hostels,etc.</a>
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
    <h2><%: Title %></h2>

        <div><label>Event Name: </label><asp:TextBox id="Event_Name"  runat="server" CssClass="form-control" Placeholder="eg. Galway Parade" required="Please Enter a Name"/>  </div><br />
        <div><label>Location: </label><asp:TextBox id="location" runat="server" CssClass="form-control" Placeholder="" required="Please Enter Location"/>  </div><br />
        <div><label>Start Date: </label><asp:TextBox id="Start_Day" MaxLength="2" runat="server" Width="45px" Placeholder="dd" />  / <asp:TextBox id="Start_Month" MaxLength="2" runat="server" Width="45px" Placeholder="mm"  /> / <asp:TextBox id="Start_Year" MaxLength="4" runat="server" Width="60px" Placeholder="YYYY"  /> </div> <br />
        <div><label>End Date: </label><asp:TextBox id="End_Day" MaxLength="2" runat="server" Width="45px" Placeholder="dd"  />  / <asp:TextBox id="End_Month" MaxLength="2" runat="server" Width="45px" Placeholder="mm"  /> / <asp:TextBox id="End_Year" MaxLength="4" runat="server" Width="60px" Placeholder="YYYY" /> </div> <br />
   
       <div id="div2" runat="server" style="font-size:larger; font-weight: 300; color: red;" ></div>
     
        <div><label>Information: </label><asp:TextBox id="information" runat="server" CssClass="form-control" TextMode="multiline"/>  </div><br />    
        <p>  </p> <asp:Button ID="submit_Event" OnClick="submitEvent" Text="Submit" runat="server" />
        
        <input id="pac-input"  type="text" placeholder="Search Box">
        <div id="map_content" >
             
        </div>
        <div id="lng_lat" >
           <asp:TextBox ID="longitude" runat="server" placeholder="longitude" Visible="true" />
        <asp:TextBox ID="latitude"  CssClass="btn btn-default" runat="server" placeholder="latitude" Visible="true"/>
        </div>
       </div>

</asp:Content>

