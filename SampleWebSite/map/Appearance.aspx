<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="Appearance.aspx.cs" Inherits="map_Appearance" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Appearance</title>
    <meta name="description" content="GoogleMap Control demo pages." />
    <meta name="keywords" content="asp.net artem googlemap control demo" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="server">
    <h1>
        GoogleMap Appearance
    </h1>
    <p>
        This demonstrates all the appearance settings of GoogleMap control.
    </p>
    <fieldset>
        <legend>Appearance</legend>
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
