Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

''' <summary>
''' Summary description for DatabaseCredentialStore
''' </summary>

Namespace CredentialStoreNamespace
	Public Class DatabaseCredentialStore : Implements ICredentialStore
		Private conn As SqlConnection

		Public Sub New()
			conn = New SqlConnection()
			conn.ConnectionString = WebConfigurationManager.ConnectionStrings("MyLoginDb").ConnectionString
		End Sub

		Public Function Authenticate(ByVal userName As String, ByVal userPassword As String, <System.Runtime.InteropServices.Out()> ByRef userData As String) As Boolean Implements ICredentialStore.Authenticate
			userData = String.Empty

			conn.Open()
			Try
				Dim cmd As SqlCommand = New SqlCommand()
				cmd.Connection = conn
				cmd.CommandText = "SELECT UserEmail From MyUsers " & "WHERE UserName=@usr AND UserPassword=@pwd"
				cmd.Parameters.AddWithValue("@usr", userName)
				cmd.Parameters.AddWithValue("@pwd", FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1"))

				userData = CStr(cmd.ExecuteScalar())
				If Not userData Is Nothing Then
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

		Public Sub CreateUser(ByVal userName As String, ByVal userPassword As String, ByVal userData As String) Implements ICredentialStore.CreateUser
			conn.Open()
			Try
				Dim cmd As SqlCommand = New SqlCommand()
				cmd.Connection = conn
				cmd.CommandText = "INSERT INTO MyUsers VALUES(@usr, @pwd, @email)"
				cmd.Parameters.AddWithValue("@usr", userName)
				cmd.Parameters.AddWithValue("@pwd", FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1"))
				cmd.Parameters.AddWithValue("@email", userData)
				cmd.ExecuteNonQuery()
			Catch ex As Exception
				' Log the error but don't 
				' display any details to the user
				System.Diagnostics.Debug.WriteLine("Exception: " & ex.Message)
			Finally
				conn.Close()
			End Try
		End Sub
	End Class
End Namespace