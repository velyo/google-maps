<%@ Page Language="C#" MasterPageFile="~/demo/markers/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Markers.InfoContentPage" Codebehind="InfoContent.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMarker - InfoContent</title>
    <meta name="description" content="GoogleMap Control - GoogleMaprker info content sample." />
    <meta name="keywords" content="asp.net artem googlemap control marker info content" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
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
    <h3>
        Descrption
    </h3>
    <p>
        This is a sample of the InfoContent usage for GoogleMaker InfoWindowContent, where
        you can add any kind of controls to its Controls collection.
    </p>
</asp:Content>
