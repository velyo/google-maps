<%@ Control Language="C#" AutoEventWireup="false" CodeFile="TestControl.ascx.cs"
    Inherits="controls_TestControl" %>
<artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude="42.1229"
    Longitude="24.7879" Zoom="4">
    <Markers>
        <artem:GoogleMarker Latitude="42.1229" Longitude="24.7879" Title="Click on the marker"
            Text="Text of marker 1" Draggable="true">
        </artem:GoogleMarker>
        <artem:GoogleMarker Position="42.1229,20.0" Title="Click on the marker" Text="Text of </b>marker</b> 2"
            Draggable="true">
        </artem:GoogleMarker>
        <artem:GoogleMarker Address="sofia bulgaria" Text="Sofia Bulgaria" AutoOpenInfo="true">
        </artem:GoogleMarker>
        <artem:GoogleMarker Address="athens greece" Text="Athens Greece" OpenInfoBehaviour="MouseOver" InfoWindowOptions-MaxWidth="30">
            <InfoWindowTemplate>
                <h1>Test</h1>
                <p>This is a test</p>
            </InfoWindowTemplate>
        </artem:GoogleMarker>
    </Markers>
</artem:GoogleMap>
<%--<artem:GoogleMap ID="GoogleMap1" runat="server" Address="aaaaaaaa" DefaultAddress="london"
    Zoom="8" EnableReverseGeocoding="true" Language="bg" Region="BG" ShowNavigationControl="true"
    ShowScaleControl="true" EnableScrollWheelZoom="true" ShowStreetViewControl="true">
    <MapTypeControlOptions Position="TopRight" ViewStyle="DropdownMenu" />
    <NavigationControlOptions Position="TopLeft" ViewStyle="Default" />
    <ScaleControlOptions Position="BottomLeft" ViewStyle="Default" />
    <StreetView Pano="panorama" Visible="false">
        <AddressControlOptions Position="BottomLeft" ViewStyle="{backgroundColor: 'red'}" />
    </StreetView>
    <Markers>
    </Markers>--%>
<%--<Polygons>
        <artem:GooglePolygon FillColor="Red" FillOpacity=".8" StrokeColor="Blue" StrokeWeight="2">
            <Points>
                <artem:GoogleLocation Latitude="7.97918" Longitude="3.716647" />
                <artem:GoogleLocation Latitude="11.036501" Longitude="8.984895" />
                <artem:GoogleLocation Latitude="14.447924" Longitude="6.097879" />
                <artem:GoogleLocation Latitude="14.802416" Longitude="0.465601" />
                <artem:GoogleLocation Latitude="12.002411" Longitude="1.436097" />
                <artem:GoogleLocation Latitude="7.97918" Longitude="3.716647" />
            </Points>
        </artem:GooglePolygon>
    </Polygons>--%>
<%--Center="42.1229,24.7879"--%>
<%--<Polylines>
                        <artem:GooglePolyline Color="Red">
                            <artem:GoogleLocation Latitude="42.0" Longitude="24.0"/>
                            <artem:GoogleLocation Latitude="42.0" Longitude="25.0"/>
                            <artem:GoogleLocation Latitude="43.0" Longitude="24.0"/>
                        </artem:GooglePolyline>
                    </Polylines>--%>
<%--<Markers>
                        <artem:GoogleMarker Address="1 bushwick new york" Draggable="true" Text="1 bushwick new york" />
                        <artem:GoogleMarker Address="2 bushwick new york" Draggable="true" Text="2 bushwick new york" />
                    </Markers>--%>
<%--</artem:GoogleMap>
<div id="panorama" style="height: 400px;">
</div>--%>
<asp:Button runat="server" Text="Submit" />
