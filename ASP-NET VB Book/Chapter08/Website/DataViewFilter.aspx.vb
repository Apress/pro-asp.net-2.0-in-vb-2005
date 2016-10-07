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
Imports System.Data.SqlClient


Public partial Class DataViewFilter : Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the Connection, DataAdapter, and DataSet.
		Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" & "Integrated Security=SSPI"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT ProductID, ProductName, UnitsInStock, UnitsOnOrder, Discontinued FROM Products"

		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet
		da.Fill(ds, "Products")

		' Filter for the Chocolade product.
		Dim view1 As DataView = New DataView(ds.Tables("Products"))
		view1.RowFilter = "ProductName = 'Chocolade'"
		Datagrid1.DataSource = view1

		' Filter for products that aren't on order or in stock.
		Dim view2 As DataView = New DataView(ds.Tables("Products"))
		view2.RowFilter = "UnitsInStock = 0 AND UnitsOnOrder = 0"
		Datagrid2.DataSource = view2

		' Filter for products starting with the letter P.
		Dim view3 As DataView = New DataView(ds.Tables("Products"))
		view3.RowFilter = "ProductName LIKE 'P%'"
		Datagrid3.DataSource = view3

		' Bind all the data-bound controls on the page.
		' Alternatively, you could call the DataBind() method
		' of each grid separately
		Me.DataBind()

	End Sub

End Class
