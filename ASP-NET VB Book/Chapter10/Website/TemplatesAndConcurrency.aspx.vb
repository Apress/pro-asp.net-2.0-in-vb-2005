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

Public partial Class TemplatesAndConcurrency : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub DetailsView1_ItemUpdated(ByVal sender As Object, ByVal e As DetailsViewUpdatedEventArgs)
		If e.AffectedRows = 0 Then
			'lblStatus.Text = "No records were updated.";
			e.KeepInEditMode = True

			' Allow more editing.
			detailsEditing.DataBind()

			' Re-populate DetailsView with values entered by user
			Dim t As TextBox
			t = CType(detailsEditing.Rows(1).Cells(1).Controls(0), TextBox)
			t.Text = CStr(e.NewValues("CompanyName"))
			t = CType(detailsEditing.Rows(2).Cells(1).Controls(0), TextBox)
			t.Text = CStr(e.NewValues("Phone"))

			' Show the panel with errors.
			ErrorPanel.Visible = True
		End If
	End Sub


	Protected Sub SqlDataSource2_Selecting(ByVal sender As Object, ByVal e As SqlDataSourceSelectingEventArgs)
		If (Not ErrorPanel.Visible) Then
		e.Cancel = True
		End If
	End Sub
End Class
