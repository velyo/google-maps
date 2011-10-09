<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="Default.aspx.cs" Inherits="direction_GoogleDirection" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>GoogleDirection</title>
    <meta name="description" content="GoogleMap Control GoogleDirection class." />
    <meta name="keywords" content="asp.net artem googlemap control directions" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="Server">
    <h1>
        GoogleDirection
    </h1>
    <div class="box">
        <h4>Enter new directions query:</h4>
        <asp:Label runat="server" Text="Query" AssociatedControlID="_txtQuery"></asp:Label>
        <asp:TextBox ID="_txtQuery" runat="server" Width="300px"></asp:TextBox>
        <asp:Label runat="server" Text="Locale" AssociatedControlID="_txtLocale"></asp:Label>
        <asp:TextBox ID="_txtLocale" runat="server" Width="48px"></asp:TextBox>
        <asp:Button runat="server" Text="Show" OnClick="HandleShowDirectionsClick" />
    </div>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="37.559819"
        Longitude="-122.210540" Zoom="4">
        <Directions>
            <artem:GoogleDirections RoutePanelId="route" Query="from: San Francisco, CA to: Mountain View, CA" />
        </Directions>
    </artem:GoogleMap>
    <div id="route">
    </div>
    <fieldset>
        <legend>PostBack Data</legend>
        <br />
        <asp:Literal ID="_ltrInfo" runat="server"></asp:Literal><br />
        <asp:Button runat="server" Text="PostBack" OnClick="HandleShowExtraData" />
    </fieldset>
</asp:Content>
<asp:Content ContentPlaceHolderID="phDescription" runat="server">
    Wraps Google Maps API class GDirections. This class is used to obtain driving directions
    results and display them on a map and/or a text panel.
    <p>
        The control above is initialized with this code.</p>
    <pre style="height: 104px;">&lt;artem:GoogleMap ID="GoogleMap2" runat="server" Width="530px" Height="500px" Latitude="37.559819" Longitude="-122.210540"
    Zoom="4" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1"&gt;
    &lt;Directions&gt;
        &lt;artem:GoogleDirection RoutePanelId="route" Query="from: San Francisco, CA to: Mountain View, CA" /&gt;
    &lt;/Directions&gt;
&lt;/artem:GoogleMap&gt;</pre>
</asp:Content>
<asp:Content ContentPlaceHolderID="phProperties" runat="server">
    <ul class="props">
        <li><b>Bounds</b> - Gets or sets the bounds of the GoogleDirection. It is used to get
            the bounding box for the result of this directions query. Have in mind it requires
            an additional post back after driving directions are loaded.</li>
        <li><b>Distance</b> - Gets or sets the distance of the GoogleDirection. Returns an object
            literal representing the total distance of the directions request (across all routes).
            Have in mind it requires an additional post back after driving directions are loaded.</li>
        <li><b>Duration</b> - Gets or sets the duration of the GoogleDirection. Returns an object
            literal representing the total time of the directions request (across all routes).
            Have in mind it requires an additional post back after driving directions are loaded.</li>
        <li><b>Locale</b> - Gets or sets a value indicating whether the GoogleDirection is localized.
            The locale to use for the directions result. For example, "en_US", "fr", "fr_CA",
            etc.</li>
        <li><b>Query</b> - Gets or sets the query of GoogleDirection. The query parameter is
            a string containing any valid directions query, e.g. "from: Seattle to: San Francisco"
            or "from: Toronto to: Ottawa to: New York".</li>
        <li><b>RoutePanelId</b> - Gets or sets the route panel id. The textual directions associated
            with the result are added to the indicated DIV, replacing any existing content in
            the DIV. If either of these arguments is null, the associated elements are not retrieved
            unless explicitly requested in the GDirections.load()</li>
    </ul>
</asp:Content>
