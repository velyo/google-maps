<%@ Page Title="" Language="C#" MasterPageFile="~/polyline/Polyline.master" AutoEventWireup="false"
    CodeFile="CodeBehind.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Polylines.CodeBehind" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Polyline Code Behind
    </h1>
    <p>
        GoogleMap control polyline code behind sample.
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Width="640px" Height="600px" Latitude="42.1229"
            Longitude="24.7879" Zoom="7" CssClass="map">
        </artem:GoogleMap>
    </div>
    <script type="text/javascript">
        function handleClick(sender, e) {
            if (console) console.dir(e);
            alert("GooglePolylien click event was fired!");
        }
    </script>
</asp:Content>
