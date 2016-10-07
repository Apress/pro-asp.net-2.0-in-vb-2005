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

Public partial Class _Default : Inherits System.Web.UI.Page
	Private _MyUsers As MembershipUserCollection

	Public ReadOnly Property SelectedUser() As MembershipUser
		Get
			Return Nothing
		End Get
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		_MyUsers = Membership.GetAllUsers()
		UsersGridView.DataSource = _MyUsers

		If (Not Me.IsPostBack) Then
			UsersGridView.DataBind()
		End If
	End Sub

	Protected Sub UsersGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		If UsersGridView.SelectedIndex >= 0 Then
			Dim Current As MembershipUser = _MyUsers(CStr(UsersGridView.SelectedValue))

			UsernameLabel.Text = Current.UserName
			PwdQuestionLabel.Text = Current.PasswordQuestion
			LastLoginLabel.Text = Current.LastLoginDate.ToShortDateString()
			EmailText.Text = Current.Email
			CommentText.Text = Current.Comment
			IsApprovedCheck.Checked = Current.IsApproved
			IsLockedOutCheck.Checked = Current.IsLockedOut
		End If
	End Sub

	Protected Sub ActionUpdateUser_Click(ByVal sender As Object, ByVal e As EventArgs)
		If UsersGridView.SelectedIndex >= 0 Then
			Dim Current As MembershipUser = _MyUsers(CStr(UsersGridView.SelectedValue))

			Current.Email = EmailText.Text
			Current.Comment = CommentText.Text
			Current.IsApproved = IsApprovedCheck.Checked

			Membership.UpdateUser(Current)

			' Refresh the grids view
			UsersGridView.DataBind()
		End If
	End Sub
End Class