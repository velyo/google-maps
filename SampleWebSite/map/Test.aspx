<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="Test.aspx.cs" Inherits="map_Test" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="server">
    <h1>
        GoogleMap Test</h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true">
        <MarkerEvents OnClick="HandleClick" />
        <Markers>
            <artem:GoogleMarker Latitude="42.1229" Longitude="24.7879" Title="Click on the marker"
                Text="Test" Draggable="true">
                <InfoWindowTemplate>
                    <h1>
                        Info Window Content</h1>
                    <p>
                        This is an info window content template.</p>
                </InfoWindowTemplate>
            </artem:GoogleMarker>
        </Markers>
    </artem:GoogleMap>
    <a href="javascript:clear();">Clear</a>
    <script type="text/javascript">
                function clear() {
                    <%= GoogleMap1.ClientID %>.clearMarkers();
                }
    </script>
</asp:Content>
