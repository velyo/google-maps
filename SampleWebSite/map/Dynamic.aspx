<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="true"
    CodeFile="Dynamic.aspx.cs" Inherits="map_Dynamic" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <asp:PlaceHolder ID="phMap" runat="server"></asp:PlaceHolder>
</asp:Content>