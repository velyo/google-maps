<%@ Page Title="" Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false"
    CodeFile="CodeBehind.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Markers.CodeBehind" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Markers - Code Behind</title>
    <meta name="description" content="GoogleMap control markers code behind sample." />
    <meta name="keywords" content="googlemap control markers code behind sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers Code Behind
    </h1>
    <p>
        GoogleMap control markers code behind sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="6" EnableScrollWheelZoom="true" CssClass="map">
        </artem:GoogleMap>
    </div>
</asp:Content>
