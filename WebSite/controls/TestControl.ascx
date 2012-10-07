<%@ Control Language="C#" AutoEventWireup="false" CodeFile="TestControl.ascx.cs"
    Inherits="controls_TestControl" %>
<h1>
    GoogleMap
</h1>
<p>
    A GoogleMap Control example to show the map location positioning.
</p>
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
<div class="map-wrap">
    <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="HYBRID" Zoom="8" Latitude="42.1229"
        Longitude="24.7879" CssClass="map" DefaultAddress="sofia">
    </artem:GoogleMap>
</div>
<%--<artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
    Longitude="24.7879" Zoom="4">
    <Markers>
        <artem:GoogleMarker Latitude="42.1229" Longitude="24.7879" Title="Click on the marker"
            Text="Text of marker 1" Draggable="true">
        </artem:GoogleMarker>
        <artem:GoogleMarker Position="42.1229,20.0" Title="Click on the marker" Text="Text of </b>marker</b> 2"
            Draggable="true">
        </artem:GoogleMarker>
        <artem:GoogleMarker Address="sofia bulgaria" Text="Sofia Bulgaria" AutoOpenInfo="true">
        </artem:GoogleMarker>
        <artem:GoogleMarker Address="athens greece" Text="Athens Greece" OpenInfoBehaviour="MouseOver"
            InfoWindowOptions-MaxWidth="30">
            <InfoWindowTemplate>
                <h1>
                    Test</h1>
                <p>
                    This is a test</p>
            </InfoWindowTemplate>
        </artem:GoogleMarker>
    </Markers>
</artem:GoogleMap>
<asp:Button runat="server" Text="Submit" />--%>
