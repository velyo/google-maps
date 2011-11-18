<%@ Page Language="C#" MasterPageFile="~/directions/Directions.master" CodeFile="Default.aspx.cs"
    Inherits="Artem.GoogleMap.WebSite.Directions.Default" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Directions</title>
    <meta name="description" content="GoogleMap control directions sample." />
    <meta name="keywords" content="googlemap control directions sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Directions
    </h1>
    <p>
        GoogleMap control directions sample.<br />
        Enter the desired origin and distination of directions to show and click the 'Show'
        button.
    </p>
    <fieldset>
        <legend>Directions</legend>
        <p>
            <asp:Label runat="server" Text="Origin" AssociatedControlID="txtOrigin" />
            <asp:TextBox ID="txtOrigin" runat="server" Width="400px"></asp:TextBox>
        </p>
        <p>
            <asp:Label runat="server" Text="Destination" AssociatedControlID="txtDestination" />
            <asp:TextBox ID="txtDestination" runat="server" Width="400px"></asp:TextBox>
        </p>
        <p style="margin-bottom: 0;">
            <label>
                &nbsp;</label>
            <asp:Button runat="server" Text="Show" OnClick="HandleShowClick" />
        </p>
    </fieldset>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="4" CssClass="map">
        </artem:GoogleMap>
        <artem:GoogleDirections ID="GoogleDirections1" TargetControlID="GoogleMap1" runat="server"
            Origin="plovdiv" Destination="sofia" Draggable="true" PanelID="route">
        </artem:GoogleDirections>
    </div>
    <div id="route">
    </div>
</asp:Content>
