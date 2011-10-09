<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="InfoContent.aspx.cs" Inherits="marker_InfoContent" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>GoogleMarker - InfoContent</title>
    <meta name="description" content="GoogleMap Control - GoogleMaprker info content sample." />
    <meta name="keywords" content="asp.net artem googlemap control marker info content" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" runat="Server">
    <h1>
        Info Content
    </h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
        EnableScrollWheelZoom="true" OnDoubleClick="HandleMapDoubleClick">
        <Markers>
            <artem:GoogleMarker Address="Plovdiv Bulgaria" Text="This is a <b>real</b> simple info window test.">
                <InfoWindowTemplate>
                    <a href='http://googlemap.artembg.com'>Visit online sample website.</a>
                </InfoWindowTemplate>
            </artem:GoogleMarker>
        </Markers>
    </artem:GoogleMap>
    <asp:Button ID="btnPost" runat="server" Text="Post" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phDescription" runat="Server">
    This is a sample of the InfoContent usage for GoogleMaker InfoWindowContent, where
    you can add any kind of controls to its Controls collection.
</asp:Content>
