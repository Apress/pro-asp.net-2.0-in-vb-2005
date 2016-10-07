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

Public partial Class LoginPersist : Inherits System.Web.UI.Page
	Protected Sub LoginAction_Click(ByVal sender As Object, ByVal e As EventArgs)
		Page.Validate()
		If (Not Page.IsValid) Then
		Return
		End If

		If FormsAuthentication.Authenticate(UsernameText.Text, PasswordText.Text) Then
			' Create the authentication cookie
			Dim AuthCookie As HttpCookie
			AuthCookie = FormsAuthentication.GetAuthCookie(UsernameText.Text, True)
			AuthCookie.Expires = DateTime.Now.AddMinutes(5)

			' Add the cookie to the response
			Response.Cookies.Add(AuthCookie)

			' Redirect to the originally requested page
			Response.Redirect(FormsAuthentication.GetRedirectUrl(UsernameText.Text, True))
		Else
			' Username and password are not correct
			LegendStatus.Text = "Invalid username or password!"
		End If
	End Sub
End Class
