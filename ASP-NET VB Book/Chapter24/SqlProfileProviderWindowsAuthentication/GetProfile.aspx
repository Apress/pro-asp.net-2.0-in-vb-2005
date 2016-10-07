<%@ Page Language="vb" AutoEventWireup="true" CodeFile="GetProfile.aspx.vb" Inherits="GetProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
	<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	<div>
		User Name: &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
		<asp:Button ID="cmdGet" runat="server" OnClick="cmdGet_Click" Text="Get Profile" /><br />
		<br />
		<asp:Label ID="lbl" runat="server" Text=""></asp:Label>
	</div>
	</form>
</body>
</html>
