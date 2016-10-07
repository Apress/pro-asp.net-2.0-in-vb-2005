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

Public partial Class GridViewSort2 : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)

	End Sub


	Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		' Save selected index
		If GridView1.SelectedIndex <> -1 Then
			ViewState("SelectedValue") = GridView1.SelectedValue.ToString()
		End If

	End Sub
	Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
		' Clear selection.
		GridView1.SelectedIndex = -1


		If GridView1.SortExpression.StartsWith(e.SortExpression) Then
			' This sort is being applied to the same field for the second time.
			' Reverse it.
			If GridView1.SortDirection = SortDirection.Ascending Then
				'e.SortExpression += " DESC";
				e.SortDirection = SortDirection.Descending
			End If

		End If


	End Sub
	Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		Dim selectedValue As String = CType(ViewState("SelectedValue"), String)
		If selectedValue Is Nothing Then
			Return
		End If

		' Determine if the selected row is visible and re-select it
		For Each row As GridViewRow In GridView1.Rows
			Dim keyValue As String = GridView1.DataKeys(row.RowIndex).Value.ToString()
			If keyValue = selectedValue Then
				GridView1.SelectedIndex = row.RowIndex
			End If
		Next row

	End Sub
	Protected Sub lstSorts_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		GridView1.Sort(lstSorts.SelectedValue, SortDirection.Ascending)
	End Sub
End Class
