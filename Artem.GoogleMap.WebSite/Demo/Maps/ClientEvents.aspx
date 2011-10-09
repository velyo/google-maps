<%@ Page Language="C#" MasterPageFile="~/demo/maps/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Maps.ClientEventsPage" Codebehind="ClientEvents.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>Client Events</title>
    <meta name="description" content="GoogleMap Control map client events sample." />
    <meta name="keywords" content="asp.net artem googlemap control client events" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        Clent Events
    </h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
        Zoom="4" OnClientAddressNotFound="handleAny('AddressNotFound')" OnClientClick="handleAny('Click')"
        OnClientDoubleClick="handleAny('DoubleClick')" OnClientDrag="handleAny('Drag')"
        OnClientDragEnd="handleAny('DragEnd')" OnClientDragStart="handleAny('DragStart')"
        OnClientGeoLocationLoaded="handleAny('GeoLocationLoaded')" OnClientInfoWindowBeforeClose="handleAny('InfoWindowBeforeClose')"
        OnClientInfoWindowClose="handleAny('InfoWindowClose')" OnClientInfoWindowOpen="handleAny('InfoWindowOpen')"
        OnClientLocationLoaded="handleAny('LocationLoaded')" OnClientMapLoad="handleAny('ClientMapLoad')"
        OnClientMapTypeAdd="handleAny('MapTypeAdd')" OnClientMapTypeChanged="handleAny('MapTypeChanged')"
        OnClientMapTypeRemove="handleAny('MapTypeRemove')" OnClientMouseMove="handleAny('MouseMove')"
        OnClientMouseOut="handleAny('MouseOut')" OnClientMouseOver="handleAny('MouseOver')"
        OnClientMove="handleAny('Move')" OnClientMoveEnd="handleAny('MoveEnd')" OnClientMoveStart="handleAny('MoveStart')"
        OnClientOverlayAdd="handleAny('OverlayAdd')" OnClientOverlayRemove="handleAny('OverlayRemove')"
        OnClientOverlaysClear="handleAny('OverlaysClear')" OnClientSingleRightClick="handleAny('SingleRightClick')"
        OnClientZoomEnd="handleAny('ZoomEnd')">
    </artem:GoogleMap>
    <p>
        Events fired (most recent first):</p>
    <div id="info">
    </div>
    <input type="button" value="Clear" onclick="javascript:clearInfo()" />
    <script type="text/javascript">

        function handleAny(name) {
            var info = document.getElementById("info");
            info.innerHTML = "<b>" + name + "</b><br/> " + info.innerHTML;
            info.scrollPosition = 10000000;
        }

        function clearInfo() {
            var info = document.getElementById("info");
            info.innerHTML = "";
        }
    </script>
    <p>
        This sample shows how to handle all GoogleMap Control events on the client-side.
    </p>
</asp:Content>
