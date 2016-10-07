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

Public partial Class login2 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			ViewState("LoginErrors") = 0
		End If
	End Sub

	Protected Sub LoginCtrl_LoginError(ByVal sender As Object, ByVal e As EventArgs)
		' Increase the number of invalid logins
		Dim ErrorCount As Integer = CInt(ViewState("LoginErrors")) + 1
		ViewState("LoginErrors") = ErrorCount

		' Now validate the number of errors
		If (ErrorCount > 3) AndAlso (LoginCtrl.PasswordRecoveryUrl <> String.Empty) Then
			Response.Redirect(LoginCtrl.PasswordRecoveryUrl)
		End If
	End Sub

	Protected Sub LoginCtrl_Authenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)
		If Membership.ValidateUser(LoginCtrl.UserName, LoginCtrl.Password) Then
			e.Authenticated = True
		Else
			e.Authenticated = False
		End If
	End Sub

	Protected Sub OtherLoginCtrl_Authenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)
		Dim AccessKeyText As TextBox = CType(OtherLoginCtrl.FindControl("AccessKey"), TextBox)

		If Membership.ValidateUser(AccessKeyText.Text, OtherLoginCtrl.UserName) Then
			e.Authenticated = True
		Else
			e.Authenticated = False
		End If
	End Sub
End Class
