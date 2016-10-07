Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public partial Class _CreateTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub AddRoleCommand_Click(ByVal sender As Object, ByVal e As EventArgs)
		Roles.CreateRole(RoleNameText.Text)
	End Sub

	Protected Sub CreateUserWizard1_ContinueButtonClick(ByVal sender As Object, ByVal e As EventArgs)
		Response.Redirect("CreateTest.aspx")
	End Sub
End Class