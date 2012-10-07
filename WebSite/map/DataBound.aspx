<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Data Bound</title>
    <meta name="description" content="GoogleMap control data bound sample." />
    <meta name="keywords" content="googlemap control data bound sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Map Data Bound
    </h1>
    <p>
        GoogleMap control data bound sample.
    </p>
    <p style="padding-bottom: 10px;">
        This sample shows a case when GoogleMap control is inside a data bound control and
        some of its properties could be bind to data source properties/fields.
    </p>
    <asp:FormView ID="_fvGooleDataBound" runat="server" DataSourceID="_odsGoogleMap"
        DefaultMode="ReadOnly">
        <ItemTemplate>
            <div class="map-wrap">
                <artem:GoogleMap ID="GoogleMap1" runat="server" CssClass="map" Latitude='<%# DataBinder.Eval(Container.DataItem, "Latitude") %>'
                    Longitude='<%# DataBinder.Eval(Container.DataItem, "Longitude") %>' Zoom='<%# DataBinder.Eval(Container.DataItem, "Zoom") %>'>
                </artem:GoogleMap>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="_odsGoogleMap" runat="server" OldValuesParameterFormatString="{0}"
        SelectMethod="GetMapData" TypeName="Artem.GoogleMap.WebSite.DataSourceHelper">
    </asp:ObjectDataSource>
</asp:Content>
