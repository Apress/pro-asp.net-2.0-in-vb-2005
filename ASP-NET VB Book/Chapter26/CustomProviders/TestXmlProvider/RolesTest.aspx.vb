Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public partial Class RolesTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Private Sub WriteResults(ByVal Results As String())
		Dim Info As StringBuilder = New StringBuilder()
		For Each Result As String In Results
			Info.AppendFormat("{0}<br>", Result)
		Next Result
		ResultsLabel.Text = Info.ToString()
	End Sub

	Protected Sub DeleteRole_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Roles.DeleteRole(RoleNameText.Text) Then
			ResultsLabel.Text = "Role deleted successfully!"
		Else
			ResultsLabel.Text = "Unable to delete roles!"
		End If
	End Sub

	Protected Sub FindUsersInRole_Click(ByVal sender As Object, ByVal e As EventArgs)
		ResultsLabel.Text = ""
		WriteResults(Roles.FindUsersInRole(RoleNameText.Text, UserNameText.Text))
	End Sub

	Protected Sub GetAll_Click(ByVal sender As Object, ByVal e As EventArgs)
		WriteResults(Roles.GetAllRoles())
	End Sub

	Protected Sub GetRolesForUser_Click(ByVal sender As Object, ByVal e As EventArgs)
		WriteResults(Roles.GetRolesForUser(UserNameText.Text))
	End Sub

	Protected Sub GetUsersInRole_Click(ByVal sender As Object, ByVal e As EventArgs)
		WriteResults(Roles.GetUsersInRole(RoleNameText.Text))
	End Sub

	Protected Sub IsUserInRole_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Roles.IsUserInRole(UserNameText.Text, RoleNameText.Text) Then
			ResultsLabel.Text = "Yes"
		Else
			ResultsLabel.Text = "No"
		End If
	End Sub

	Protected Sub AddUserToRole_Click(ByVal sender As Object, ByVal e As EventArgs)
		Roles.AddUserToRole(UserNameText.Text, RoleNameText.Text)
	End Sub

	Protected Sub RemoveUserFromRole_Click(ByVal sender As Object, ByVal e As EventArgs)
		Roles.RemoveUserFromRole(UserNameText.Text, RoleNameText.Text)
	End Sub
End Class
