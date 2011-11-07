<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Polygon</title>
    <meta name="description" content="GoogleMap control polygon sample." />
    <meta name="keywords" content="googlemap control polygon sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Polygon
    </h1>
    <p>
        GoogleMap control polygon sample.
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
