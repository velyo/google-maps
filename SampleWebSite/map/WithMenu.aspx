<%@ Page Language="C#" MasterPageFile="~/map/Map.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - With Menu</title>
    <meta name="description" content="GoogleMap control on page with ASP.NET menu sample." />
    <meta name="keywords" content="googlemap control on page with asp.net menu sample" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Map With Menu
    </h1>
    <p>
        GoogleMap control on page with ASP.NET menu sample.
    </p>
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
        <Items>
            <asp:MenuItem Text="Item 1"/>
            <asp:MenuItem Text="Item 2"/>
        </Items>
    </asp:Menu>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="HYBRID" Zoom="8" Latitude="42.1229"
            Longitude="24.7879" CssClass="map" DefaultAddress="sofia">
        </artem:GoogleMap>
    </div>
</asp:Content>
