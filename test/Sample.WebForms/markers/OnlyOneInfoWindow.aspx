<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlyOneInfoWindow.aspx.cs" Inherits="markers_OnlyOneInfoWindow" MasterPageFile="~/markers/Marker.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Only one info window
    </h1>
    <p>
        Show only one info window on click
    </p>
    <div class="map-wrap">
        <asp:Panel runat="server" ID="pnlControls">
        </asp:Panel>
    </div>
</asp:Content>
