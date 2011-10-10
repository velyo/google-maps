<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="InUpdatePanel.aspx.cs" Inherits="map_InUpdatePanel" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>Inside UpdatePanel</title>
    <meta name="description" content="GoogleMap Control inside UpdatePanel sample." />
    <meta name="keywords" content="asp.net artem googlemap control ajax update panel" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Inside UpdatePanel
    </h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Address" AssociatedControlID="_txtAddress"></asp:Label>
                <asp:TextBox ID="_txtAddress" runat="server" Width="360px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="HandleShowClick" />
            </p>
            <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
                Zoom="5" ShowScaleControl="true">
            </artem:GoogleMap>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        A sample of GoogleMap control inside <b>UpdatePanel</b>.
    </p>
</asp:Content>
