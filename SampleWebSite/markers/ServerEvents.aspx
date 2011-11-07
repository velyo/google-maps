<%@ Page Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false"
    CodeFile="~/markers/ServerEvents.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Polygons.ServerEvents" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Markers - Server Events</title>
    <meta name="description" content="GoogleMap control markers server event handling sample." />
    <meta name="keywords" content="googlemap control markers server event handling sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers Server Events
    </h1>
    <p>
        GoogleMap control markers server event handling sample.
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
            Zoom="4" EnableScrollWheelZoom="true" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server"
            OnClick="HandleClick" OnPositionChanged="HandlePositionChanged">
            <%--
            TODO Add some of those bellow to test them:
            OnAnimationChanged="HandleAnimationChanged"
            OnClickableChanged="HandleClickableChanged"
            OnCursorChanged="HandleCursorChanged"
            OnDoubleClick="HandleDoubleClick"
            OnDrag="HandleDrag"
            OnDragEnd="HandleDragEnd"
            OnDraggableChanged="HandleDraggableChanged"
            OnDragStart="HandleDragStart"
            OnFlatChanged="HandleFlatChanged"
            OnIconChanged="HandleIconChanged"
            OnMouseDown="HandleMouseDown"
            OnMouseOut="HandleMouseOut"
            OnMouseOver="HandleMouseOver"
            OnMouseUp="HandleMouseUp"
            OnRightClick="HandleRightClick"
            OnShadowChanged="HandleShadowChanged"
            OnShapeChanged="HandleShapeChanged"
            OnTitleChanged="HandleTitleChanged"
            OnVisibleChanged="HandleVisibleChanged"
            OnZIndexChanged="HandleZIndexChanged"
            --%>
            <Markers>
                <artem:Marker Position-Latitude="42.1229" Position-Longitude="24.7879" Title="Click on the marker"
                    Info="Text of marker 1">
                </artem:Marker>
                <artem:Marker Position-Latitude="42.1229" Position-Longitude="20." Title="Click on the marker"
                    Info="Text of marker 2">
                </artem:Marker>
            </Markers>
            <MarkerOptions Draggable="true">
            </MarkerOptions>
        </artem:GoogleMarkers>
    </div>
    <div>
        Events (most recent first):
        <asp:Button ID="Button1" runat="server" Text="Clear" OnClick="HandleClearClick" />
    </div>
    <asp:ListBox ID="lbEvents" runat="server" Rows="20" Width="100%"></asp:ListBox>
</asp:Content>
