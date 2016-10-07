<%@ Page Language="vb" AutoEventWireup="true" CodeFile="ChangePasswordTemplate.aspx.vb" Inherits="ChangePasswordTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body style="text-align: center">
	<form id="form1" runat="server">
	<div>
		<asp:ChangePassword ID="ChangePassword1" runat="server">
			<ChangePasswordTemplate>
				Old Password:&nbsp;
				<asp:TextBox ID="CurrentPassword" runat="server" 
							 TextMode="Password" /><br />
				New Password:&nbsp;
				<asp:TextBox ID="NewPassword" runat="server" 
							 TextMode="Password" /><br />
				Confirmation:&nbsp;
				<asp:TextBox ID="ConfirmNewPassword" runat="server" 
							 TextMode="Password" /><br />                
				<asp:Button ID="ChangePasswordPushButton" CommandName="ChangePassword"
							runat="server" Text="Change Password" />
				<asp:Button ID="CancelPushButton" CommandName="Cancel"
							runat="server" Text="Cancel" /><br />
				<asp:Literal ID="FailureText" runat="server" 
							 EnableViewState="False" />
			</ChangePasswordTemplate>
			<SuccessTemplate>
				Your password has been changed!</td>
				<asp:Button ID="ContinuePushButton" runat="server" 
							CausesValidation="False" CommandName="Continue"
							Text="Continue" />
			</SuccessTemplate>
		</asp:ChangePassword>
	
	</div>
	</form>
</body>
</html>
