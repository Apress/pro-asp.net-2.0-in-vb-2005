<%@ Page Language="vb" AutoEventWireup="true" CodeFile="CacheFileDependency.aspx.vb" Inherits="CacheFileDependency" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="Form1" method="post" runat="server">
			<asp:button id="cmdModify" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server" Text="Modify File" Width="103px" Height="24px" OnClick="cmdModfiy_Click"></asp:button><asp:button id="cmdGetItem" style="Z-INDEX: 103; LEFT: 136px; POSITION: absolute; TOP: 16px" runat="server" Text="Check for Item" Width="103px" Height="24px" OnClick="cmdGetItem_Click"></asp:button><asp:label id="lblInfo" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 72px" runat="server" Width="480px" Height="192px" BorderWidth="2px" BorderStyle="Groove" Font-Names="Verdana" Font-Size="X-Small" BackColor="LightYellow"></asp:label></form>
</body>
</html>
