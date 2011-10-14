<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="GoogleCirclePolygon.aspx.cs" Inherits="polygon_GoogleCirclePolygon" %>

<asp:Content ID="cntHead" ContentPlaceHolderID="phHead" runat="server">
    <title>GooglePolygon - Circle</title>
    <meta name="description" content="GoogleMap Control - GooglePolygon circle sample." />
    <meta name="keywords" content="asp.net artem googlemap control polygon circle" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" runat="Server">

    <script type="text/javascript">
        function handleClick(overlay, point) {
            if (point) {
                var el = document.getElementById('<%= _txtPoint.ClientID %>');
                el.value = point.lat() + "," + point.lng();
            }
        }
    </script>

    <h1>
        GoogleCirclePolygon
    </h1>
    <p>
        Click on the map below to set the center point of circle polygon. Set the radius
        and click 'Draw' button the draw the polygon.</p>
    Point
    <asp:TextBox ID="_txtPoint" runat="server" Width="300px"></asp:TextBox><br />
    Radius
    <asp:TextBox ID="_txtRadius" runat="server" Width="100px" Text="100"></asp:TextBox>
    <asp:Button runat="server" Text="Draw" OnClick="HandleDrawClick" />
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true" OnClientClick="handleClick">
        <%--<Polygons>
            <artem:GoogleCirclePolygon Latitude="42.1229" Longitude="24.7879" Radius="400" FillColor="Blue"
                FillOpacity=".5" StrokeColor="#000080" StrokeOpacity=".75" StrokeWeight="2" />
        </Polygons>--%>
    </artem:GoogleMap>
</asp:Content>
<asp:Content ContentPlaceHolderID="phDescription" runat="server">
    Wraps Google Maps API class GPolygon and extends it to draw circle polygon.
    <p>
        The control above is initialized with this code.</p>
    <pre>&lt;artem:GoogleMap ID="GoogleMap2" runat="server" Width="530px" Height="500px" Latitude="42.1229" Longitude="24.7879"
        Zoom="4" EnableScrollWheelZoom="true" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1" OnClientClick="handleClick"&gt;
        &lt;Polygons&gt;
            &lt;artem:GoogleCirclePolygon Latitude="42.1229" Longitude="24.7879" Radius="400" FillColor="Blue" FillOpacity=".5"
                StrokeColor="#000080" StrokeOpacity=".75" StrokeWeight="2" /&gt;
        &lt;/Polygons&gt;
    &lt;/artem:GoogleMap&gt;</pre>
</asp:Content>
<asp:Content ContentPlaceHolderID="phProperties" runat="server">
    <ul class="props">
        <li><b>Latitude</b> - The latitide for the center point of circle polygon.</li>
        <li><b>Longitude</b> - The longitude for the center point of circle polygon.</li>
        <li><b>Radius</b> - The radius of circle polygon in pixels.</li>
    </ul>
</asp:Content>
<asp:Content ContentPlaceHolderID="phActions" runat="server">
    <ul class="props">
        <li><b>Hide</b> - Method to fire invokation of hide function of the GPolygon instance
            from the server-side code.</li>
        <li><b>Show</b> - Method to fire invokation of show function of the GPolygon instance
            from the server-side code.</li>
    </ul>
</asp:Content>
