<%@ Page Language="C#" MasterPageFile="~/polyline/Polyline.master" AutoEventWireup="false"
    CodeFile="~/polyline/ServerEvents.aspx.cs" Inherits="polyline_ServerEvents" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Polyline - Server Events</title>
    <meta name="description" content="GoogleMap control polyline server event handling sample." />
    <meta name="keywords" content="googlemap control polyline server event handling sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Polyline Server Events
    </h1>
    <p>
        GoogleMap control polyline server event handling sample.
        <br />
        The polyline fires next events: click, double click, mouse down, mouse move, mouse
        out, mouse over, mouse up, right click.<br />
        The event fired by the polyline will be listed in the info list bellow (most recent
        first) by the server side code.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="7" CssClass="map">
        </artem:GoogleMap>
        <artem:GooglePolyline ID="GooglePolyline1" TargetControlID="GoogleMap1" runat="server"
            StrokeWeight="10" Clickable="true" OnClick="HandleClick">
            <%--
                     TODO: Add some of those bellow to test them:
                        OnDoubleClick="HandleDoubleClick"
                        OnMouseDown="HandleMouseDown" 
                        OnMouseOut="HandleMouseOut" 
                        OnMouseOver="HandleMouseOver"
                        OnMouseUp="HandleMouseUp" 
                        OnRightClick="HandleRightClick"
            --%>
            <artem:LatLng Latitude="42.14304" Longitude="24.74967" />
            <artem:LatLng Latitude="42.69649" Longitude="23.32601" />
        </artem:GooglePolyline>
    </div>
    <div>
        Events (most recent first):
        <asp:Button runat="server" Text="Clear" OnClick="HandleClearClick" />
    </div>
    <asp:ListBox ID="lbEvents" runat="server" Rows="20" Width="100%"></asp:ListBox>
</asp:Content>
