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

Public partial Class FocusAndDefault : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
		Label1.Text = "Clicked Submit."
	End Sub
	Protected Sub cmdSetFocus1_Click(ByVal sender As Object, ByVal e As EventArgs)
		TextBox1.Focus()
	End Sub
	Protected Sub cmdSetFocus2_Click(ByVal sender As Object, ByVal e As EventArgs)
		TextBox2.Focus()
	End Sub
End Class
