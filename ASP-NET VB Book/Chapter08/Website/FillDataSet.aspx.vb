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

Public partial Class FillDataSet : Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create the Connection, DataAdapter, and DataSet.
		Dim connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;" & "Integrated Security=SSPI"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT * FROM Employees"

		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet.
		da.Fill(ds, "Employees")

		' Cycle through the records, and build the HTML string.
		Dim htmlStr As StringBuilder = New StringBuilder("")
		For Each dr As DataRow In ds.Tables("Employees").Rows
			htmlStr.Append("<li>")
			htmlStr.Append(dr("TitleOfCourtesy").ToString())
			htmlStr.Append(" <b>")
			htmlStr.Append(dr("LastName").ToString())
			htmlStr.Append("</b>, ")
			htmlStr.Append(dr("FirstName").ToString())
			htmlStr.Append("</li>")
		Next dr

		' Show the generated HTML string.
		HtmlContent.Text = htmlStr.ToString()

		' Bind the DataSet to the Repeater.
		Repeater1.DataSource = ds
		Repeater1.DataMember = "Employees"
		Repeater1.DataBind()

	End Sub
End Class
