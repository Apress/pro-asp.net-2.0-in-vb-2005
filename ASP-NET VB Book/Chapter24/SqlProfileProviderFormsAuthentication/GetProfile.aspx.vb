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

Public partial Class GetProfile : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdGet_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim profile As ProfileCommon = Profile.GetProfile(txtUserName.Text)
		lbl.Text = "This user lives in " & profile.Address.Country

	End Sub
End Class
