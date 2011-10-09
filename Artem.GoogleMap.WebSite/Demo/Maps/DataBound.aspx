<%@ Page Language="C#" MasterPageFile="~/demo/maps/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Maps.DataBoundPage" Codebehind="DataBound.aspx.cs" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>DataBound Sample</title>
    <meta name="description" content="GoogleMap Control data bound sample." />
    <meta name="keywords" content="asp.net artem googlemap control data bound" />
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="Server">
    <h1>
        GoogleMap DataBound Sample
    </h1>
    <p style="padding-bottom: 10px;">
        This sample shows a case when GoogleMap control is inside a data bound control and
        some of its properties could be bind to data source properties/fields.
    </p>
    <asp:FormView ID="_fvGooleDataBound" runat="server" DataSourceID="_odsGoogleMap"
        DefaultMode="ReadOnly">
        <ItemTemplate>
            <artem:GoogleMap ID="GoogleMap1" runat="server" Width="634px" Height="600px" Latitude='<%# DataBinder.Eval(Container.DataItem, "Latitude") %>'
                Longitude='<%# DataBinder.Eval(Container.DataItem, "Longitude") %>' Zoom='<%# DataBinder.Eval(Container.DataItem, "Zoom") %>'>
            </artem:GoogleMap>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="_odsGoogleMap" runat="server" OldValuesParameterFormatString="{0}"
        SelectMethod="GetMapData" TypeName="Artem.GoogleMap.WebSite.DataSourceHelper">
    </asp:ObjectDataSource>
</asp:Content>
