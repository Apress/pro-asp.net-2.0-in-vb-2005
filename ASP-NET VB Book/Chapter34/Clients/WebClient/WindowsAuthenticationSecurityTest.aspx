<%@ Page Language="vb" AutoEventWireup="true" CodeFile="WindowsAuthenticationSecurityTest.aspx.vb" Inherits="WindowsAuthenticationSecurityTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
				<asp:label id="lblInfo" style="Z-INDEX: 100; LEFT: 22px; POSITION: absolute; TOP: 165px" runat="server"
				Font-Size="Large" Font-Bold="True" Font-Names="Verdana" Height="117px" Width="552px"></asp:label><asp:label id="Label2" style="Z-INDEX: 107; LEFT: 21px; POSITION: absolute; TOP: 51px" runat="server">Password:</asp:label><asp:label id="Label1" style="Z-INDEX: 106; LEFT: 20px; POSITION: absolute; TOP: 18px" runat="server">User Name:</asp:label>
			<asp:TextBox id="txtPassword" style="Z-INDEX: 104; LEFT: 108px; POSITION: absolute; TOP: 48px"
				runat="server" Width="155px" TextMode="Password"></asp:TextBox>
			<asp:TextBox id="txtUserName" style="Z-INDEX: 103; LEFT: 108px; POSITION: absolute; TOP: 18px"
				runat="server"></asp:TextBox>
			<asp:Button id="cmdAuthenticated" style="Z-INDEX: 102; LEFT: 195px; POSITION: absolute; TOP: 99px"
				runat="server" Width="160px" Text="Authenticated Call" OnClick="cmdAuthenticated_Click"></asp:Button>
			<asp:Button id="cmdUnauthenticated" style="Z-INDEX: 101; LEFT: 22px; POSITION: absolute; TOP: 99px"
				runat="server" Width="160px" Text="Unauthenticated Call" OnClick="cmdUnauthenticated_Click"></asp:Button>
	</div>
	</form>
</body>
</html>
