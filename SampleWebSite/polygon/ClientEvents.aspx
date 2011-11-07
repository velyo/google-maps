<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Polygon - Client Events</title>
    <meta name="description" content="GoogleMap control polygon client event handling sample." />
    <meta name="keywords" content="googlemap control polygon client event handling sample" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="main">
    <h1>
        Polygon Client Events
    </h1>
    <p>
        GoogleMap control polygon client event handling sample.<br />
        The polygon fires next events: click, double click, mouse down, mouse move, mouse
        out, mouse over, mouse up, right click.<br />
        The event fired by the polygon will be listed in the info panel bellow (most recent
        first).
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolygon TargetControlID="GoogleMap1" runat="server" OnClientClick="handleClick"
            OnClientDoubleClick="handleDoubleClick" OnClientMouseDown="handleMouseDown" OnClientMouseOut="handleMouseOut"
            OnClientMouseOver="handleMouseOver" OnClientMouseUp="handleMouseUp" OnClientRightClick="handleRightClick">
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
            <artem:LatLng Latitude="41.036501" Longitude="28.984895" />
            <artem:LatLng Latitude="44.447924" Longitude="26.097879" />
            <artem:LatLng Latitude="44.802416" Longitude="20.465601" />
            <artem:LatLng Latitude="42.002411" Longitude="21.436097" />
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
        </artem:GooglePolygon>
    </div>
    <div>
        Events (most recent first): <input type="button" value="Clear" onclick="handleClearClick()" />
    </div>
    <select id="list" multiple="multiple" size="20" style="width: 100%;">
    </select>
    <script type="text/javascript">
        var list = document.getElementById("list");

        function handleClearClick() {
            $("#list").empty();
        }

        function handleClick(sender, e) {
            printEvent("Click", e);
        }
        function handleDoubleClick(sender, e) {
            printEvent("Double Click", e);
        }
        function handleMouseDown(sender, e) {
            printEvent("Mouse Down", e);
        }
        function handleMouseMove(sender, e) {
            printEvent("Mouse Move", e);
        }
        function handleMouseOut(sender, e) {
            printEvent("Mouse Out", e);
        }
        function handleMouseOver(sender, e) {
            printEvent("Mouse Over", e);
        }
        function handleMouseUp(sender, e) {
            printEvent("Mouse Up", e);
        }
        function handleRightClick(sender, e) {
            printEvent("Right Click", e);
        }

        function printEvent(name, e) {

            var buffer = [];
            buffer.push(name);
            buffer.push(" event was fired");
            if (e && e.latLng) {
                buffer.push(" (lat: ");
                buffer.push(e.latLng.lat());
                buffer.push(", lng: ");
                buffer.push(e.latLng.lng());
                buffer.push(")");
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
