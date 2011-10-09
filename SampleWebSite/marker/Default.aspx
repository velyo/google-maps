<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="Default.aspx.cs" Inherits="marker_GoogleMarker" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>GoogleMarker</title>
    <meta name="description" content="GoogleMap Control - GoogleMarker class." />
    <meta name="keywords" content="asp.net artem googlemap control marker" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" runat="Server">

    <script type="text/javascript">

        function addMarker(overlay, point) {
            if (point) {
                GoogleMap1.addMarker({ Latitude: point.lat(), Longitude: point.lng() });
            }
        }

        function showInfoWindow(index) {
            var marker = GoogleMap1.Markers[index];
            marker.openInfoWindowHtml(marker.Text);
        }

        function test() {
            alert("Marker clicked!");
        }
    </script>

    <h1>
        GoogleMarker
    </h1>
    <p>
        Click on the map to add marker. Then click on the button 'Save' to save the location
        of all markers added. You can later click on 'Load' button to load saved markers.
        Clicking on the 'Clear' button all markers on the map will be removed, but you can
        load saved lately. If you want to save the map as image click the 'Make Map Static'
        button below and then when map is rendered as image you can save it.</p>
    <%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <asp:Button runat="server" Text="Clear" OnClick="HandleClearClick" />
    <asp:Button runat="server" Text="Save" OnClick="HandleSaveClick" />
    <asp:Button runat="server" Text="Load" OnClick="HandleLoadClick" />
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true" OnClientClick="addMarker">
        <MarkerEvents OnClientClick="test" />
        <Markers>
            <artem:GoogleMarker Latitude="42.1229" Longitude="24.7879" Title="Click on the marker"
                Text="Text of marker 1" Draggable="true">
            </artem:GoogleMarker>
            <artem:GoogleMarker Latitude="42.1229" Longitude="20." Title="Click on the marker"
                Text="Text of </b>marker</b> 2" Draggable="true">
            </artem:GoogleMarker>
        </Markers>
    </artem:GoogleMap>
    <p>
        <asp:Button runat="server" Text="Make Map Static" OnClick="HandleMakeStaticClick" />
        <br />
        <a href="javascript:showInfoWindow(0);">Show first marker</a><br />
        <a href="javascript:showInfoWindow(1);">Show second marker</a>
    </p>
</asp:Content>
<asp:Content ContentPlaceHolderID="phDescription" runat="server">
    A marker object has a point, which is the geographical position where the marker
    is anchored on the map, and an icon. If the icon is not set in the constructor,
    the default icon G_DEFAULT_ICON is used. After it is added to a map, the info window
    of that map can be opened through the marker. The marker object will fire mouse
    events and infowindow events.
    <p>
        The control above is initialized with this code.</p>
    <pre>&lt;artem:GoogleMap ID="GoogleMap2" runat="server" Width="530px" Height="500px" Latitude="37.559819" Longitude="-122.210540"
    Zoom="4" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1"&gt;
    &lt;Directions&gt;
        &lt;artem:GoogleDirection RoutePanelId="route" Query="from: San Francisco, CA to: Mountain View, CA" /&gt;
    &lt;/Directions&gt;
&lt;/artem:GoogleMap&gt;</pre>
</asp:Content>
<asp:Content ContentPlaceHolderID="phProperties" runat="server">
    <ul class="props">
        <li><b>Address</b> - Gets or sets the address of the marker.</li>
        <li><b>AutoPan</b> - Gets or sets a value indicating whether to 'Auto-pan' the map as
            you drag the marker near the edge.</li>
        <li><b>Bouncy</b> - Gets or sets a value indicating whether the GoogleMarker is bouncy.
            Toggles whether or not the marker should bounce up and down after it finishes dragging.</li>
        <li><b>Clickable</b> - Gets or sets a value indicating whether the GoogleMarker is clickable.
            Toggles whether or not the marker is clickable. Markers that are not clickable or
            draggable are inert, consume less resources and do not respond to any events. The
            default value for this option is true, i.e. if the option is not specified, the
            marker will be clickable.</li>
        <li><b>Draggable</b> - Gets or sets a value indicating whether the GoogleMarkeris draggable.
            Toggles whether or not the marker will be draggable by users. Markers set up to
            be dragged require more resources to set up than markers that are clickable. Any
            marker that is draggable is also clickable, bouncy and auto-pan enabled by default.
            The default value for this option is false.</li>
        <li><b>DragCrossMove</b> - When dragging markers normally, the marker floats up and
            away from the cursor. Setting this value to true keeps the marker underneath the
            cursor, and moves the cross downwards instead. The default value for this option
            is false.</li>
        <li><b>IconAnchor</b> - Gets or sets the icon anchor. The pixel coordinate relative
            to the top left corner of the icon image at which this icon is anchored to the map.</li>
        <li><b>IconSize</b> - Gets or sets the size of the icon. The pixel size of the foreground
            image of the icon.</li>
        <li><b>ImageUrl</b> - Gets or sets the foreground image URL of the icon.</li>
        <li><b>InfoWindowAnchor</b> - Gets or sets the info window anchor. The pixel coordinate
            relative to the top left corner of the icon image at which this icon is anchored
            to the map.</li>
        <li><b>InfoWindowContent</b> - Gets or sets the controls' template content of the info
            window.</li>
        <li><b>Latitude</b> - Gets or sets the latitude of the marker.</li>
        <li><b>Longitude</b> - Gets or sets the longitude of the marker.</li>
        <li><b>OpenInfoBehaviour</b> - Gets or sets the behaviour for opening the info window
            of the marker - on which mouse event the info window of the marker to be opened.
            Available values are: Click, DoubleClick, MouseDown, MouseOut, MouseOver, MouseUp.</li>
        <li><b>ShadowSize</b> - Gets or sets the pixel size of the shadow image, if custom image
            is used for icon.</li>
        <li><b>ShadowUrl</b> - Gets or sets the shadow image URL of the icon, if custom image
            is used for icon.</li>
        <li><b>Text</b> - Gets or sets the simple text content for the marker's info window.</li>
        <li><b>Title</b> - Gets or sets the title of the marker. This string will appear as
            tooltip on the marker, i.e. it will work just as the title attribute on HTML elements.</li>
    </ul>
</asp:Content>
<asp:Content ContentPlaceHolderID="phActions" runat="server">
    <ul class="props">
        <li><b>CloseInfoWindow</b> - Method to fire invokation of {{closeInfoWindow}} function
            of the GMarker instance from the server-side code.</li>
        <li><b>Hide</b> - Method to fire invokation of {{hide}} function of the GMarker instance
            from the server-side code.</li>
        <li><b>OpenInfoWindow</b> - Method to fire invokation of {{openInfoWindow}} function
            of the GMarker instance from the server-side code.</li>
        <li><b>OpenInfoWindowHtml</b> - Method to fire invokation of {{openInfoWindowHtml}}
            function of the GMarker instance from the server-side code.</li>
        <li><b>Show</b> - Method to fire invokation of {{show}} function of the GMarker instance
            from the server-side code.</li>
    </ul>
</asp:Content>
