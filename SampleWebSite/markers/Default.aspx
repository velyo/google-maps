<%@ Page Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Markers</title>
    <meta name="description" content="GoogleMap control markers sample." />
    <meta name="keywords" content="googlemap control markers sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers
    </h1>
    <p>
        GoogleMap control markers sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="6" EnableScrollWheelZoom="true" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server"
            OnClientClick="handleMarkerClick">
            <Markers>
                <artem:Marker Address="plovdiv" Title="Click on the marker" Info="Text of marker 1">
                    <%--Position-Latitude="42.1229" Position-Longitude="24.7879"--%>
                </artem:Marker>
                <artem:Marker Position-Latitude="42.7" Position-Longitude="23.3" Title="Click on the marker"
                    Info="Text of marker 2">
                </artem:Marker>
            </Markers>
            <MarkerOptions Draggable="true">
            </MarkerOptions>
        </artem:GoogleMarkers>
    </div>
    <script type="text/javascript">
        function handleMarkerClick(sender, e) {
            alert("Marker #" + (e.index + 1) + "\nPosition: lat=" + e.latLng.lat() + "/lng=" + e.latLng.lng() +
                "\nPixel: x=" + e.pixel.x + "/y=" + e.pixel.y);
        }
    </script>
</asp:Content>
