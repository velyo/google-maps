<%@ Page Language="C#" MasterPageFile="~/directions/Directions.master" AutoEventWireup="false"
    CodeFile="ServerEvents.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Directions.ServerEvents" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Directions Server Events</title>
    <meta name="description" content="GoogleMap - Directions Server Events" />
    <meta name="keywords" content="googlemap directions server events" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Directions Server Events
    </h1>
    <p>
        GoogleMap control directions server event handling sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleDirections ID="GoogleDirections1" TargetControlID="GoogleMap1" runat="server"
            Origin="plovdiv" Destination="sofia" Draggable="true" PanelID="route" OnChanged="HandleDirectionsChanged">
        </artem:GoogleDirections>
    </div>
    <asp:PlaceHolder ID="phRoutes" runat="server">
        <div id="route">
        </div>
    </asp:PlaceHolder>
</asp:Content>
