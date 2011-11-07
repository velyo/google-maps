<%@ Page Language="C#" MasterPageFile="~/polyline/Polyline.master" AutoEventWireup="false" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Polyline</title>
    <meta name="description" content="GoogleMap control polyline sample." />
    <meta name="keywords" content="googlemap control polyline sample." />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Polyline
    </h1>
    <p>
        GoogleMap control polyline sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="7" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolyline TargetControlID="GoogleMap1" runat="server" StrokeWeight="10"
            OnClientClick="handleClick" Clickable="true">
            <artem:LatLng Latitude="42.14304" Longitude="24.74967" />
            <artem:LatLng Latitude="42.69649" Longitude="23.32601" />
        </artem:GooglePolyline>
    </div>
    <script type="text/javascript">
        function handleClick(sender, e) {
            if (console) console.dir(e);
            alert("GooglePolylien click event was fired!");
        }
    </script>
</asp:Content>
