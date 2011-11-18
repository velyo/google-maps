<%@ Page Title="" Language="C#" MasterPageFile="~/polygon/Polygon.master" AutoEventWireup="false"
    CodeFile="CodeBehind.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Polygons.CodeBehind" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Polygon - Code Behind</title>
    <meta name="description" content="GoogleMap control polygon code behind sample." />
    <meta name="keywords" content="googlemap control polygon code behind sample" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Polygon Code Behind
    </h1>
    <p>
        GoogleMap control polygon code behind sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" CssClass="map">
        </artem:GoogleMap>
    </div>
</asp:Content>
