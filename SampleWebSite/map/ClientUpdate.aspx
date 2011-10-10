<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="ClientUpdate.aspx.cs" Inherits="map_ClientUpdate" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>Client Update Sample</title>
    <meta name="description" content="GoogleMap Control client-side update sample." />
    <meta name="keywords" content="asp.net artem googlemap control client-side update" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        GoogleMap Client Update Sample</h1>
    <p style="padding-bottom: 10px;">
        This is a sample of how to do updates on the client-side of GoogleMap control without
        refreshing(reloading) the Google map.<br />
        The site will be automatically update with new markers from server-side code every
        5 seconds.
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4">
    </artem:GoogleMap>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Literal ID="_ltrScript" runat="server"></asp:Literal>
            <asp:Literal ID="_ltrCounter" runat="server" Text="Counter"></asp:Literal><br />
            <asp:Timer runat="server" Interval="5000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
