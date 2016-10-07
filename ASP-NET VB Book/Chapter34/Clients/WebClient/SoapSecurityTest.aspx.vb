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
Imports localhost

Public partial Class SoapSecurityTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdCall_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim proxy As SoapSecurityService = New SoapSecurityService()

		Try
			proxy.Login(txtUserName.Text, txtPassword.Text)
			GridView1.DataSource = proxy.GetEmployees()
			GridView1.DataBind()
		Catch err As Exception
			lblInfo.Text = err.Message
		End Try

	End Sub
	Protected Sub cmdCreate_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim proxy As SoapSecurityService = New SoapSecurityService()
		Try
			proxy.CreateTestUser(txtUserName.Text, txtPassword.Text)
			lblInfo.Text = "Successfully added this user as an administrator."
		Catch err As Exception
			lblInfo.Text = err.Message
		End Try
	End Sub
End Class
