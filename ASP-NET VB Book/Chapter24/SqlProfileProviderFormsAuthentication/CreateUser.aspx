<%@ Page Language="vb" AutoEventWireup="true" CodeFile="CreateUser.aspx.vb" Inherits="CreateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:Login ID="Login1" runat="server">
		</asp:Login>
		<br />
		&nbsp;<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" RequireEmail="False">
			<WizardSteps>
				<asp:CreateUserWizardStep runat="server">
					<ContentTemplate>
						<table border="0">
							<tr>
								<td align="center" colspan="2">
									Sign Up for Your New Account</td>
							</tr>
							<tr>
								<td align="right">
									<label for="UserName">
										User Name:</label></td>
								<td>
									<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
										ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td align="right">
									<label for="Password">
										Password:</label></td>
								<td>
									<asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
										ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td align="right">
									<label for="ConfirmPassword">
										Confirm Password:</label></td>
								<td>
									<asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
										ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
										ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td align="center" colspan="2">
									<asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
										ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
										ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
								</td>
							</tr>
							<tr>
								<td align="center" colspan="2" style="color: red">
									<asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
								</td>
							</tr>
						</table>
					</ContentTemplate>
				</asp:CreateUserWizardStep>
				<asp:CompleteWizardStep runat="server">
				</asp:CompleteWizardStep>
			</WizardSteps>
		</asp:CreateUserWizard>
	
	</div>
	</form>
</body>
</html>
