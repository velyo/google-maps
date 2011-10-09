<%@ Page Language="C#" MasterPageFile="~/demo/maps/Master.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" Inherits="Artem.Google.Web.Demo.Maps.DefaultPage"
    CodeBehind="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap</title>
    <meta name="description" content="GoogleMap Control class." />
    <meta name="keywords" content="asp.net artem googlemap control" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        GoogleMap
    </h1>
    <p>
        A GoogleMap Control example to show the map location positioning.
    </p>
    <fieldset>
        <legend>Location</legend>
        <div>
            <asp:Label runat="server" Text="Point" AssociatedControlID="txtPoint" />
            <asp:TextBox ID="txtPoint" runat="server" Width="160px" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPoint" ErrorMessage="Invalid latitude/longitude format. Must be (^\-?\d+\.?\d+/\-?\d+\.?\d+$)"
                ValidationExpression="^\-?\d+\.?\d+/\-?\d+\.?\d+$" ValidationGroup="LocationValidation">*</asp:RegularExpressionValidator>
            format(Lat/Lng), or
        </div>
        <div>
            <asp:Label runat="server" Text="Address" AssociatedControlID="txtAddress" />
            <asp:TextBox ID="txtAddress" runat="server" Width="300px" />
        </div>
        <div style="padding-left: 120px;">
            <asp:Button ID="Button1" runat="server" Text="Show" OnClick="HandleShowClick" ValidationGroup="LocationValidation" />
        </div>
        <div>
            <asp:ValidationSummary runat="server" ValidationGroup="LocationValidation" />
        </div>
    </fieldset>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="HYBRID" Zoom="8" Latitude="42.1229"
            Longitude="24.7879" CssClass="map" DefaultAddress="sofia">
        </artem:GoogleMap>
    </div>
    <div id="pano"></div>
</asp:Content>
