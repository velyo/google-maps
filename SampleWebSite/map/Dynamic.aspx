<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="true"
    CodeFile="Dynamic.aspx.cs" Inherits="map_Dynamic" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" runat="Server">
    <asp:PlaceHolder ID="phMap" runat="server"></asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phDescription" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phProperties" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="phActions" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="phIssues" runat="Server">
</asp:Content>