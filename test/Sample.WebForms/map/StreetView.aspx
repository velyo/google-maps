<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="StreetView.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Maps.StreetView" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Map Street View
    </h1>
    <p>
        GoogleMap control street view sample.
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.345573" Longitude="-71.098326"
        Zoom="14">
    </artem:GoogleMap>
</asp:Content>
