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

Public partial Class GridViewDataBind : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		If (Not Page.IsPostBack) Then
			' Create the command and the connection.
			Dim connectionString As String = "Data Source=localhost;" & "Initial Catalog=Northwind;Integrated Security=SSPI"
			Dim sql As String = "SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees"
			Dim con As SqlConnection = New SqlConnection(connectionString)
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			Try
				' Open the connection and get the DataReader.
				con.Open()
				Dim reader As SqlDataReader = cmd.ExecuteReader()

				' Bind the DataReader to the list.
				grid.DataSource = reader
				grid.DataBind()
				reader.Close()
			Finally
				' Close the connection.
				con.Close()
			End Try
		End If
	End Sub

End Class
