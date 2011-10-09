<%@ Page Language="C#" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Maps.TestPage" Codebehind="Test.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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

    </div>
    </form>
</body>
</html>
