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
Imports System.Data.SqlClient

Public partial Class SqlInjection : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub cmdGetRecords_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" & "Integrated Security=SSPI"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT Orders.CustomerID, Orders.OrderID, COUNT(UnitPrice) AS Items, " & "SUM(UnitPrice * Quantity) AS Total FROM Orders " & "INNER JOIN [Order Details] " & "ON Orders.OrderID = [Order Details].OrderID " & "WHERE Orders.CustomerID = '" & txtID.Text & "' " & "GROUP BY Orders.OrderID, Orders.CustomerID"
		Dim cmd As SqlCommand = New SqlCommand(sql, con)

		con.Open()
		Dim reader As SqlDataReader = cmd.ExecuteReader()
		GridView1.DataSource = reader
		GridView1.DataBind()
		reader.Close()
		con.Close()
	End Sub
End Class
