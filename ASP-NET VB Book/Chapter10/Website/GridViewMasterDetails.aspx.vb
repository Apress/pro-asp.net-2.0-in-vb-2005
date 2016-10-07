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

Public partial Class GridViewMasterDetails : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)

	End Sub


	Protected Sub gridEmployees_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim index As Integer = gridEmployees.SelectedIndex

		' You can retrieve the key field from the SelectedDataKey property.
		Dim ID As Integer = CInt(gridEmployees.SelectedDataKey.Values("EmployeeID"))

		' You can retrieve other data directly from the Cells collection,
		' as long as you know the column offset.
		Dim firstName As String = gridEmployees.SelectedRow.Cells(2).Text
		Dim lastName As String = gridEmployees.SelectedRow.Cells(3).Text

		lblRegionCaption.Text = "Regions that " & firstName & " " & lastName & " (employee " & ID.ToString() & ") is responsible for:"
	End Sub
End Class
