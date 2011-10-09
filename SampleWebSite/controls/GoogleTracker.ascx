<%@ Control Language="C#" AutoEventWireup="false" CodeFile="GoogleTracker.ascx.cs" Inherits="controls_GoogleTracker" %>
<%@ OutputCache Duration="1800" VaryByParam="none" %>
<%-- >> Google Analytics --%>
<script type="text/javascript">
    var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
    document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<%-- << Google Analytics --%>
<%-- >> Google Tracker --%>
<script type="text/javascript">
    var pageTracker = _gat._getTracker("UA-1361428-5");
    pageTracker._initData();
    pageTracker._trackPageview();
</script>
<%-- << Google Tracker --%>
