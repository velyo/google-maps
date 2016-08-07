<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlyOneInfoWindow.aspx.cs" Inherits="markers_OnlyOneInfoWindow" MasterPageFile="~/markers/Marker.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Markers - Only one info window</title>
    <meta name="description" content="GoogleMap control markers code behind sample." />
    <meta name="keywords" content="googlemap control markers code behind sample" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Only one infowindow
    </h1>
    <p>
        Show only one info window on click
    </p>
    <div class="map-wrap">
        <asp:Panel runat="server" ID="pnlControls">
        </asp:Panel>
    </div>
</asp:Content>
