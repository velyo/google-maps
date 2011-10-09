<%@ Page Language="C#" MasterPageFile="~/demo/maps/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Maps.DataBindingPage" Codebehind="DataBinding.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>Data Binding Sample</title>
    <meta name="description" content="GoogleMap Control data binding sample." />
    <meta name="keywords" content="asp.net artem googlemap control data binding" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        GoogleMap Data Binding Sample</h1>
    <p style="padding-bottom: 10px;">
        This sample shows how to bind GoogleMap control to DataSource for the markers.<br />
        The markers bellow are comming from an ObjectDataSource.<br />
        In same fashion you can bind GoogleMap Control to any DataSource.
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
        Longitude="24.7879" Zoom="4" EnableScrollWheelZoom="true" DataSourceID="_odsMarkers"
        DataAddressField="Address" DataTextField="Description">
    </artem:GoogleMap>
    <asp:ObjectDataSource ID="_odsMarkers" runat="server" OldValuesParameterFormatString="{0}"
        SelectMethod="GetMarkersData" TypeName="Artem.GoogleMap.WebSite.DataSourceHelper">
    </asp:ObjectDataSource>
</asp:Content>
