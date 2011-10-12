<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="true"
    CodeFile="EnableDrawing.aspx.cs" Inherits="polyline_EnableDrawing" %>

<asp:Content ID="cntHead" ContentPlaceHolderID="phHead" runat="Server">
    <title>GooglePolyline - EnableDrawing</title>
    <meta name="description" content="GoogleMap Control - GooglePolyline EnableDrawing sample." />
    <meta name="keywords" content="asp.net artem googlemap control polyline enable drawing" />
</asp:Content>
<asp:Content ID="cntContent" ContentPlaceHolderID="phContent" runat="Server">
    <h1>
        GooglePolyline - EnableDrawing</h1>
    <p>
        Click on the map below to build points of the polyline<br />
        Then click to button 'Draw' to draw it.</p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true">
        <Polylines>
            <artem:GooglePolyline Color="Blue" Weight="2" Opacity="1" IsClickable="true" IsGeodesic="false"
                EnableDrawing="true" EditingFromStart="false" EditingMaxVertices="35">
                <artem:LatLng Latitude="42.1229" Longitude="24.7879" />
                <artem:LatLng Latitude="51.34433" Longitude="16.17578" />
                <artem:LatLng Latitude="41.70572" Longitude="12.39257" />
            </artem:GooglePolyline>
        </Polylines>
    </artem:GoogleMap>
</asp:Content>
