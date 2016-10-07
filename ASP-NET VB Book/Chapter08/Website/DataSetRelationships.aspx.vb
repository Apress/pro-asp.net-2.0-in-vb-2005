Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Data.SqlClient

Public partial Class DataSetRelationships : Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the Connection, DataAdapter, and DataSet.
		Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" & "Integrated Security=SSPI"
		Dim con As SqlConnection = New SqlConnection(connectionString)

		Dim sqlCat As String = "SELECT CategoryID, CategoryName FROM Categories"
		Dim sqlProd As String = "SELECT ProductName, CategoryID FROM Products"

		Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCat, con)
		Dim ds As DataSet = New DataSet()

		Try
			con.Open()

			' Fill the DataSet with the Categories table.
			da.Fill(ds, "Categories")

			' Change the command text and retrieve the Products table.
			' You could also use another DataAdapter object for this task.
			da.SelectCommand.CommandText = sqlProd
			da.Fill(ds, "Products")
		Finally
			con.Close()
		End Try

		' Define the relationship between Categories and Products.
		Dim relat As DataRelation = New DataRelation("CatProds", ds.Tables("Categories").Columns("CategoryID"), ds.Tables("Products").Columns("CategoryID"))
		' Add the relationship to the DataSet.
		ds.Relations.Add(relat)

		' Loop through the category records and build the HTML string.
		Dim htmlStr As StringBuilder = New StringBuilder("")
		For Each row As DataRow In ds.Tables("Categories").Rows
			htmlStr.Append("<b>")
			htmlStr.Append(row("CategoryName").ToString())
			htmlStr.Append("</b><ul>")

			' Get the children (products) for this parent (category).
			Dim childRows As DataRow() = row.GetChildRows(relat)
			' Loop through all the products in this category.
			For Each childRow As DataRow In childRows
				htmlStr.Append("<li>")
				htmlStr.Append(childRow("ProductName").ToString())
				htmlStr.Append("</li>")
			Next childRow
			htmlStr.Append("</ul>")
		Next row

		' Show the generated HTML code.
		HtmlContent.Text = htmlStr.ToString()
	End Sub

End Class