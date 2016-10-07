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

Public partial Class DataSetXml : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' create the connection, DataAdapter and DataSet
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
		Dim sql As String = "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees"
		Dim conn As SqlConnection = New SqlConnection(connectionString)
		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet and fill the first grid.
		da.Fill(ds, "Employees")
		Datagrid1.DataSource = ds.Tables("Employees")
		Datagrid1.DataBind()

		' Generate the XML file.
		Dim xmlFile As String = Server.MapPath("Employees.xml")
		ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema)

		' Load the XML file.
		Dim dsXml As DataSet = New DataSet()
		dsXml.ReadXml(xmlFile)
		' Fill the second grid.
		Datagrid2.DataSource = dsXml.Tables("Employees")
		Datagrid2.DataBind()

	End Sub
End Class
