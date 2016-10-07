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

Public partial Class VaryByControl : Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Select Case lstMode.SelectedIndex
			Case 0
				TimeMsg.Font.Size = FontUnit.Large
			Case 1
				TimeMsg.Font.Size = FontUnit.Small
			Case 2
				TimeMsg.Font.Size = FontUnit.Medium
		End Select
		TimeMsg.Text = DateTime.Now.ToString("F")
	End Sub
	Protected Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As EventArgs)


	End Sub
End Class
