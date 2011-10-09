<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="ListDataBound.aspx.cs" Inherits="examples_ListDataBound" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>DataList Data Bind Sample</title>
    <meta name="description" content="GoogleMap Control DataList data binding sample." />
    <meta name="keywords" content="asp.net artem googlemap control data binding" />
</asp:Content>
<asp:Content ContentPlaceHolderID="phContent" ID="cntContent" runat="server">
    <asp:DataList ID="dlSample" runat="server" OnItemDataBound="HandleItemDataBound"
        DataSourceID="odsSample">
        <ItemTemplate>
            <artem:GoogleMap ID="crtGooleMap" runat="server" Width="640px" Height="600px">
            </artem:GoogleMap>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="odsSample" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetMapData" TypeName="Artem.GoogleMap.WebSite.DataSourceHelper">
    </asp:ObjectDataSource>
</asp:Content>
