<%@ Page Language="C#" MasterPageFile="~/directions/Directions.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleDirection</title>
    <meta name="description" content="GoogleMap Control GoogleDirection class." />
    <meta name="keywords" content="asp.net artem googlemap control directions" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        GoogleDirection
    </h1>
    <div class="box">
        <h4>
            Enter new directions query:</h4>
        <asp:Label runat="server" Text="Query" AssociatedControlID="_txtQuery"></asp:Label>
        <asp:TextBox ID="_txtQuery" runat="server" Width="300px"></asp:TextBox>
        <asp:Label runat="server" Text="Locale" AssociatedControlID="_txtLocale"></asp:Label>
        <asp:TextBox ID="_txtLocale" runat="server" Width="48px"></asp:TextBox>
        <asp:Button runat="server" Text="Show" OnClick="HandleShowDirectionsClick" />
    </div>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleDirections TargetControlID="GoogleMap1" runat="server"
            OnClientChanged="handleChanged" Origin="plovdiv" Destination="sofia" Draggable="true"
            PanelID="route">
        </artem:GoogleDirections>
    </div>
    <div id="route">
    </div>
    <script type="text/javascript">

        function handleChanged() {
            alert("GoogleDirections changed event was fired!");
        }
    </script>
</asp:Content>
<script runat="server">

    protected void HandleShowDirectionsClick(object sender, EventArgs e) {
    }
</script>
