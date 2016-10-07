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
Imports System.Xml
Imports System.Web.Configuration

Public partial Class DataSetToXml : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Pubs").ConnectionString
		Dim SQL As String = "SELECT * FROM authors WHERE city='Oakland'"

		' Create the ADO.NET objects.
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim cmd As SqlCommand = New SqlCommand(SQL, con)
		Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
		Dim ds As DataSet = New DataSet("AuthorsDataSet")

		' Retrieve the data.
		con.Open()
		adapter.Fill(ds, "AuthorsTable")
		con.Close()

		' Create the XmlDataDocument that wraps this DataSet.
		Dim dataDoc As XmlDataDocument = New XmlDataDocument(ds)

		' Display the XML data (with the help of an XSLT) in the XML web control.
		XmlControl.Document = dataDoc
		XmlControl.TransformSource = "authors.xslt"
	End Sub
End Class
