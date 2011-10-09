<%@ Page Title="" Language="C#" MasterPageFile="~/demo/markers/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Markers.MarkerManagerPage" Codebehind="MarkerManager.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="Server">
    <title>GoogleMarker - MarkerManager</title>
    <meta name="description" content="GoogleMap Control - MarkerManager sample." />
    <meta name="keywords" content="asp.net artem googlemap control marker manager" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        Marker Manager</h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
        EnableScrollWheelZoom="true" EnableMarkerManager="true" Zoom="6">
        <MarkerManagerOptions maxZoom="8" />
        <Markers>
            <%--<artem:GoogleMarker Address="sofia bulgaria" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/sun.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/sun-shadow.png"
                                MinZoom="3"/>
            <artem:GoogleMarker Address="plovdiv bulgaria" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/sun.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/sun-shadow.png"
                                MinZoom="5"/>
            <artem:GoogleMarker Address="varna bulgaria" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/sun.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/sun-shadow.png"
                                MinZoom="5"/>
            <artem:GoogleMarker Address="burgas bulgaria" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/sun.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/sun-shadow.png"
                                MinZoom="5"/>
                                
            <artem:GoogleMarker Address="bucuresti romania" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/snow.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/snow-shadow.png"
                                MinZoom="3"/>
            <artem:GoogleMarker Address="arad romania" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/snow.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/snow-shadow.png"
                                MinZoom="5"/>
            <artem:GoogleMarker Address="brasov romania" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/snow.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/snow-shadow.png"
                                MinZoom="5"/>
                                
            <artem:GoogleMarker Address="beograd srbija" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/rain.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/rain-shadow.png"
                                MinZoom="3"/>
            <artem:GoogleMarker Address="nis srbija" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/rain.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/rain-shadow.png"
                                MinZoom="5"/>
            <artem:GoogleMarker Address="loznica srbija" 
                                IconAnchor="16,16" 
                                IconSize="32,32" 
                                IconUrl="/images/marker-manager/rain.png" 
                                ShadowSize="59,32"
                                ShadowUrl="/images/marker-manager/rain-shadow.png"
                                MinZoom="5"/>--%>
        </Markers>
    </artem:GoogleMap>
    <h3>
        Descriptions</h3>
    <p>
        This is a sample of MarkerManager usage with a big amount of markers.
    </p>
    <p>
        This MarkerManager is used to manage visibility of hundreds of markers on a map,
        based on the map's current viewport and zoom level.
    </p>
    <p>
        The GoogleMaps API GMarkerManager class is deprecated and it is recommended to use
        the <a href="http://code.google.com/p/gmaps-utility-library-dev/" target="_blank">open
            sourced MarkerManager</a> instead.
        <br />
        That's the MarkerManager implementation used by GoogleMap Control
    </p>
    <p>
        Please, check out the further <a href="http://gmaps-utility-library-dev.googlecode.com/svn/tags/markermanager/1.1/docs/"
            target="_blank">information</a> , <a href="http://gmaps-utility-library-dev.googlecode.com/svn/tags/markermanager/1.1/examples/"
                target="_blank">examples</a> or <a href="http://gmaps-utility-library-dev.googlecode.com/svn/tags/markermanager/1.1/src/"
                    target="_blank">source</a>.
    </p>
</asp:Content>
