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
Imports System.Diagnostics

Public partial Class CreateUser : Inherits System.Web.UI.Page
	Protected Sub ActionAddUser_Click(ByVal sender As Object, ByVal e As EventArgs)
		Try
			Dim Status As MembershipCreateStatus

			Membership.CreateUser(UserNameText.Text, PasswordText.Text, UserEmailText.Text, PwdQuestionText.Text, PwdAnswerText.Text, True, Status)

			StatusLabel.Text = "User created successfully!"
		Catch ex As Exception
			Debug.WriteLine("Exception: " & ex.Message)
			StatusLabel.Text = "Unable to create user!"
		End Try
	End Sub
End Class
