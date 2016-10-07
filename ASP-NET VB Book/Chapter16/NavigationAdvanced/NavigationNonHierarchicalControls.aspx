<%@ Page Language="vb" AutoEventWireup="true" CodeFile="NavigationNonHierarchicalControls.aspx.vb" Inherits="NavigationNonHierarchicalControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:DropDownList ID="lstParent" runat="server" DataTextField="Title"
			Width="165px" AutoPostBack="True" DataValueField="Url" OnSelectedIndexChanged="Nav_SelectedIndexChanged">
		</asp:DropDownList>
		<br />
		<asp:ListBox ID="lstChild" runat="server" Width="164px" AutoPostBack="True" DataTextField="Title" DataValueField="Url" OnSelectedIndexChanged="Nav_SelectedIndexChanged"></asp:ListBox><br />
		&nbsp;
	
	</div>
	</form>
</body>
</html>
