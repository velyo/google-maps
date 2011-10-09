<%@ Page Language="C#" MasterPageFile="~/demo/markers/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Markers.ServerGeocodingPage" Codebehind="ServerGeocoding.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMarker - Server Geocoding</title>
    <meta name="description" content="GoogleMap Control - GoogleMaprker server geocoding sample." />
    <meta name="keywords" content="asp.net artem googlemap control marker server geocoding" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        Server Geocoding
    </h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
        EnableScrollWheelZoom="true">
        <MarkerEvents OnGeoLocationLoaded="HandleGeoLoaded" />
    </artem:GoogleMap>
</asp:Content>