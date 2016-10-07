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
Imports System.Text

Public partial Class _Default : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not User Is Nothing) AndAlso (User.Identity.IsAuthenticated) Then
			Dim rp As RolePrincipal = CType(User, RolePrincipal)

			Dim Info As StringBuilder = New StringBuilder()
			Info.AppendFormat("<h2>Welcome {0}!</h2>", User.Identity.Name)
			Info.AppendFormat("<b>Provider: </b>{0}<br>", rp.ProviderName)
			Info.AppendFormat("<b>Version: </b>{0}<br>", rp.Version)
			Info.AppendFormat("<b>Expiration: </b>{0}<br>", rp.ExpireDate)
			Info.AppendFormat("<b>Roles: </b><br>")

			Dim Roles As String() = rp.GetRoles()
			For Each role As String In Roles
				If (Not role.Equals(String.Empty)) Then
					Info.AppendFormat("-) {0}<br>", role)
				End If
			Next role

			LabelPrincipalInfo.Text = Info.ToString()
		End If
	End Sub
End Class