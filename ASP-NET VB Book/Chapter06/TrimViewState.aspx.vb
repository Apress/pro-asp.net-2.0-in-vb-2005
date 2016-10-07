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

Public partial Class TrimViewState : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		For i As Integer = 0 To 999
			lstBig.Items.Add(i.ToString())
		Next i

		If Page.IsPostBack Then
			lstBig.SelectedItem.Text = Request.Form("lstBig")
		End If
	End Sub
	Protected Sub cmdSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
		lblInfo.Text += lstBig.SelectedItem.Text & "<br />"
		'lblInfo.Text = Request.Form["lstBig"];
	End Sub

End Class