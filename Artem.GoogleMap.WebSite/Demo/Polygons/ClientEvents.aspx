<%@ Page Language="C#" MasterPageFile="~/demo/polygons/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Polygons.ClientEventsPage" Codebehind="ClientEvents.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GooglePolygon - Client Events</title>
    <meta name="description" content="GoogleMap Control - GooglePolygon client events sample." />
    <meta name="keywords" content="asp.net artem googlemap control polygon client events" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="server">

    <script type="text/javascript">
    
        function __setLocation(overlay, point) {
            var latField = document.getElementById('<%= _lat.ClientID %>');
            var lngField = document.getElementById('<%= _lng.ClientID %>');
            latField.value = point.lat();
            lngField.value = point.lng();
            <%= this.ClientScript.GetPostBackEventReference(_btnSubmit, "") %>;
        }
    </script>

    <h1>
        Client Events
    </h1>
    <p>
        Click on the map bellow.<br />
        After second click you will start drawing rectangles.</p>
    <hr style="visibility: hidden;" />
    <asp:UpdatePanel runat="server" ID="upTest">
        <ContentTemplate>
            <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
                Longitude="24.7879" Zoom="4" OnClientClick="__setLocation">
            </artem:GoogleMap>
            <asp:HiddenField ID="_lat" runat="server" />
            <asp:HiddenField ID="_lng" runat="server" />
            <asp:LinkButton ID="_btnSubmit" runat="server" Text=""></asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
