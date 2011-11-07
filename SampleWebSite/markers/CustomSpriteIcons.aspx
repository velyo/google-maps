<%@ Page Title="" Language="C#" MasterPageFile="~/markers/Marker.master" %>

<asp:Content ContentPlaceHolderID="head" runat="Server">
    <title>GoogleMap - Markers - Custom Sprite Icons</title>
    <meta name="description" content="GoogleMap control markers' custom sprite icons sample." />
    <meta name="keywords" content="googlemap control markers custom sprite icons sample" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="Server">
    <h1>
        Markers Custom Sprite Icons
    </h1>
    <p>
        GoogleMap control markers' custom sprite icons sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
            Zoom="6" BorderStyle="Solid" CssClass="map">
        </artem:GoogleMap>
        <%--
        NOTICE THE VARIOUS WAYS YOU CAN SET THE ICONS' PROPERTIES
        --%>
        <artem:GoogleMarkers ID="GoogleMarkers1" TargetControlID="GoogleMap1" runat="server">
            <Markers>
                <artem:Marker Address="plovdiv" Title="Click on the marker" Info="Text of marker 1"
                    Icon-Url="/images/icons/sprites.gif" Icon-Size-Height="32" Icon-Size-Width="32">
                </artem:Marker>
                <artem:Marker Address="burgas" Title="Click on the marker" Info="Text of marker 2"
                    Icon-Url="/images/icons/sprites.gif" Icon-Origin-X="0" Icon-Origin-Y="32">
                    <Icon Size-Height="32" Size-Width="32"></Icon>
                </artem:Marker>
                <artem:Marker Position-Latitude="42.7" Position-Longitude="23.3" Title="Click on the marker"
                    Info="Text of marker 3">
                    <Icon Url="/images/icons/sprites.gif" Origin-X="32" Origin-Y="0" Size-Height="32" Size-Width="32">
                    </Icon>
                </artem:Marker>
                <artem:Marker Title="Click on the marker"
                    Info="Text of marker 4">
                    <Position Latitude="43.0" Longitude="24.0"/>
                    <Icon Url="/images/icons/sprites.gif" Origin-X="32" Origin-Y="32">
                        <Size Height="32" Width="32"/>
                        <Anchor X="16" Y="32" />
                    </Icon>
                </artem:Marker>
            </Markers>
            <MarkerOptions Draggable="true">
            </MarkerOptions>
        </artem:GoogleMarkers>
    </div>
</asp:Content>
