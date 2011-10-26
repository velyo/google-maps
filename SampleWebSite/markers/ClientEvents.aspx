<%@ Page Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Markers - Client Events</title>
    <meta name="description" content="GoogleMap - Markers." />
    <meta name="keywords" content="asp.net googlemap control markers" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers - Client Events
    </h1>
    <p>
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true">
        </artem:GoogleMap>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server">
            <Markers>
                <artem:Marker Position-Latitude="42.1229" Position-Longitude="24.7879" Title="Click on the marker"
                    Info="Text of marker 1">
                </artem:Marker>
                <artem:Marker Position-Latitude="42.1229" Position-Longitude="20." Title="Click on the marker"
                    Info="Text of marker 2">
                </artem:Marker>
            </Markers>
            <MarkerOptions Draggable="true">
            </MarkerOptions>
        </artem:GoogleMarkers>
    </div>
</asp:Content>
