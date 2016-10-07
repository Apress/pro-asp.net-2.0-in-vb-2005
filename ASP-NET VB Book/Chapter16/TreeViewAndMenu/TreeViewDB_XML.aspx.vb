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
Imports System.Xml

Public partial Class TreeViewDB_XML : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
		Dim con As SqlConnection = New SqlConnection(connectionString)

		Dim sql As String = "SELECT C.CategoryName, C.CategoryID, P.ProductName, P.ProductID FROM Products P INNER JOIN Categories C ON P.CategoryID = C.CategoryID FOR XML AUTO, ELEMENTS"

		Dim cmd As SqlCommand = New SqlCommand(sql, con)

		Dim xml As String = ""
		Try
			con.Open()

			Dim r As XmlReader = cmd.ExecuteXmlReader()
			r.Read()
			xml = "<root>" & r.ReadOuterXml() & "</root>"
		Finally
			con.Close()
		End Try
		sourceDbXml.Data = xml
	End Sub
End Class
