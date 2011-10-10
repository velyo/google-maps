<%@ Page Title="" Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="Behavior.aspx.cs" Inherits="map_Behavior" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Behavior</title>
    <meta name="description" content="GoogleMap Control demo pages." />
    <meta name="keywords" content="asp.net artem googlemap control demo" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="server">
    <h1>
        GoogleMap Behavior
    </h1>
    <p>
        This demonstrates all the behavior settings of GoogleMap control.
    </p>
    <fieldset>
        <legend>Behavior</legend>
        <%--<div>
            <asp:Label ID="Label1" runat="server" Text="Point" AssociatedControlID="txtPoint" />
            <asp:TextBox ID="txtPoint" runat="server" Width="160px" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPoint" ErrorMessage="Invalid latitude/longitude format. Must be (^\-?\d+\.?\d+/\-?\d+\.?\d+$)"
                ValidationExpression="^\-?\d+\.?\d+/\-?\d+\.?\d+$" ValidationGroup="LocationValidation">*</asp:RegularExpressionValidator>
            format(Lat/Lng), or
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Address" AssociatedControlID="txtAddress" />
            <asp:TextBox ID="txtAddress" runat="server" Width="300px" />
        </div>--%>
        <div style="padding-left: 120px;">
            <asp:Button ID="Button1" runat="server" Text="Show" OnClick="HandleShowClick" ValidationGroup="LocationValidation" />
        </div>
        <%--<div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="LocationValidation" />
        </div>--%>
    </fieldset>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="HYBRID" Zoom="8" Latitude="42.1229"
            Longitude="24.7879" CssClass="map" DefaultAddress="sofia">
        </artem:GoogleMap>
    </div>
</asp:Content>
