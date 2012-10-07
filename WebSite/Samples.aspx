<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" %>

<asp:Content ID="headCntent" ContentPlaceHolderID="head" runat="server">
    <title>Samples - GoogleMap Control Website</title>
    <meta name="description" content="Samples - GoogleMap Control Website" />
    <meta name="keywords" content="Samples - GoogleMap Control Website" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        GoogleMap Control Samples</h1>
    <p>
        Welcome to GoogleMap Control samples. Choose from any of the main sample topics.
    </p>
    <ul>
        <li><a href="/map/Default.aspx">maps</a> - a general GoogleMap control usage and features;</li>
        <li><a href="/markers/Default.aspx">markers</a> - markers usage and features;</li>
        <li><a href="/polygon/Default.aspx">polygons</a> - polygons usage and features;</li>
        <li><a href="/polyline/Default.aspx">polylines</a> - polylines usage and features;</li>
        <li><a href="/directions/Default.aspx">directions</a> - directions usage and features;</li>
    </ul>
</asp:Content>
