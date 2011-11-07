<%@ Page Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Markers - Custom Icons</title>
    <meta name="description" content="GoogleMap control markers' custom icons sample." />
    <meta name="keywords" content="googlemap control markers custom icons sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers Custom Icons
    </h1>
    <p>
        GoogleMap control markers' custom icons sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="6" BorderStyle="Solid" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server">
            <Markers>
                <artem:Marker Address="plovdiv" Title="Click on the marker" Info="Text of marker 1"
                    Icon-Url="/images/icons/sun.png" Shadow-Url="/images/icons/sun-shadow.png">
                </artem:Marker>
                <artem:Marker Position-Latitude="42.7" Position-Longitude="23.3" Title="Click on the marker"
                    Info="Text of marker 2">
                    <Icon Url="/images/icons/rain.png"></Icon>
                    <Shadow Url="/images/icons/rain-shadow.png"></Shadow>
                </artem:Marker>
            </Markers>
            <MarkerOptions Draggable="true">
            </MarkerOptions>
        </artem:GoogleMarkers>
    </div>
</asp:Content>
