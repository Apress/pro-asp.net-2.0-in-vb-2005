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
Imports System.Net
Imports localhost

Public partial Class WindowsAuthenticationSecurityTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdUnauthenticated_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim securedService As SecureService = New SecureService()
		Try
			lblInfo.Text = securedService.TestAuthenticated()
		Catch err As Exception
			lblInfo.Text = err.Message
		End Try

	End Sub
	Protected Sub cmdAuthenticated_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim securedService As SecureService = New SecureService()

		' Specity some user credentials for the web service.
		Dim credentials As NetworkCredential = New NetworkCredential(txtUserName.Text, txtPassword.Text)
		securedService.Credentials = credentials

		lblInfo.Text = securedService.TestAuthenticated()

	End Sub
End Class
