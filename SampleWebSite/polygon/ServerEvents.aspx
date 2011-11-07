<%@ Page Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false"
    CodeFile="~/polygon/ServerEvents.aspx.cs" Inherits=" Artem.GoogleMap.WebSite.Polygons.ServerEvents" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Polygon - Server Events</title>
    <meta name="description" content="GoogleMap control polygon client event handling sample." />
    <meta name="keywords" content="googlemap control polygon client event handling sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server">
    <h1>
        Polygon Server Events
    </h1>
    <p>
        GoogleMap control polygon client event handling sample.
        <br />
        The polygon fires next events: click, double click, mouse down, mouse move, mouse
        out, mouse over, mouse up, right click.<br />
        The event fired by the polyline will be listed in the info list bellow (most recent
        first).
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolygon TargetControlID="GoogleMap1" runat="server" OnClick="HandleClick">
            <%--
                TODO: Add some of those bellow to test them:
                OnDoubleClick="HandleDoubleClick"
                OnMouseDown="HandleMouseDown" 
                OnMouseOut="HandleMouseOut" 
                OnMouseOver="HandleMouseOver"
                OnMouseUp="HandleMouseUp" 
                OnRightClick="HandleRightClick"
            --%>
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
            <artem:LatLng Latitude="41.036501" Longitude="28.984895" />
            <artem:LatLng Latitude="44.447924" Longitude="26.097879" />
            <artem:LatLng Latitude="44.802416" Longitude="20.465601" />
            <artem:LatLng Latitude="42.002411" Longitude="21.436097" />
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
        </artem:GooglePolygon>
    </div>
    <div>
        Events (most recent first):
        <asp:Button runat="server" Text="Clear" OnClick="HandleClearClick" />
    </div>
    <asp:ListBox ID="lbEvents" runat="server" Rows="20" Width="100%"></asp:ListBox>
</asp:Content>
