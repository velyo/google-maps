<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="CustomIcons.aspx.cs" Inherits="marker_CustomIcons" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMarker - Custom Icons</title>
    <meta name="description" content="GoogleMap Control markers custom icons." />
    <meta name="keywords" content="asp.net artem googlemap control marker custom icons" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Custom Icons Sample
    </h1>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="5" BorderStyle="Solid">
        <%--<Markers>
            <artem:GoogleMarker Address="sofia bulgaria" Icon-Url="/images/arrow24.gif" Icon-Size-Height="24"
                Icon-Size-Width="24" Icon-Anchor-X="12" Icon-Anchor-Y="24" Text="Sofia Bulgaria">
            </artem:GoogleMarker>
            <artem:GoogleMarker Address="athens greece" Text="Athens Greece">
                <Icon Url="/images/rabbit.jpg" Anchor-X="30" Anchor-Y="75">
                    <Size Width="60" Height="75" />
                </Icon>
            </artem:GoogleMarker>
        </Markers>--%>
    </artem:GoogleMap>
    <asp:Button runat="server" Text="Submit" />
</asp:Content>