﻿<%@ Page Language="C#" %>

<%@ Register Src="~/controls/TestControl.ascx" TagName="TestControl" TagPrefix="site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smTest" runat="server" />
    <site:TestControl ID="ctrTest" runat="server" />
    </form>
</body>
</html>
