<%@ Page Language="C#" MasterPageFile="~/demo/markers/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Markers.MarkerStylePage" Codebehind="MarkerStyle.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMarker - Style</title>
    <meta name="description" content="GoogleMap Control - GoogleMaprker style sample." />
    <meta name="keywords" content="asp.net artem googlemap control marker style" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        Marker Style
    </h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
        EnableScrollWheelZoom="true">
        <Markers>
            <artem:GoogleMarker Address="sofia bulgaria" Text="Sofia Bulgaria">
            </artem:GoogleMarker>
            <artem:GoogleMarker Address="athens greece" Text="Athens Greece">
            </artem:GoogleMarker>
        </Markers>
        <MarkerStyle Title="Click on the marker">
            <Icon Url="~/images/arrow24.gif" Size-Height="24" Size-Width="24">
               <Anchor X="12" Y="24" />
            </Icon>
        </MarkerStyle>
    </artem:GoogleMap>
</asp:Content>