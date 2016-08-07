<%@ Page Title="" Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="true" CodeFile="SearchBox.aspx.cs" Inherits="searchbox_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
     <h1>
        SearchBox
    </h1>
    <p>
        Adds a search box
    </p>
    <div class="map-wrap">
        <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879" Zoom="6" EnableSearchBoxControl="true" CssClass="map" SearchBoxControlOptions-Position="TopLeft" SearchBoxControlOptions-Style="margin-top: 6px" SearchBoxControlOptions-Text="Search places">
        </artem:GoogleMap>
    </div>
</asp:Content>


