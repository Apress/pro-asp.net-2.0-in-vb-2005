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
Imports System.Text
Imports System.Data.SqlClient

Public partial Class DataReaderMultiple : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Create the Command and the Connection.
		Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" & "Integrated Security=SSPI"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT TOP 5 EmployeeID, FirstName, LastName FROM Employees;" & "SELECT TOP 5 ContactName, ContactTitle FROM Customers;" & "SELECT TOP 5 SupplierID, CompanyName, ContactName FROM Suppliers"

		Dim cmd As SqlCommand = New SqlCommand(sql, con)

		' Open the Connection and get the DataReader.
		con.Open()
		Dim reader As SqlDataReader = cmd.ExecuteReader()

		' Cycle through the records and all the rowsets,
		' and build the HTML string.
		Dim htmlStr As StringBuilder = New StringBuilder("")
		Dim i As Integer = 0
		Do
			htmlStr.Append("<h2>Rowset: ")
			htmlStr.Append(i.ToString())
			htmlStr.Append("</h2>")

			Do While reader.Read()
				htmlStr.Append("<li>")
				' Get all the fields in this row.
                Dim nField As Integer = 0
                Do While nField < reader.FieldCount
                    htmlStr.Append(reader.GetName(nField).ToString())
                    htmlStr.Append(": ")
                    htmlStr.Append(reader.GetValue(nField).ToString())
                    htmlStr.Append("&nbsp;&nbsp;&nbsp;")
                    nField += 1
                Loop
				htmlStr.Append("</li>")
			Loop
			htmlStr.Append("<br><br>")
			i += 1
		Loop While reader.NextResult()


		' Close the DataReader and the Connection.
		reader.Close()
		con.Close()

		' Show the generated HTML code on the page.
		HtmlContent.Text = htmlStr.ToString()
	End Sub
End Class
