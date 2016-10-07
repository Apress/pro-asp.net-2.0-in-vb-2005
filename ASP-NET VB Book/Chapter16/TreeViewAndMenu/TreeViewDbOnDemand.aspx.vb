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
Imports System.Web.Configuration
Imports System.Data.SqlClient

Public partial Class TreeViewDbOnDemand : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			Dim dtCategories As DataTable = GetCategories()

			' Loop through the category records.
			For Each row As DataRow In dtCategories.Rows
				Dim nodeCategory As TreeNode = New TreeNode(row("CategoryName").ToString(), row("CategoryID").ToString())

				' Use the populate-on-demand feature for this
				' node's children.
				nodeCategory.PopulateOnDemand = True

				' Make sure the node is collapsed at first,
				' so it's no populated immediately.
				nodeCategory.Collapse()
				TreeView1.Nodes.Add(nodeCategory)
			Next row
		End If
	End Sub

	Private Function GetCategories() As DataTable
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
		Dim con As SqlConnection = New SqlConnection(connectionString)

		Dim sqlCat As String = "SELECT CategoryID, CategoryName FROM Categories"

		Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCat, con)
		Dim ds As DataSet = New DataSet()
		Try
			con.Open()

			' Fill the DataSet with the Categories table.
			da.Fill(ds, "Categories")
		Finally
			con.Close()
		End Try

		Return ds.Tables("Categories")
	End Function

	Private Function GetProducts(ByVal categoryID As Integer) As DataTable
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
		Dim con As SqlConnection = New SqlConnection(connectionString)

		Dim sqlProd As String = "SELECT ProductID, ProductName, CategoryID FROM Products WHERE CategoryID=@CategoryID"

		Dim da As SqlDataAdapter = New SqlDataAdapter(sqlProd, con)
		da.SelectCommand.Parameters.AddWithValue("@CategoryID", categoryID)
		Dim ds As DataSet = New DataSet()
		Try
			con.Open()

			' Fill the DataSet with the Categories table.
			da.Fill(ds, "Products")
		Finally
			con.Close()
		End Try
		Return ds.Tables("Products")
	End Function
	Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs)
		If TreeView1.SelectedNode Is Nothing Then
		Return
		End If
		If TreeView1.SelectedNode.Depth = 0 Then
			lblInfo.Text = "You selected Category ID: "
		Else If TreeView1.SelectedNode.Depth = 1 Then
			lblInfo.Text = "You selected Product ID: "
		End If
		lblInfo.Text += TreeView1.SelectedNode.Value
	End Sub
	Protected Sub TreeView1_TreeNodePopulate(ByVal sender As Object, ByVal e As TreeNodeEventArgs)
		' The only on-populate nodes are categories.
		' However, if there were several types you would check
		' the TreeNode.Depth to determine what type of node
		' is being expanded.
		Dim categoryID As Integer = Int32.Parse(e.Node.Value)
		Dim dtProducts As DataTable = GetProducts(categoryID)

		' Loop through the product records.
		For Each row As DataRow In dtProducts.Rows
			' Use the constructor that requires just text
			' and a non-displayed value.
			Dim nodeProduct As TreeNode = New TreeNode(row("ProductName").ToString(), row("ProductID").ToString())

			e.Node.ChildNodes.Add(nodeProduct)
		Next row
	End Sub
End Class
