<%@ Page Language="C#" MasterPageFile="GoogleMap.master" AutoEventWireup="false"
    CodeFile="Geocoding.aspx.cs" Inherits="page_Geocoding" %>

<asp:Content ContentPlaceHolderID="phHead" ID="cntHead" runat="server">
    <title>GoogleMap Geocoding</title>
    <meta name="description" content="GoogleMap Control - geocoding samples." />
    <meta name="keywords" content="asp.net artem googlemap control geocoding" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" runat="Server">
    <h1>
        Geocoding Sample
    </h1>
    <hr style="visibility: hidden;" />
    <asp:UpdatePanel runat="server" ID="upTest">
        <ContentTemplate>
            Address
            <asp:TextBox ID="_txtAddress" runat="server"></asp:TextBox>
            <asp:Button ID="_btnShow" runat="server" Text="Show" />
            <artem:GoogleMap ID="GoogleMap1" runat="server" Width="800px" Height="560px" Latitude="42.1229"
                Longitude="24.7879" Zoom="4">
            </artem:GoogleMap>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
