<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="StreetView.aspx.cs" Inherits="map_StreetView" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>StreetView Mode</title>
    <meta name="description" content="GoogleMap Control StreetView mode sample." />
    <meta name="keywords" content="asp.net artem googlemap control street view" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        StreetView Mode
    </h1>
    <p>
        <fieldset>
            <legend>Control panel</legend>
            <p>
                <asp:CheckBox ID="chkStreetView" runat="server" AutoPostBack="true" Text="IsStreetView" />
                <asp:DropDownList ID="ddlStreetViewMode" runat="server" AutoPostBack="true">
                    <asp:ListItem Text="Panorama" Value="Panorama"></asp:ListItem>
                    <asp:ListItem Text="Overlay" Value="Overlay"></asp:ListItem>
                </asp:DropDownList>
                <asp:CheckBox ID="chkExternal" runat="server" AutoPostBack="true" Text="Use External Panorama container" />
            </p>
            <p>
                <asp:Literal ID="ltrInfo" runat="server">Click on the map to see the desired street view!</asp:Literal>
            </p>
        </fieldset>
    </p>
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.345573" Longitude="-71.098326"
        Zoom="14">
    </artem:GoogleMap>
    <p>
        Lorem ipsum dolor sit amet, maecenas fusce ornare phasellus semper, ac imperdiet
        sodales. Mi cursus, odio consectetuer proin auctor pulvinar posuere, massa ea id,
        maecenas tempor. Nibh ipsum mauris quam. Velit duis, in orci fames nulla, erat vitae
        etiam, magna commodo, ipsum sed fringilla in wisi nonummy. Nam amet non rutrum,
        nibh ac magna tempor urna, amet mollis pulvinar aliquet, fusce pretium. Per interdum
        suspendisse felis morbi pulvinar nisl, tellus sit vel dis libero proin etiam. Dapibus
        et euismod nulla leo viverra. Et nulla pellentesque augue integer, libero ante gravida
        eget, elit cras aliquet, nullam non. Cras felis, libero libero ullamcorper nunc,
        feugiat blandit tristique, lacus quis sed ut quam suscipit, et malesuada magna orci
        aliquam commodo maecenas. Ornare metus volutpat metus suspendisse faucibus, leo
        in velit nam montes, blandit vitae nulla tempor, sem nulla potenti praesent, libero
        a dis sociis quis quisque arcu.
    </p>
    <div id="pano" style="width: 500px; height: 200px">
    </div>
    <p>
        This is an example of GoogleMap Control StreetView functionality. It demonstrates
        the different modes of the StreetView supported by GoogleMap Control.
        <ol>
            <li>Panorama mode - IsStreetView is just set to <b>true</b> and the street view is shwon
                instead of the GoogleMap in same element container.</li>
            <li>Overlay mode
                <ol>
                    <li>Without StreetViewPanoID set</li>
                    <li>With StreetViewPanoID set</li>
                </ol>
            </li>
        </ol>
    </p>
    <ul class="props">
        <li><b>IsStreetView</b> - switches on/off the StreetView of GoogleMap Control</li>
        <li><b>StreetViewMode</b> - switches between the <b>Panorama</b> and <b>Overlay</b>
            modes.</li>
        <li><b>StreetViewPanoID</b> - provides an external DOM element as container for the
            street view panorama</li>
    </ul>
</asp:Content>
