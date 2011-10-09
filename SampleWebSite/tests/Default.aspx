<%@ Page Language="C#" %>

<%@ Register Src="~/controls/TestControl.ascx" TagName="TestControl" TagPrefix="site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <site:TestControl ID="ctrTest" runat="server" />
    <h2>
        Support GoogleMap Control, Make A Donation
    </h2>
    <p>
        Please make a donation if you enjoy using the software and believe in the importance
        of what the GoogleMap Control project is working to accomplish.
    </p>
    <p>
        Here are offered two easy ways to make a donation to support the project:
    </p>
    <h3>
        Donate once
    </h3>
    <p>
        If you have a major credit card (Visa, MasterCard, American Express) or a PayPal
        account, donating is easy. Just click the button below to get started:<br />
        <br />
        <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
        <input type="hidden" name="cmd" value="_s-xclick">
        <input type="hidden" name="encrypted" value="-----BEGIN PKCS7-----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-----END PKCS7-----">
        <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif"
            border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
        <img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif"
            width="1" height="1">
        </form>
    </p>
    </form>
</body>
</html>
