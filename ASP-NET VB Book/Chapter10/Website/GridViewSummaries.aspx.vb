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

Public partial Class GridViewSummaries : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub


	Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		Dim valueInStock As Decimal = 0


		' The Rows collection only includes rows on the current page
		' (not "virtual" rows).
		For Each row As GridViewRow In GridView1.Rows
			Dim price As Decimal = Decimal.Parse(row.Cells(2).Text.Substring(1))
			Dim unitsInStock As Integer = Int32.Parse(row.Cells(3).Text)
			valueInStock += price * unitsInStock
		Next row

		Dim footer As GridViewRow = GridView1.FooterRow

		' Set the first cell to span over the entire row.
		footer.Cells(0).ColumnSpan = 3
		footer.Cells(0).HorizontalAlign = HorizontalAlign.Center

		' Remove the unneeded cells.
		footer.Cells.RemoveAt(2)
		footer.Cells.RemoveAt(1)

		' Add the text.
		footer.Cells(0).Text = "Total value in stock (on this page): " & valueInStock.ToString("C")

	End Sub
	Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

	End Sub
	Protected Sub GridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)


	End Sub
End Class
