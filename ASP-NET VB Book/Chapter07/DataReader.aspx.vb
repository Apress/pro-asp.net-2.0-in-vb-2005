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
Imports System.Text
Imports System.Web.Configuration

Public partial Class DataReader : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Create the Command and the Connection.
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString

		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT * FROM Employees"
		Dim cmd As SqlCommand = New SqlCommand(sql, con)

		' Open the Connection and get the DataReader.
		con.Open()
		Dim reader As SqlDataReader = cmd.ExecuteReader()

		' Cycle through the records, and build the HTML string.
		Dim htmlStr As StringBuilder = New StringBuilder("")
		Do While reader.Read()
			htmlStr.Append("<li>")
			htmlStr.Append(reader("TitleOfCourtesy"))
			htmlStr.Append(" <b>")
			htmlStr.Append(reader.GetString(1))
			htmlStr.Append("</b>, ")
			htmlStr.Append(reader.GetString(2))
			htmlStr.Append(" - employee from ")
			htmlStr.Append(reader.GetDateTime(6).ToString("d"))
			htmlStr.Append("</li>")
		Loop

		' Close the DataReader and the Connection.
		reader.Close()
		con.Close()

		' Show the generated HTML code on the page.
		HtmlContent.Text = htmlStr.ToString()
	End Sub
End Class
