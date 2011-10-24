<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - GooglePolygon - Client Events</title>
    <meta name="description" content="GoogleMap Control - GooglePolygon client events sample." />
    <meta name="keywords" content="asp.net artem googlemap control polygon client events" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="main">
    <h1>
        Client Events
    </h1>
    <p>
        How to register GooglePolygon client event handlers.
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
    <select id="list" multiple="multiple" size="10" style="width: 100%;">
    </select>
    <input type="button" value="Clear" onclick="handleClearClick()" />
    <script type="text/javascript">
        var list = document.getElementById("list");

        function addEvent(name) {
            var option = document.createElement("option");
            option.text = name + " event was fired!";
            list.insertBefore(option);
        }

        function handleClearClick() {
            var parent = list.parentNode;
            var empty = list.cloneNode(false);
            parent.replaceChild(empty, list);
        }

        function handleClick(sender, e) {
            addEvent("Click");
            console.dir(e);
        }
        function handleDoubleClick(sender, e) {
            addEvent("Double Click");
            console.dir(e);
        }
        function handleMouseDown(sender, e) {
            addEvent("Mouse Down");
            console.dir(e);
        }
        function handleMouseMove(sender, e) {
            addEvent("Mouse Move");
            console.dir(e);
        }
        function handleMouseOut(sender, e) {
            addEvent("Mouse Out");
            console.dir(e);
        }
        function handleMouseOver(sender, e) {
            addEvent("Mouse Over");
            console.dir(e);
        }
        function handleMouseUp(sender, e) {
            addEvent("Mouse Up");
            console.dir(e);
        }
        function handleRightClick(sender, e) {
            addEvent("Right Click");
            console.dir(e);
        }
    </script>
</asp:Content>
