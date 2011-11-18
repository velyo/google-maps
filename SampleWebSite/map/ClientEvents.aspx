<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Client Events</title>
    <meta name="description" content="GoogleMap control map client event handling sample." />
    <meta name="keywords" content="googlemap control map client event handling sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Map Clent Events
    </h1>
    <p>
        GoogleMap control map client event handling sample.
        <br />
        The map fire next events: bounds changed, center changed, click, double click, drag,
        drag end, drag start, heading changed, idle, map type changed, mouse move, mouse
        out, mouse over, projection changed, resize, right click, tiles loaded, tilt changed,
        zoom changed.
        <br />
        The event fired by the polyline will be listed in the info list bellow (most recent
        first).
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="5" CssClass="map" OnClientBoundsChanged="handleBoundsChanged" OnClientCenterChanged="handleCenterChanged"
            OnClientClick="handleClick" OnClientDoubleClick="handleDoubleClick" OnClientDrag="handleDrag"
            OnClientDragEnd="handleDragEnd" OnClientDragStart="handleDragStart" OnClientHeadingChanged="handleHeadingChanged"
            OnClientMapTypeChanged="handleMapTypeChanged" OnClientMouseOut="handleMouseOut"
            OnClientMouseOver="handleMouseOver" OnClientProjectionChanged="handleProjectionChanged"
            OnClientResize="handleResize" OnClientRightClick="handleRightClick" OnClientTilesLoaded="handleTilesLoaded"
            OnClientTiltChanged="handleTiltChanged" OnClientZoomChanged="handleZoomChanged">
            <%--
            TODO This fires a lot of events, that's why omitted.
            OnClientMouseMove="handleMouseMove"
            --%>
        </artem:GoogleMap>
    </div>
    <div>
        Events (most recent first):
        <input type="button" value="Clear" onclick="handleClearClick()" />
    </div>
    <select id="list" multiple="multiple" size="20" style="width: 100%;">
    </select>
    <script type="text/javascript">
        var list = document.getElementById("list");

        function handleClearClick() {
            $("#list").empty();
        }

        function handleBoundsChanged(sender, e) {
            printEvent("Bounds Changed", sender, e);
        }
        function handleCenterChanged(sender, e) {
            printEvent("Center Changed", sender, e);
        }
        function handleClick(sender, e) {
            printEvent("Click", sender, e);
        }
        function handleDoubleClick(sender, e) {
            printEvent("Double Click", sender, e);
        }
        function handleDrag(sender, e) {
            printEvent("Drag", sender, e);
        }
        function handleDragEnd(sender, e) {
            printEvent("Drag End", sender, e);
        }
        function handleDragStart(sender, e) {
            printEvent("Drag Start", sender, e);
        }
        function handleHeadingChanged(sender, e) {
            printEvent("Heading Changed", sender, e);
        }
        function handleMapTypeChanged(sender, e) {
            printEvent("Map Type Changed", sender, e);
        }
        function handleMouseMove(sender, e) {
            printEvent("Mouse Move", sender, e);
        }
        function handleMouseOut(sender, e) {
            printEvent("Mouse Out", sender, e);
        }
        function handleMouseOver(sender, e) {
            printEvent("Mouse Over", sender, e);
        }
        function handleProjectionChanged(sender, e) {
            printEvent("Projection Changed", sender, e);
        }
        function handleResize(sender, e) {
            printEvent("Resize", sender, e);
        }
        function handleRightClick(sender, e) {
            printEvent("Right Click", sender, e);
        }
        function handleTilesLoaded(sender, e) {
            printEvent("Tiles Loaded", sender, e);
        }
        function handleTiltChanged(sender, e) {
            printEvent("Tilt Changed", sender, e);
        }
        function handleZoomChanged(sender, e) {
            printEvent("Zoom Changed", sender, e);
        }

        function printEvent(name, sender, e) {

            var buffer = [];
            buffer.push(name);
            buffer.push(" event was fired by the map");
            if (e) {
                if (e.latLng) {
                    buffer.push(" position[lat: ");
                    buffer.push(e.latLng.lat());
                    buffer.push(", lng: ");
                    buffer.push(e.latLng.lng());
                    buffer.push("]");
                }
            }
            buffer.push(".");

            var option = document.createElement("option");
            option.text = buffer.join('');

            if (list.childNodes.length > 0) {
                list.insertBefore(option, list.childNodes[0]);
            }
            else {
                list.appendChild(option);
            }
            // print it out in the browser console as well, if provided
            if (console) console.dir(e);
        }
    </script>
</asp:Content>
