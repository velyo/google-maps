<%@ Page Title="" Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false"
    CodeFile="CodeBehind.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Markers.CodeBehind" %>

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
