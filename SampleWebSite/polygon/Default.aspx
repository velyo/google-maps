<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false"
    CodeFile="Default.aspx.cs" Inherits="polygon_GooglePolygon" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GooglePolygon</title>
    <meta name="description" content="GoogleMap Control - GooglePolygon sample." />
    <meta name="keywords" content="asp.net artem googlemap control polygon" />
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
        function test() {
            alert("Clicked");
        }
    </script>

    <h1>
        GooglePolygon
    </h1>
    <p>
        Click on the map below to build points of the polygon(at least 3).<br />
        Then click to button 'Draw' to draw it.</p>
    Current Points #
    <asp:TextBox ID="_txtPoints" runat="server" ReadOnly="true" Width="100px" Text="0"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Draw" OnClick="HandleDrawClick" />
    <input id="__points" name="__points" type="hidden" />
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4"><%-- OnClientClick="handleMapClick" EnableScrollWheelZoom="true">--%>
        <%--<PolygonEvents OnClick="HandleClick" />--%>
        <Polygons>
            <artem:GooglePolygon FillColor="Red" FillOpacity=".8" StrokeColor="Blue" StrokeWeight="2">
                <artem:GoogleLocation Latitude="37.97918" Longitude="23.716647" />
                <artem:GoogleLocation Latitude="41.036501" Longitude="28.984895" />
                <artem:GoogleLocation Latitude="44.447924" Longitude="26.097879" />
                <artem:GoogleLocation Latitude="44.802416" Longitude="20.465601" />
                <artem:GoogleLocation Latitude="42.002411" Longitude="21.436097" />
                <artem:GoogleLocation Latitude="37.97918" Longitude="23.716647" />
            </artem:GooglePolygon>
        </Polygons>
    </artem:GoogleMap>
    <fieldset>
        <legend>Extra Data</legend>
        <br />
        <asp:Literal ID="_ltrInfo" runat="server"></asp:Literal><br />
        <asp:Button ID="Button2" runat="server" Text="Show" OnClick="HandleShowExtraDataClick" />
    </fieldset>
    Wraps Google Maps API class GPolygon. This is very similar to a GPolyline, except
    that you can additionally specify a fill color and opacity.
    <p>
        The control above is initialized with this code.</p>
    <pre>&lt;artem:GoogleMap ID="GoogleMap2" runat="server" Width="530px" Height="500px" Latitude="42.1229" Longitude="24.7879"
    Zoom="4" OnClientClick="handleMapClick" EnableScrollWheelZoom="true" BorderStyle="Solid" BorderColor="#999999"
    BorderWidth="1"&gt;
    &lt;Polygons&gt;
        &lt;artem:GooglePolygon FillColor="Red" FillOpacity=".8" StrokeColor="Blue" StrokeWeight="2"&gt;
            &lt;artem:GooglePoint Latitude="37.97918" Longitude="23.716647" /&gt;
            &lt;artem:GooglePoint Latitude="41.036501" Longitude="28.984895" /&gt;
            &lt;artem:GooglePoint Latitude="44.447924" Longitude="26.097879" /&gt;
            &lt;artem:GooglePoint Latitude="44.802416" Longitude="20.465601" /&gt;
            &lt;artem:GooglePoint Latitude="42.002411" Longitude="21.436097" /&gt;
            &lt;artem:GooglePoint Latitude="37.97918" Longitude="23.716647" /&gt;
        &lt;/artem:GooglePolygon&gt;
    &lt;/Polygons&gt;
&lt;/artem:GoogleMap&gt;</pre>
    <ul class="props">
        <li><b>Bounds</b> - Gets or sets the bounds of polygon. Have in mind it requires an
            additional post back after polygon is loaded.</li>
        <li><b>FillColor</b> - Gets or sets the fill color of polygon. The color is given as
            a string that contains the color in hexadecimal numeric HTML style, i.e. #RRGGBB.</li>
        <li><b>FillOpacity</b> - Gets or sets the fill opacity of polygon. The opacity is given
            as a number between 0 and 1. The line will be antialiased and semitransparent.</li>
        <li><b>IsClickable</b> - Gets or sets a value indicating whether this polygon is clickable.</li>
        <li><b>Points</b> - Gets or sets the points of polygon.</li>
        <li><b>StrokeColor</b> - Gets or sets the stroke color of polygon. The color is given
            as a string that contains the color in hexadecimal numeric HTML style, i.e. #RRGGBB.</li>
        <li><b>StrokeOpacity</b> - Gets or sets the stroke opacity of polygon. The opacity is
            given as a number between 0 and 1. The line will be antialiased and semitransparent.</li>
        <li><b>StrokeWeight</b> - Gets or sets the weight of polygon. The weight is the width
            of the line in pixels.</li>
    </ul>
    <ul class="props">
        <li><b>Hide</b> - Method to fire invokation of hide function of the GPolygon instance
            from the server-side code.</li>
        <li><b>Show</b> - Method to fire invokation of show function of the GPolygon instance
            from the server-side code.</li>
    </ul>
</asp:Content>
