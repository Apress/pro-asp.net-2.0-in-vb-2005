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
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If User.Identity.IsAuthenticated Then
		End If
	End Sub
	Protected Sub LoginViewCtrl_ViewChanged(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
End Class