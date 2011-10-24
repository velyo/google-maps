<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - GooglePolygon - Server Events</title>
    <meta name="description" content="GoogleMap - GooglePolygon - Server Events" />
    <meta name="keywords" content="GoogleMap - GooglePolygon - Server Events" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server">
    <h1>
        Server Events
    </h1>
    <p>
        How to register GooglePolygon server event handlers.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolygon TargetControlID="GoogleMap1" runat="server">
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
            <artem:LatLng Latitude="41.036501" Longitude="28.984895" />
            <artem:LatLng Latitude="44.447924" Longitude="26.097879" />
            <artem:LatLng Latitude="44.802416" Longitude="20.465601" />
            <artem:LatLng Latitude="42.002411" Longitude="21.436097" />
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
        </artem:GooglePolygon>
    </div>
</asp:Content>
