<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="Default.aspx.cs" Inherits="map_GoogleMap" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
