Imports Microsoft.VisualBasic
Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public partial Class MenuDb : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			Dim ds As DataSet = GetProductsAndCategories()

			' Loop through the category records.
			For Each row As DataRow In ds.Tables("Categories").Rows
				' Use the constructor that requires just text
				' and a non-displayed value.
				Dim itemCategory As MenuItem = New MenuItem(row("CategoryName").ToString(), row("CategoryID").ToString())

				Menu1.Items.Add(itemCategory)

				' Get the children (products) for this parent (category).
				Dim childRows As DataRow() = row.GetChildRows(ds.Relations(0))

				' Loop through all the products in this category.
				For Each childRow As DataRow In childRows
					Dim itemProduct As MenuItem = New MenuItem(childRow("ProductName").ToString(), childRow("ProductID").ToString())
					itemCategory.ChildItems.Add(itemProduct)

				Next childRow
			Next row
		End If
	End Sub

	Private Function GetProductsAndCategories() As DataSet
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
		Dim con As SqlConnection = New SqlConnection(connectionString)

		Dim sqlCat As String = "SELECT CategoryID, CategoryName FROM Categories"
		Dim sqlProd As String = "SELECT ProductID, ProductName, CategoryID FROM Products"

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
		Return ds
	End Function


	Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs)
If Menu1.SelectedItem Is Nothing Then
Return
End If
		If Menu1.SelectedItem.Depth = 0 Then
			lblInfo.Text = "You selected Category ID: "
		Else If Menu1.SelectedItem.Depth = 1 Then
			lblInfo.Text = "You selected Product ID: "
		End If
		lblInfo.Text += Menu1.SelectedItem.Value
	End Sub
End Class

