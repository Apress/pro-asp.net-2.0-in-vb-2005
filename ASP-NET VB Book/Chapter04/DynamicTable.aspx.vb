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

Public partial Class DynamicTable : Inherits System.Web.UI.Page
	   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create a new HtmlTable object.
		Dim table1 As HtmlTable = New HtmlTable()

		' Set the table's formatting-related properties.
		table1.Border = 1
		table1.CellPadding = 3
		table1.CellSpacing = 3
		table1.BorderColor = "red"

		' Start adding content to the table.
		Dim row As HtmlTableRow
		Dim cell As HtmlTableCell
		For i As Integer = 1 To 5
			' Create a new row and set its background color.
			row = New HtmlTableRow()
			If i Mod 2 = 0 Then
				row.BgColor = ("lightyellow")
			Else
				row.BgColor = ("lightcyan")
			End If

			For j As Integer = 1 To 4
				' Create a cell and set its text.
				cell = New HtmlTableCell()
				cell.InnerHtml = "Row: " & i.ToString() & "<br>Cell: " & j.ToString()

				' Add the cell to the current row.
				row.Cells.Add(cell)
			Next j

			' Add the row to the table.
			table1.Rows.Add(row)
		Next i

		' Add the table to the page.
		Me.Controls.Add(table1)
	   End Sub

End Class
