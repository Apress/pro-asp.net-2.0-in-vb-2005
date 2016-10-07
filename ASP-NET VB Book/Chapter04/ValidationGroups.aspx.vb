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

Public partial Class ValidationGroups : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdValidateAll_Click(ByVal sender As Object, ByVal e As EventArgs)
		Label1.Text = "Valid: " & Page.IsValid.ToString()
		Page.Validate("Group1")
		Label1.Text &= "<br />Group1 Valid: " & Page.IsValid.ToString()
		Page.Validate("Group2")
		Label1.Text &= "<br />Group2 Valid: " & Page.IsValid.ToString()
	End Sub
End Class
