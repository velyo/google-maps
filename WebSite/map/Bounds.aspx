<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="Bounds.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Maps.BoundsPage" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Map Bounds</title>
    <meta name="description" content="GoogleMap control bounds sample." />
    <meta name="keywords" content="googlemap control sample bounds" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        Map Bounds
    </h1>
    <p>
        GoogleMap control bounds sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" MapType="HYBRID" Zoom="8" CssClass="map"
            Bounds-NorthEast-Latitude="42.2697868981211" Bounds-NorthEast-Longitude="24.9835939697266"
            Bounds-SouthWest-Latitude="42.02542336268529" Bounds-SouthWest-Longitude="24.5441408447266">
            <%--TODO uncoment to use different markup--%>
            <%--<Bounds NorthEast-Latitude="42.2697868981211" NorthEast-Longitude="24.9835939697266"
                SouthWest-Latitude="42.02542336268529" SouthWest-Longitude="24.5441408447266" />
            <Bounds>
                <NorthEast Latitude="42.2697868981211" Longitude="24.9835939697266" />
                <SouthWest Latitude="42.02542336268529" Longitude="24.5441408447266" />
            </Bounds>--%>
        </artem:GoogleMap>
    </div>
</asp:Content>
