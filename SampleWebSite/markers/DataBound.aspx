<%@ Page Language="C#" MasterPageFile="~/markers/Marker.master" AutoEventWireup="false"
    CodeFile="~/markers/DataBound.aspx.cs" Inherits="Artem.GoogleMap.WebSite.DataBound"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>GoogleMap - Markers - Data Bound</title>
    <meta name="description" content="GoogleMap - Markers." />
    <meta name="keywords" content="asp.net googlemap control markers" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers - Data Bound
    </h1>
    <p>
        Shows how to use data source in order to bind markers on the map.<br />
        Drag and zoom the map to desired position and code will generate random markers
        (20 by default) inside the current bounds of the map.
    </p>
    <fieldset>
        <legend>Settings</legend>
        <label>
            Change markers' count</label>
        <asp:TextBox ID="txtCount" runat="server" OnTextChanged="HandleTextCountChanged"></asp:TextBox>
    </fieldset>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true" OnDragEnd="Generate"
            OnZoomChanged="Generate" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server"
            DataSourceID="odsMarkers" DataLatitudeField="Lat" DataLongitudeField="Lng" DataInfoField="Info">
            <MarkerOptions Draggable="true">
            </MarkerOptions>
            <InfoWindowOptions DisableAutoPan="true" />
        </artem:GoogleMarkers>
    </div>
    <asp:ObjectDataSource ID="odsMarkers" runat="server" TypeName="Artem.GoogleMap.WebSite.Models.MarkersRepository"
        SelectMethod="GetTestMarkers" OnSelecting="HandleDataSelecting">
        <SelectParameters>
            <asp:Parameter Name="count" Type="Int32" DefaultValue="20" />
            <asp:Parameter Name="bounds" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
