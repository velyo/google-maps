<%@ Page Language="C#" MasterPageFile="~/demo/directions/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Directions.EventsPage" Codebehind="Events.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="Server">
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        GoogleDirection - Events
    </h1>
    <asp:Label runat="server" Text="Query" AssociatedControlID="_txtQuery"></asp:Label>
    <asp:TextBox ID="_txtQuery" runat="server" Width="300px"></asp:TextBox>
    <asp:Label runat="server" Text="Locale" AssociatedControlID="_txtLocale"></asp:Label>
    <asp:TextBox ID="_txtLocale" runat="server" Width="48px"></asp:TextBox>
    <asp:Button runat="server" Text="Show" OnClick="HandleShowDirectionsClick" />
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="37.559819"
        Longitude="-122.210540" Zoom="4">
        <DirectionsEvents OnClientAddOverlay="handleAddOverlay" OnClientError="handleError" OnClientLoad="handleLoad" />
        <Directions>
            <artem:GoogleDirections RoutePanelId="route" Query="from: San Francisco, CA to: Mountain View, CA" />
        </Directions>
    </artem:GoogleMap>
    <div id="route">
    </div>
    <select id="console" size="10" style="width: 100%;">
    </select>
    <fieldset>
        <legend>Extra Data</legend>
        <br />
        <asp:Literal ID="_ltrInfo" runat="server"></asp:Literal><br />
        <asp:Button runat="server" Text="Show" OnClick="HandleShowExtraData" />
    </fieldset>
    <script type="text/javascript">

        var console;
        function handleAddOverlay() {
            write("Directions addoverlay event fired!");
        }

        function handleError() {
            write("Directions error event fired!");
        }

        function handleLoad() {
            write("Directions load event fired!");
        }

        function write(message) {
            if (!console) console = document.getElementById("console");
            var item = document.createElement("option");
            item.innerText = message;
            console.appendChild(item);
        }
    </script>
</asp:Content>