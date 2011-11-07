<%@ Page Language="C#" MasterPageFile="~/directions/Directions.master" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Directions Client Events</title>
    <meta name="description" content="GoogleMap - Directions Client Events" />
    <meta name="keywords" content="googlemap directions client events" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Directions Client Events
    </h1>
    <p>
        GoogleMap control directions client event handling sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleDirections ID="GoogleDirections1" TargetControlID="GoogleMap1" runat="server"
            OnClientChanged="handleChanged" Origin="plovdiv" Destination="sofia" Draggable="true"
            PanelID="route">
        </artem:GoogleDirections>
    </div>
    <div id="route">
    </div>
    <script type="text/javascript">
        function handleChanged(sender) {
            /// <summary>Handles google directions changed event.<summary>
            /// <param name="sender" type="Function">the instance of google directions which fired the event</param>

            // output params and info to console, if exists
            if (console) {
                console.dir(sender);
                console.dir(sender.getDirections());
            }
            alert("Directions was changed!");
        }
    </script>
</asp:Content>