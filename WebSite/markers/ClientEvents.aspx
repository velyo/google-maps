<%@ Page Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Markers - Client Events</title>
    <meta name="description" content="GoogleMap control markers client event handling sample." />
    <meta name="keywords" content="googlemap control markers client event handling sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers Client Events
    </h1>
    <p>
        GoogleMap control markers client event handling sample.
        <br />
        The markers fire next events: animation changed, click, clickable changed, cursor
        changed, double click, drag, draggable changed, drag end, drag start, flat changed,
        icon changed, mouse down, mouse out, mouse over, mouse up, position changed, right
        click, shadow changed, shape changed, title changed, visible changed, z-index changed.
        <br />
        The event fired by the polyline will be listed in the info list bellow (most recent
        first).
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="12" EnableScrollWheelZoom="true" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server"
            OnClientAnimationChanged="handleAnimationChanged" OnClientClick="handleClick"
            OnClientClickableChanged="handleClickableChanged" OnClientCursorChanged="handleCursorChanged"
            OnClientDoubleClick="handleDoubleClick" OnClientDrag="handleDrag" OnClientDragEnd="handleDragEnd"
            OnClientDraggableChanged="handleDraggableChanged" OnClientDragStart="handleDragStart"
            OnClientFlatChanged="handleFlatChanged" OnClientIconChanged="handleIconChanged"
            OnClientMouseDown="handleMouseDown" OnClientMouseOut="handleMouseOut" OnClientMouseOver="handleMouseOver"
            OnClientMouseUp="handleMouseUp" OnClientPositionChanged="handlePositionChanged"
            OnClientRightClick="handleRightClick" OnClientShadowChanged="handleShadowChanged"
            OnClientShapeChanged="handleShapeChanged" OnClientTitleChanged="handleTitleChanged"
            OnClientVisibleChanged="handleVisibleChanged" OnClientZIndexChanged="handleZIndexChanged">
            <Markers>
                <artem:Marker Position-Latitude="42.132" Position-Longitude="24.75" Title="Click on the marker"
                    Info="Text of marker 1">
                </artem:Marker>
                <artem:Marker Position-Latitude="42.7" Position-Longitude="23.3" Title="Click on the marker"
                    Info="Text of marker 2">
                </artem:Marker>
            </Markers>
            <MarkerOptions Draggable="true">
            </MarkerOptions>
        </artem:GoogleMarkers>
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

        function handleAnimationChanged(sender, e) {
            printEvent("Animation Changed", sender, e);
        }
        function handleClick(sender, e) {
            printEvent("Click", sender, e);
        }
        function handleClickableChanged(sender, e) {
            printEvent("Clickable Changed", sender, e);
        }
        function handleCursorChanged(sender, e) {
            printEvent("Cursor Changed", sender, e);
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
        function handleDraggableChanged(sender, e) {
            printEvent("Draggable Changed", sender, e);
        }
        function handleDragStart(sender, e) {
            printEvent("Drag Start", sender, e);
        }
        function handleFlatChanged(sender, e) {
            printEvent("Flat Changed", sender, e);
        }
        function handleIconChanged(sender, e) {
            printEvent("Icon Changed", sender, e);
        }
        function handleMouseDown(sender, e) {
            printEvent("Mouse Down", sender, e);
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
        function handleMouseUp(sender, e) {
            printEvent("Mouse Up", sender, e);
        }
        function handlePositionChanged(sender, e) {
            printEvent("Position Changed", sender, e);
        }
        function handleRightClick(sender, e) {
            printEvent("Right Click", sender, e);
        }
        function handleShadowChanged(sender, e) {
            printEvent("Shadow Changed", sender, e);
        }
        function handleShapeChanged(sender, e) {
            printEvent("Shape Changed", sender, e);
        }
        function handleTitleChanged(sender, e) {
            printEvent("Title Changed", sender, e);
        }
        function handleVisibleChanged(sender, e) {
            printEvent("Visible Changed", sender, e);
        }
        function handleZIndexChanged(sender, e) {
            printEvent("ZIndex Changed", sender, e);
        }

        function printEvent(name, sender, e) {

            var position = e.latLng || sender.markers[e.index].getPosition();
            var buffer = [];
            buffer.push(name);
            buffer.push(" event was fired by marker [index: ");
            buffer.push(e.index);
            buffer.push("] at position [lat: ");
            buffer.push(position.lat());
            buffer.push(", lng: ");
            buffer.push(position.lng());
            buffer.push("].");

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
