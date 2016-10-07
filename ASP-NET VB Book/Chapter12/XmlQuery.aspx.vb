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
Imports System.Xml
Imports System.Text

Public partial Class XmlQuery : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString

		' Define the command.
		Dim customerQuery As String = "SELECT FirstName, LastName FROM Employees FOR XML AUTO, ELEMENTS"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim com As SqlCommand = New SqlCommand(customerQuery, con)

		' Execute the command.
		Dim str As StringBuilder = New StringBuilder()
		Try
			con.Open()
			Dim reader As XmlReader = com.ExecuteXmlReader()

			Do While reader.Read()
				' Process each employee.
				If (reader.Name = "Employees") AndAlso (reader.NodeType = XmlNodeType.Element) Then
					reader.ReadStartElement("Employees")
					str.Append(reader.ReadElementString("FirstName"))
					str.Append(" ")
					str.Append(reader.ReadElementString("LastName"))
					str.Append("<br>")
					reader.ReadEndElement()
				End If
			Loop
			reader.Close()
		Finally
			con.Close()
		End Try
		XmlText.Text = str.ToString()
	End Sub
End Class
