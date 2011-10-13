<%@ Page Language="C#" MasterPageFile="~/polyline/Polyline.master" AutoEventWireup="false"
    CodeFile="Default.aspx.cs" Inherits="polyline_GooglePolyline" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <title>GooglePolyline</title>
    <meta name="description" content="GoogleMap Control - GooglePolyline sample." />
    <meta name="keywords" content="asp.net artem googlemap control polyline" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">

    <script type="text/javascript">
        var __count = 0;
        function handleMapClick(overlay, point) {
            if (point) {
                var el = document.getElementById('__points');
                if (el) {
                    var state = el.value;
                    if (!state) state = "";
                    else state += ";"
                    state += point.lat() + "," + point.lng();
                    el.value = state;
                }
                el = document.getElementById('<%= _txtPoints.ClientID %>');
                if (el) el.value = ++__count;
            }
        }

        function __test() {
            alert("Polyline clicked!");
        }
    </script>

    <h1>
        GooglePolyline Reference</h1>
    <p>
        Click on the map below to build points of the polyline<br />
        Then click to button 'Draw' to draw it.</p>
    Current Points #
    <asp:TextBox ID="_txtPoints" runat="server" ReadOnly="true" Width="100px" Text="0"></asp:TextBox>
    <asp:Button runat="server" Text="Draw" OnClick="HandleShowPolylineClick" />
    <input id="__points" name="__points" type="hidden" />
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4"><%-- OnClientClick="handleMapClick" EnableScrollWheelZoom="true">--%>
        <%--<PolylineEvents OnClick="HandlePolylineClick" />--%>
        <%--<Polylines>
            <artem:GooglePolyline Color="Blue" Weight="2" Opacity="1" IsGeodesic="false">
                <artem:LatLng Latitude="42.1229" Longitude="24.7879" />
                <artem:LatLng Latitude="51.34433" Longitude="16.17578" />
                <artem:LatLng Latitude="41.70572" Longitude="12.39257" />
            </artem:GooglePolyline>
        </Polylines>--%>
    </artem:GoogleMap>
    <fieldset>
        <legend>Extra Data</legend>
        <br />
        <asp:Literal ID="_ltrInfo" runat="server"></asp:Literal><br />
        <asp:Button ID="Button1" runat="server" Text="Show" OnClick="HandleShowExtraDataClick" />
    </fieldset>
    Wraps Google Maps API class GPolyline. This is a map overlay that draws a polyline
    on the map, using the vector drawing facilities of the browser if they are available,
    or an image overlay from Google servers otherwise.
    <p>
        The control above is initialized with this code.</p>
    <pre>&lt;artem:GoogleMap ID="GoogleMap2" runat="server" Width="530px" Height="500px" Latitude="42.1229" Longitude="24.7879"
    Zoom="4" OnClientClick="handleMapClick" EnableScrollWheelZoom="true" BorderStyle="Solid" BorderColor="#999999"
    BorderWidth="1"&gt;
    &lt;Polylines&gt;
        &lt;artem:GooglePolyline Color="Blue" Weight="2" Opacity="1" IsGeodesic="false"&gt;
            &lt;artem:GooglePoint Latitude="42.1229" Longitude="24.7879" /&gt;
            &lt;artem:GooglePoint Latitude="51.34433" Longitude="16.17578" /&gt;
            &lt;artem:GooglePoint Latitude="41.70572" Longitude="12.39257" /&gt;
        &lt;/artem:GooglePolyline&gt;
    &lt;/Polylines&gt;
&lt;/artem:GoogleMap&gt;</pre>
    <ul class="props">
        <li><b>Bounds</b> - Gets or sets the bounds of polyline. Have in mind it requires an
            additional post back after polyline is loaded.</li>
        <li><b>Color</b> - Gets or sets a value for color of polyline.</li>
        <li><b>IsClickable</b> - Gets or sets a value indicating whether this polyline is clickable.</li>
        <li><b>IsGeodesic</b> - Gets or sets a value indicating whether this polyline is geodesic.</li>
        <li><b>Opacity</b> - Gets or sets the opacity of polyline. The opacity is given as a
            number between 0 and 1. The line will be antialiased and semitransparent.</li>
        <li><b>Points</b> - Gets or sets the points of polyline.</li>
        <li><b>Weight</b> - Gets or sets the weight of polyline. The weight is the width of
            the line in pixels.</li>
    </ul>
</asp:Content>
