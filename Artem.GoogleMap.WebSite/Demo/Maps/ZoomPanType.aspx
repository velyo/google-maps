<%@ Page Language="C#" MasterPageFile="~/demo/maps/Master.master" AutoEventWireup="true"
    Inherits="Artem.Google.Web.Demo.Maps.ZoomPanTypePage" CodeBehind="ZoomPanType.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>ZoomPanType Sample</title>
    <meta name="description" content="GoogleMap Control zoom pan type sample." />
    <meta name="keywords" content="asp.net artem googlemap control zoom pan type" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        ZoomPanType Sample</h1>
    <p>
        <asp:DropDownList ID="ddlZoomPanType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="HandleZoomPanTypeChanged">
            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
            <asp:ListItem Text="SmallZoom" Value="SmallZoom"></asp:ListItem>
            <asp:ListItem Text="Small3D" Value="Small3D"></asp:ListItem>
            <asp:ListItem Text="Large3D" Value="Large3D"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="5" ShowScaleControl="true" EnableMarkerManager="true"
        ZoomPanType="Small">
    </artem:GoogleMap>
</asp:Content>
