Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public partial Class _Default : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If User.Identity.IsAuthenticated Then
			Dim rp As RolePrincipal = CType(User, RolePrincipal)

			Dim RoleInfo As StringBuilder = New StringBuilder()
			RoleInfo.AppendFormat("<h2>Welcome {0}</h2>", rp.Identity.Name)
			RoleInfo.AppendFormat("<b>Provider:</b> {0}<BR>", rp.ProviderName)
			RoleInfo.AppendFormat("<b>Version:</b> {0}<BR>", rp.Version)
			RoleInfo.AppendFormat("<b>Expires at:</b> {0}<BR>", rp.ExpireDate)
			RoleInfo.Append("<b>Roles:</b> ")

			Dim roles As String() = rp.GetRoles()
			Dim i As Integer = 0
'ORIGINAL LINE: for (int i = 0; i < roles.Length; i += 1)
            Do While i < roles.Length
                If i > 0 Then
                    RoleInfo.Append(", ")
                End If
                RoleInfo.Append(roles(i))
                i += 1
            Loop

            LabelRoleInformation.Text = RoleInfo.ToString()
        End If
	End Sub
End Class