<%@ Page Language="C#" %>

<%@ Register Src="~/controls/TestControl.ascx" TagName="TestControl" TagPrefix="site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <legend>Location</legend>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Point" AssociatedControlID="txtPoint" />
            <asp:TextBox ID="txtPoint" runat="server" Width="160px" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPoint"
                ErrorMessage="Invalid latitude/longitude format. Must be (^\-?\d+\.?\d+/\-?\d+\.?\d+$)"
                ValidationExpression="^\-?\d+\.?\d+/\-?\d+\.?\d+$" ValidationGroup="LocationValidation">*</asp:RegularExpressionValidator>
            format(Lat/Lng), or
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Address" AssociatedControlID="txtAddress" />
            <asp:TextBox ID="txtAddress" runat="server" Width="300px" />
        </div>
        <div style="padding-left: 120px;">
            <asp:Button ID="Button1" runat="server" Text="Show" OnClick="HandleShowClick" ValidationGroup="LocationValidation" />
        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="LocationValidation" />
        </div>
    </fieldset>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="Hybrid" CssClass="map"
            Latitude="42.345573" Longitude="-71.098326" Zoom="14">
            <%--Latitude="42.1229" Longitude="24.7879"--%>
        </artem:GoogleMap>
        <artem:GoogleStreetView TargetControlID="GoogleMap1" runat="server" />
        <%--<artem:GoogleMarkers TargetControlID="GoogleMap1" runat="server" />--%>
        <%--<artem:GooglePolygon TargetControlID="GoogleMap1" runat="server" OnClick="HandleClick" OnClientRightClick="test">
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
            <artem:LatLng Latitude="41.036501" Longitude="28.984895" />
            <artem:LatLng Latitude="44.447924" Longitude="26.097879" />
            <artem:LatLng Latitude="44.802416" Longitude="20.465601" />
            <artem:LatLng Latitude="42.002411" Longitude="21.436097" />
            <artem:LatLng Latitude="37.97918" Longitude="23.716647" />
        </artem:GooglePolygon>--%>
        <%--<artem:GoogleCircle TargetControlID="GoogleMap1" runat="server" Center="42.002411,21.436097"
            Radius="100000" OnClick="HandleClick" OnClientRightClick="test" />--%>
        <%--<artem:GoogleRectangle TargetControlID="GoogleMap1" runat="server" OnClick="HandleClick"
            OnClientRightClick="test" FillColor="Green" Bounds-SouthWest="44.802416,20.465601"
            Bounds-NorthEast="37.97918,23.716647">
        </artem:GoogleRectangle>--%>
        <%--Bounds="44.802416,20.465601:37.97918,23.716647"--%>
        <%--<artem:GooglePolyline TargetControlID="GoogleMap1" runat="server" StrokeWeight="5" OnClientClick="test" OnRightClick="HandleClick">
            <artem:LatLng Latitude="42.14304" Longitude="24.74967" />
            <artem:LatLng Latitude="42.69649" Longitude="23.32601" />
        </artem:GooglePolyline>--%>
        <%--<artem:GoogleDirections TargetControlID="GoogleMap1" runat="server" OnClientChanged="test"
            Origin="plovdiv" Destination="sofia" Draggable="true" PanelID="info" OnChanged="HandleChanged">
        </artem:GoogleDirections>--%>
    </div>
    <div id="info">
    </div>
    <%--<site:TestControl ID="ctrTest" runat="server" />--%>
    </form>
    <script type="text/javascript">
        function test() {
            alert("Test!");
        }
    </script>
</body>
</html>
<script runat="server">
    #region Methods

    /// <summary>
    /// Handles the show click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowClick(object sender, EventArgs e) {

        string point = txtPoint.Text;
        if (!string.IsNullOrEmpty(point)) {
            string[] pair = point.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (pair.Length == 2) {
                double lat, lng;

                if (double.TryParse(pair[0], out lat)) {
                    if (double.TryParse(pair[1], out lng)) {
                        GoogleMap1.Center.Latitude = lat;
                        GoogleMap1.Center.Longitude = lng;
                    }
                }
            }
        }
        else {
            string address = txtAddress.Text;
            if (!string.IsNullOrEmpty(address)) {
                GoogleMap1.Address = address;
            }
        }

        txtAddress.Text = null;
        txtPoint.Text = null;
    }

    protected void HandleChanged(object sender, DirectionsChangedEventArgs e) {
        int i = 0;
    }

    protected void HandleClick(object sender, MouseEventArgs e) {
        int i = 0;
    }
    #endregion
</script>
