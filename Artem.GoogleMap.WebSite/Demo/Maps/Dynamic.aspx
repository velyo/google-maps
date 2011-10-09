<%@ Page Language="C#" MasterPageFile="~/demo/maps/Master.master" AutoEventWireup="false" Inherits="Artem.Google.Web.Demo.Maps.DynamicPage" Codebehind="Dynamic.aspx.cs" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="main" ID="mainContent" runat="server">
    <asp:PlaceHolder ID="phMap" runat="server"></asp:PlaceHolder>
</asp:Content>