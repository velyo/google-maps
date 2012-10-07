<%@ Page Language="C#" MasterPageFile="~/map/Map.master" AutoEventWireup="false"
    CodeFile="InTabPanel.aspx.cs" Inherits="Artem.GoogleMap.WebSite.Maps.InTabPanel" %>

<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
    <title>GoogleMap - Inside TabPanel</title>
    <meta name="description" content="GoogleMap control inside ajax tab panel sample." />
    <meta name="keywords" content="googlemap control inside ajax tab panel sample" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <h1>
        Map Inside TabPanel
    </h1>
    <p>
        GoogleMap control inside ajax tab panel sample.
    </p>
    <%--<ajax:TabContainer ID="tabContainer" runat="server" OnClientActiveTabChanged="refreshMap">
        <ajax:TabPanel ID="tabLorem" runat="server" HeaderText="Text">
            <ContentTemplate>
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
                <p>
                    Eget sapien pellentesque, praesent volutpat sed, tortor rutrum vestibulum at sit
                    quis, sit pharetra mauris, ut wisi eu dolor consectetuer. Eros nisl donec nulla,
                    orci in et, laoreet dolor curabitur nibh mollis. Donec sit, etiam leo mauris turpis
                    eleifend sed. Non morbi venenatis, sit curabitur a lacus, pellentesque vitae diam
                    sed magna, turpis aenean orci, laoreet dolor dolor laoreet mi vestibulum. Porta
                    adipiscing in arcu curabitur, magnis interdum nulla urna risus ipsum.
                </p>
                <p>
                    Justo erat fusce nunc diam. Pellentesque nisl ut nonummy sollicitudin, a dolor.
                    Porta convallis, vitae eu pellentesque commodo ultricies, consequat totam, eu urna
                    mi sed sodales phasellus tincidunt, vestibulum iaculis ipsum duis ullamcorper suscipit.
                    Vivamus dignissim pellentesque. A vitae donec, erat cras eu, ac morbi dis nulla
                    ultrices, aliquam libero vehicula vitae. Facilisi condimentum aliquam, interdum
                    felis feugiat lacinia quisque. In ac et et nulla. Nec velit elit. Et penatibus ac
                    integer leo bibendum amet, pede wisi et, curabitur adipiscing nunc porta nec. A
                    ante enim. Suscipit per aliquam velit tincidunt, non vestibulum turpis fermentum
                    pede, neque ut, varius a.
                </p>
                <p>
                    Sed dolor enim arcu vitae auctor suspendisse, ac hendrerit mattis, leo tortor tempus
                    in, eros et dui purus. Amet imperdiet vel, duis eros convallis dolor ligula nisl
                    nam, urna convallis commodo ultricies, curabitur elit quam lectus id, sit amet.
                    Molestie sapien, quam ultricies mauris justo et, suspendisse quam erat purus lacus
                    amet ut, viverra sit. Etiam pretium, turpis ligula donec sociis et, donec lectus
                    velit amet lectus, vivamus nunc cursus in quis mauris. Ultricies libero wisi nec
                    non lectus, elit eu, est duis vestibulum pede, duis ullamcorper aenean vitae non.
                    Donec turpis. Quam a. Risus ac tristique dui eget et tristique, cursus consectetuer
                    natoque dolor, urna quam dictum lorem pretium, velit quis luctus aliquam vitae in,
                    libero id. Ullamcorper vehicula taciti auctor libero, id sem ac pharetra duis lacus
                    cras, sit suscipit maecenas deleniti mauris felis sollicitudin, lacinia auctor feugiat
                    amet in, metus aliquet egestas eu cursus. Aptent rhoncus orci placerat feugiat,
                    cras lobortis purus, eu erat magna velit quia eu quis, tempus turpis quis.
                </p>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel ID="tabMap" runat="server" HeaderText="Map">
            <ContentTemplate>
                <div style="position: relative">
                    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="616px" Height="600px" Latitude="42.1229"
                        Longitude="24.7879" Zoom="5" ShowScaleControl="true" EnableMarkerManager="true"
                        ZoomPanType="Large" SkinID="InTab">
                    </artem:GoogleMap>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel ID="tabStreetView" runat="server" HeaderText="StreetView">
            <ContentTemplate>
                <div style="position: relative">
                    <artem:GoogleMap ID="GoogleMap2" runat="server" Latitude="42.345573" Longitude="-71.098326"
                        Zoom="14" EnableScrollWheelZoom="true" IsStreetView="true" SkinID="InTab">
                        <Markers>
                            <artem:GoogleMarker Latitude="42.1229" Longitude="24.7879" Title="Click on the marker"
                                Text="<h1>Test</h1>" Draggable="true">
                            </artem:GoogleMarker>
                        </Markers>
                    </artem:GoogleMap>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
    </ajax:TabContainer>--%>

    <%--<script type="text/javascript">
        function refreshMap() {
            GoogleMap1.checkResize();
        }
    </script>
    Source Code:
    <pre>&lt;ajax:TabContainer ID="tabContainer1" runat="server" Width="640px" Height="600px" OnClientActiveTabChanged="refreshMap"&gt;
        &lt;ajax:TabPanel ID="TabPanel1" runat="server" HeaderText="Text"&gt;
            &lt;ContentTemplate&gt;
                Some text ...
            &lt;/ContentTemplate&gt;
        &lt;/ajax:TabPanel&gt;
        &lt;ajax:TabPanel ID="TabPanel2" runat="server" HeaderText="Map" Width="640px" Height="600px"&gt;
            &lt;ContentTemplate&gt;
                &lt;div style="position: relative"&gt;
                    &lt;artem:GoogleMap ID="GoogleMap2" runat="server" Width="616px" Height="600px" Latitude="42.1229"
                        Longitude="24.7879" Zoom="5" ShowScaleControl="true" EnableMarkerManager="true"
                        ZoomPanType="Large" BorderStyle="Solid" BorderColor="#999999" BorderWidth="3"&gt;
                    &lt;/artem:GoogleMap&gt;
                &lt;/div&gt;
            &lt;/ContentTemplate&gt;
        &lt;/ajax:TabPanel&gt;
    &lt;/ajax:TabContainer&gt;
    &lt;script type="text/javascript"&gt;
        function refreshMap() {
            var map = &lt;%= GoogleMap1.ClientID %&gt;;
            map.checkResize();
        }
    &lt;/script></pre>--%>
</asp:Content>
