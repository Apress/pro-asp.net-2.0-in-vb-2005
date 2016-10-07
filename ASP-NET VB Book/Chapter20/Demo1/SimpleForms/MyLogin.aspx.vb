Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public partial Class login : Inherits System.Web.UI.Page
	Protected Sub LoginAction_Click(ByVal sender As Object, ByVal e As EventArgs)
		Page.Validate()
		If (Not Page.IsValid) Then
		Return
		End If

		If FormsAuthentication.Authenticate(UsernameText.Text, PasswordText.Text) Then
			' Create the ticket, add the cookie to the response
			' and redirect to the originally requested page
			FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, False)
		Else
			' Username and password are not correct
			LegendStatus.Text = "Invalid username or password!"
		End If
	End Sub
End Class
