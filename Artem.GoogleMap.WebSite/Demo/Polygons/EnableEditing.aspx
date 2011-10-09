<%@ Page Language="C#" MasterPageFile="~/demo/polygons/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Polygons.EnableEditingPage" Codebehind="EnableEditing.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="Server">
    <title>GooglePolygon - Enable Editing</title>
    <meta name="description" content="GoogleMap Control - GooglePolygon enable editing sample." />
    <meta name="keywords" content="asp.net artem googlemap control polygon enable editing" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        GooglePolygon - Enable Editing
    </h1>
    <p>
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true">
        <Polygons>
            <artem:GooglePolygon FillColor="Red" FillOpacity=".8" StrokeColor="Blue" StrokeWeight="2">
                <%--EnableEditing="true">--%>
                <artem:GoogleLocation Latitude="37.97918" Longitude="23.716647" />
                <artem:GoogleLocation Latitude="41.036501" Longitude="28.984895" />
                <artem:GoogleLocation Latitude="44.447924" Longitude="26.097879" />
                <artem:GoogleLocation Latitude="44.802416" Longitude="20.465601" />
                <artem:GoogleLocation Latitude="42.002411" Longitude="21.436097" />
                <artem:GoogleLocation Latitude="37.97918" Longitude="23.716647" />
            </artem:GooglePolygon>
        </Polygons>
    </artem:GoogleMap>
</asp:Content>
