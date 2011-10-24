<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - GooglePolygon - Gound Overlay</title>
    <meta name="description" content="GoogleMap - GooglePolygon - Rectangle" />
    <meta name="keywords" content="GoogleMap - GooglePolygon - Rectangle" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="main">
    <h1>
        Ground Overlay
    </h1>
    <p>
        How to draw a ground overlay on GoogleMap.
    </p>
    <p>
        Events can be handled same way as the polygon events.
        <br />
        Check out <a href="ClientEvents.aspx">client</a> and <a href="ServerEvents.aspx">server</a>
        polygon events handling.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="Roadmap" CssClass="map"
            Latitude="40.740" Longitude="-74.18" Zoom="13" MapTypeControlOptions-Position="BottomRight">
        </artem:GoogleMap>
        <artem:GoogleGround TargetControlID="GoogleMap1" runat="server" Bounds-SouthWest-Latitude="40.716216"
            Bounds-SouthWest-Longitude="-74.213393" Bounds-NorthEast-Latitude="40.765641"
            Bounds-NorthEast-Longitude="-74.139235" Clickable="true" Url="http://www.lib.utexas.edu/maps/historical/newark_nj_1922.jpg"
            OnClientClick="handleClick" />
    </div>
    <script type="text/javascript">
        function handleClick() {
            alert("Ground Overlay click event was fired!");
        }
    </script>
</asp:Content>