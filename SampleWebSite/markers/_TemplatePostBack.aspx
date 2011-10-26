<%@ Page Language="C#" MasterPageFile="~/GoogleMap.master" AutoEventWireup="false"
    CodeFile="_TemplatePostBack.aspx.cs" Inherits="marker_TemplatePostBack" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="main" runat="Server">
    <artem:GoogleMap ID="GoogleMap1" runat="server" Latitude="42.1229" Longitude="24.7879"
        EnableScrollWheelZoom="true" Zoom="6">
        <%--<Markers>
            <artem:GoogleMarker Address="plovdiv bulgaria"> IconAnchor="16,16" IconSize="32,32"
                IconUrl="/images/marker-manager/sun.png" ShadowSize="59,32" ShadowUrl="/images/marker-manager/sun-shadow.png">
                <InfoWindowTemplate>
                    <div>
                        <h3>
                            Template PostBack</h3>
                        <p>
                            This is a sample of control postback inside marker's InfoWindowTemplate.
                        </p>
                        <p>
                            <asp:TextBox ID="txtTimestamp" runat="server" Width="240px"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                        </p>
                    </div>
                </InfoWindowTemplate>
            </artem:GoogleMarker>
        </Markers>--%>
    </artem:GoogleMap>
</asp:Content>