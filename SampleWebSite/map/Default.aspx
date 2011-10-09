<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="Default.aspx.cs" Inherits="map_GoogleMap" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>GoogleMap</title>
    <meta name="description" content="GoogleMap Control class." />
    <meta name="keywords" content="asp.net artem googlemap control" />
</asp:Content>
<asp:Content ID="cntContent" ContentPlaceHolderID="phContent" runat="Server">
    <h1>
        GoogleMap class
    </h1>
    <p>
        <asp:Label runat="server" Text="Address" AssociatedControlID="_txtAddress"></asp:Label>
        <asp:TextBox ID="_txtAddress" runat="server" Width="360px">
        </asp:TextBox>
        <asp:Button runat="server" Text="Show" OnClick="HandleShowClick" />
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Address="london" MapType="HYBRID"
        Zoom="12" ShowScaleControl="true">
        <%--Latitude="42.1229" Longitude="24.7879" --%>
    </artem:GoogleMap>
</asp:Content>
<asp:Content ID="cntDescription" ContentPlaceHolderID="phDescription" runat="server">
    <p>
        Wraps Google Maps API as ASP.NET custom control. Offers extremely easy and fast
        way of adding Google Maps API support on your ASP.NET pages.
    </p>
</asp:Content>
<asp:Content ID="cntProperties" ContentPlaceHolderID="phProperties" runat="server">
    <p>
        The control above is initialized with this code.</p>
    <pre>&lt;artem:GooleMap 
    ID="GoogleMap1" 
    runat="server" 
    Width="530px" 
    Height="500px" 
    Latitude="42.1229" 
    Longitude="24.7879"
    Zoom="4" 
    <em>EnableScrollWheelZoom="true"</em>&gt;
&lt;/artem:GooleMap&gt;</pre>
    <ul class="props">
        <li><b>Key</b> - Gets or sets the Google Maps API key. If you want to set the key once
            and use it on all google maps, you can set it in <b>appSettings - GoogleMapKey</b>
            and then omit setting it for every GoogleMap control.</li>
        <li><b>Width</b> - Gets or sets the width of the Web server control. If it is omited
            deafult value of 600px is used.</li>
        <li><b>Height</b> - Gets or sets the height of the Web server control. If it is omited
            deafult value of 480px is used.</li>
        <li><b>Address</b> - Gets or sets the address for map center geolocation position.</li>
        <li><b>Latitude</b> - Gets or sets the latitude for map center position.</li>
        <li><b>Longitude</b> - Gets or sets the longitude for map center position.</li>
        <li><b>Zoom</b> - Gets or sets the zoom.</li>
        <li><b>BaseCountryCode</b> - Gets or sets the base country code for the client geocoder.</li>
        <li><b>DefaultMapView</b> - Gets or sets the default map view</li>
        <li><b>EnableContinuousZoom</b> - Gets or sets a value indicating whether continuous
            zoom is enabled.</li>
        <li><b>EnableDoubleClickZoom</b> - Gets or sets a value indicating whether double click
            zoom is enabled.</li>
        <li><b>EnableDragging</b> - Gets or sets a value indicating whether dragging is enabled.</li>
        <li><b>EnableGoogleBar</b> - Gets or sets a value indicating whether google bar is enabled.</li>
        <li><b>EnableInfoWindow</b> - Gets or sets a value indicating whether info window is
            enabled.</li>
        <li><b>EnableMarkerManager</b> - Gets or sets a value indicating whether marker manager
            is enabled.</li>
        <li><b>EnableScrollWheelZoom</b> - Gets or sets a value indicating whether scroll wheel
            zoom is enabled.</li>
        <li><b>IsStatic</b> - Gets or sets a value indicating whether this is static and rendered
            as image on the page.</li>
        <li><b>ShowMapTypeControl</b> - Gets or sets a value indicating whether to show map
            type control.</li>
        <li><b>ShowTraffic</b> - Gets or sets a value indicating whether to show traffic.</li>
        <li><b>ZoomPanType</b> - Gets or sets the type of the zoom pan.</li>
    </ul>
</asp:Content>
