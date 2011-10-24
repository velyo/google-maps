<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - GooglePolygon - Circle</title>
    <meta name="description" content="GoogleMap Control - GooglePolygon client events sample." />
    <meta name="keywords" content="asp.net artem googlemap control polygon client events" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="main">
    <h1>
        Circle Polygon
    </h1>
    <p>
        How to draw a circle polygon on GoogleMap.
    </p>
    <p>
        Events can be handled same way as the polygon events.
        <br />
        Check out <a href="ClientEvents.aspx">client</a> and <a href="ServerEvents.aspx">server</a>
        polygon events handling.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="6" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleCircle TargetControlID="GoogleMap1" runat="server" Center="42.1229,24.7879"
            Radius="200000" />
    </div>
</asp:Content>
