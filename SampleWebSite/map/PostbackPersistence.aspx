<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="PostbackPersistence.aspx.cs" Inherits="map_PostbackPersistence" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>Postback Persistence Sample</title>
    <meta name="description" content="GoogleMap Control postback persistene sample." />
    <meta name="keywords" content="asp.net artem googlemap control postback persistence" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" runat="Server">
    <h1>
        GoogleMap Postback Persistence Sample</h1>
    <p>
        This is sample about GoogleMap control properties' values and changes persited back
        to server during postbacks.<br />
        To see the result of this demo, just drag the map to new location or change the
        zoom level.<br />
        The "Submit" button fires just a postback to server after which you can see the
        position and zoom persisted.<br />
        The "Save" button fires postback to server and saves position and zoom of the map
        to session, as well.<br />
        The "Restore" button fires postback to server and restores the last saved in session
        position and zoom.
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true" OnClick="HandleClick">
    </artem:GoogleMap>
    <div style="text-align: right; padding: 5px;">
        <asp:Button ID="_btnSubmit" runat="server" Text="Submit" Width="88px" />
        <asp:Button ID="_btnSave" runat="server" Text="Save" Width="88px" OnClick="HandleSaveClick" />
        <asp:Button ID="_btnRestore" runat="server" Text="Restore" Width="88px" OnClick="HandleRestoreClick" />
    </div>
</asp:Content>
