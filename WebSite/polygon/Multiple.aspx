<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Polygon - Multiple</title>
    <meta name="description" content="GoogleMap control multiple polygons sample." />
    <meta name="keywords" content="googlemap control multiple polygons sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Multiple Polygons
    </h1>
    <p>
        GoogleMap control multiple polygons sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolygon ID="GooglePolygon1" TargetControlID="GoogleMap1" runat="server">
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
            <artem:LatLng Latitude="41.036501" Longitude="28.984895" />
            <artem:LatLng Latitude="44.447924" Longitude="26.097879" />
            <artem:LatLng Latitude="44.802416" Longitude="20.465601" />
            <artem:LatLng Latitude="42.002411" Longitude="21.436097" />
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
        </artem:GooglePolygon>
        <artem:GooglePolygon ID="GooglePolygon2" TargetControlID="GoogleMap1" runat="server">
            <artem:LatLng Latitude="77.97918" Longitude="23.716647" />
            <artem:LatLng Latitude="51.036501" Longitude="28.984895" />
            <artem:LatLng Latitude="54.447924" Longitude="26.097879" />
            <artem:LatLng Latitude="54.802416" Longitude="20.465601" />
            <artem:LatLng Latitude="52.002411" Longitude="21.436097" />
            <artem:LatLng Latitude="47.97918" Longitude="23.716647" />
        </artem:GooglePolygon>
    </div>
</asp:Content>
