Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public partial Class DbLogin : Inherits System.Web.UI.Page
	Private Function MyAuthenticate(ByVal username As String, ByVal userPassword As String) As Boolean
		Dim conn As SqlConnection = New SqlConnection()
		conn.ConnectionString = WebConfigurationManager.ConnectionStrings("MyLoginDb").ConnectionString

		conn.Open()
		Try
			Dim cmd As SqlCommand = New SqlCommand()
			cmd.Connection = conn
			cmd.CommandText = "SELECT UserName From MyUsers " & "WHERE UserName=@usr AND UserPassword=@pwd"
			cmd.Parameters.AddWithValue("@usr", username)
			cmd.Parameters.AddWithValue("@pwd", userPassword)

			Dim RetUser As String = CStr(cmd.ExecuteScalar())
			If Not RetUser Is Nothing Then
				Return True
			Else
				Return False
			End If
		Catch ex As Exception
			' Log the error but don't 
			' display any details to the user
			System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
			' Login failed
			Return False
		Finally
			conn.Close()
		End Try
	End Function

	Protected Sub LoginAction_Click(ByVal sender As Object, ByVal e As EventArgs)
		Page.Validate()
		If (Not Page.IsValid) Then
		Return
		End If

		If Me.MyAuthenticate(UsernameText.Text, PasswordText.Text) Then
			FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, False)
		Else
			LegendStatus.Text = "Invalid username or password!"
		End If
	End Sub
End Class
