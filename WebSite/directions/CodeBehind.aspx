<%@ Page Title="" Language="C#" MasterPageFile="~/directions/Directions.master" AutoEventWireup="false"
    CodeFile="CodeBehind.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Directions.CodeBehind" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Directions - Code Behind</title>
    <meta name="description" content="GoogleMap control directions code behind sample." />
    <meta name="keywords" content="googlemap control directions code behind sample" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Directions Code Behind
    </h1>
    <p>
        GoogleMap control directions code behind sample.<br />
        Enter the desired origin and distination of directions to show and click the 'Show'
        button.
    </p>
    <fieldset>
        <legend>Directions</legend>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Origin" AssociatedControlID="txtOrigin" />
            <asp:TextBox ID="txtOrigin" runat="server" Width="400px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Destination" AssociatedControlID="txtDestination" />
            <asp:TextBox ID="txtDestination" runat="server" Width="400px"></asp:TextBox>
        </p>
        <p style="margin-bottom: 0;">
            <label>
                &nbsp;</label>
            <asp:Button ID="Button1" runat="server" Text="Show" OnClick="HandleShowClick" />
        </p>
    </fieldset>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="4" CssClass="map">
        </artem:GoogleMap>
    </div>
    <div id="route">
    </div>
</asp:Content>
