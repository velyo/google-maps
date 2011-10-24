<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - GooglePolygon - Rectangle</title>
    <meta name="description" content="GoogleMap - GooglePolygon - Rectangle" />
    <meta name="keywords" content="GoogleMap - GooglePolygon - Rectangle" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="main">
    <h1>
        Rectangle Polygon
    </h1>
    <p>
        How to draw a rectangle polygon on GoogleMap.
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
        <artem:GoogleRectangle TargetControlID="GoogleMap1" runat="server" FillColor="Green"
            Bounds-SouthWest="44.802416,20.465601" Bounds-NorthEast="37.97918,23.716647">
        </artem:GoogleRectangle>
    </div>
</asp:Content>
