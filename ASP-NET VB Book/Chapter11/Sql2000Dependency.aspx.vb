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
Imports System.Web.Configuration
Imports System.Web.Caching

Public partial Class Sql2000Dependency : Inherits System.Web.UI.Page
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
		lblInfo.Text &= "<br>"
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			lblInfo.Text &= "Creating dependent item...<br>"
			Cache.Remove("Person.Address")
			' Create a dependency for the Employees table.
			Dim dependency As SqlCacheDependency = New SqlCacheDependency("Northwind", "Person.Address")


			Dim dt As DataTable = GetEmployeeTable()
			lblInfo.Text &= "Adding dependent item<br>"
			Cache.Insert("Person.Address", dt, dependency)
		End If
	End Sub


	Private connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
	Private Function GetEmployeeTable() As DataTable
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT * FROM Employees"
		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
		Dim ds As DataSet = New DataSet()
		da.Fill(ds, "Person.Address")
		Return ds.Tables(0)
	End Function

	Protected Sub cmdModfiy_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim con As SqlConnection = New SqlConnection(connectionString)
		' Even a change that really does do anything is still a change.
		Dim sql As String = "UPDATE Employees SET LastName='Davolio' WHERE LastName='Davolio'"
		Dim cmd As SqlCommand = New SqlCommand(sql, con)

		Try
			con.Open()
			cmd.ExecuteNonQuery()
		Finally
			con.Close()
		End Try
		lblInfo.Text &= "Update completed (remember to wait for poll time to pass).<br />"
	End Sub
	Protected Sub cmdGetItem_Click(ByVal sender As Object, ByVal e As EventArgs)
		If Cache("Person.Address") Is Nothing Then
			lblInfo.Text &= "Cache item no longer exits.<br />"
		Else
			lblInfo.Text &= "Item is still present.<br />"
		End If
	End Sub
End Class
