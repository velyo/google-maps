<%@ Page Language="C#" MasterPageFile="GoogleMap.master" AutoEventWireup="false"
    CodeFile="Default.aspx.cs" Inherits="page_Default" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>GoogleMap Control Samples Website</title>
    <meta name="description" content="The GoogleMap Control samples website." />
    <meta name="keywords" content="asp.net artem googlemap control samples website" />
</asp:Content>
<asp:Content ContentPlaceHolderID="phContent" ID="Content1" runat="server">
    <p>
        Wecome to GoogleMap Control samples website.<br />
        Please choose from any of the samples on the left.
    </p>
    <h2>
        Project Links</h2>
    <ul>
        <li><a href="http://www.codeplex.com/googlemap/Release/ProjectReleases.aspx">&raquo;
            Current Release</a> </li>
        <li><a href="http://www.codeplex.com/googlemap/Wiki/View.aspx?title=Installation&referringTitle=Home">
            &raquo; Installation</a> </li>
    </ul>
    <h2>
        Features</h2>
    <ul class="props">
        <li><b>ASP.NET AJAX</b> (under <b>UpdatePanel</b>) enabled;</li>
        <li><b>Geocoding</b> or <b>Latitude/Longitude</b> center point of the map;</li>
        <li><b>Google Map Marker(s)</b>, with formated text, using <b>Geocoding</b> or <b>Latitude/Longitude</b>;</li>
        <li><b>Traffic Overlays</b>;</li>
        <li><b>Driving Directions</b> (look at the sample page for the issue with localhost
            usage);</li>
        <li><b>Capture</b> map click point position;</li>
        <li><b>GoogleBar</b> for address search on the maps;</li>
        <li><b>Marker Manager</b> for maps with a lot of markers;</li>
        <li><b>Draggable Markers</b>;</li>
        <li><b>Custom Icons</b>;</li>
        <li><b>Polylines</b>;</li>
        <li><b>Polygons</b>;</li>
        <li><b>Goecoding</b> locations <b>caching</b> and <b>persistence</b> on postback for
            map and markers;</li>
        <li><b>DefaultView</b> control property to manage the map initial view with support
            to all google map types since Google API 2.9 (Normal, Satellite, Hybrid, Physical,
            MoonElevation, MoonVisible, MarsElevation, MarsVisible, MarsInfrared, SkyVisible);</li>
        <li><b>GoogleMap Events</b> client-side/server-side handling;</li>
        <li><b>GoogleMarker Events</b> client-side/server-side handling;</li>
        <li><b>Static Map</b> as image that can be saved;</li>
    </ul>
    <h2>
        Known Issues</h2>
    <ul class="props">
        <li>When using Google Maps on localhost they can work with not properly obtained keys
            (even that given in the samples here), but in order to work without problems you
            have to obtain a key for the desired domain;</li>
        <li>Driving direction will not appear on localhost, but on the public site/domain for
            which you have obtained the key, they will be shown properly (That is probably protection
            or security issue of Google Maps API). Check out next discussion: [url: Getting
            around the Google API Key Issue on localhost | https://www.codeplex.com/Thread/View.aspx?ProjectName=googlemap&ThreadId=22070]</li>
        <li>When using GoogleMap control inside *ASP.NET AJAX TabPanel* you have to set size
            of the control in pixels (not in percents) in order to get control working properly;</li>
        <li>Static map will not work on localhost. Check out [url: Getting around the Google
            API Key Issue on localhost | https://www.codeplex.com/Thread/View.aspx?ProjectName=googlemap&ThreadId=22070];</li>
        <li>The max size of the static map is 512x512. Code cuts it if is greater, otherwise
            static map will not work;</li>
        <li>Only markers are supported for static map - no traffic, no overlays, no directions
            etc. This is like it is - that's just provided by Google Maps API. There is no as
            I can see so far support for custom makers icons as well. So, the standard markers'
            icons are used only on the static map;</li>
    </ul>
</asp:Content>
