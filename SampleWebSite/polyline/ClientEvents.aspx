<%@ Page Language="C#" MasterPageFile="~/polyline/Polyline.master" AutoEventWireup="false" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Polyline - Client Events</title>
    <meta name="description" content="GoogleMap control polyline client event handling sample." />
    <meta name="keywords" content="googlemap control polyline client event handling sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Polyline Client Events
    </h1>
    <p>
        GoogleMap control polyline client event handling sample.
        <br />
        The polyline fires next events: click, double click, mouse down, mouse move, mouse
        out, mouse over, mouse up, right click.<br />
        The event fired by the polyline will be listed in the info list bellow (most recent
        first).
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="7" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolyline ID="GooglePolyline1" TargetControlID="GoogleMap1" runat="server"
            StrokeWeight="10" Clickable="true" OnClientClick="handleClick" OnClientDoubleClick="handleDoubleClick"
            OnClientMouseDown="handleMouseDown" OnClientMouseOut="handleMouseOut" OnClientMouseOver="handleMouseOver"
            OnClientMouseUp="handleMouseUp" OnClientRightClick="handleRightClick">
            <artem:LatLng Latitude="42.14304" Longitude="24.74967" />
            <artem:LatLng Latitude="42.69649" Longitude="23.32601" />
        </artem:GooglePolyline>
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
