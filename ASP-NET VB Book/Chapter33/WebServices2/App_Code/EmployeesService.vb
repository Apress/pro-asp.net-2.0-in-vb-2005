Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports DatabaseComponent
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Web.Configuration

''' <summary>
''' Summary description for EmployeesService
''' </summary>
<WebService(Namespace := "http://www.apress.com/ProASP.NET/Compat"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class EmployeesService : Inherits System.Web.Services.WebService
	<WebMethod(Description := "Returns the full list of employees.")> _
	Public Function GetEmployees() As EmployeeDetails()
		Dim db As EmployeeDB = New EmployeeDB()
		Return db.GetEmployees()
	End Function

	<WebMethod()> _
	Public Function GetEmployeesCountError() As Integer
		Try
			Dim con As SqlConnection = New SqlConnection(connectionString)

			' Make a deliberately faulty SQL string
			Dim sql As String = "INVALID_SQL COUNT(*) FROM Employees"
			Dim cmd As SqlCommand = New SqlCommand(sql, con)

			' Open the connection and get the value.
			cmd.Connection.Open()
			Dim numEmployees As Integer = -1
			Try
				numEmployees = CInt(cmd.ExecuteScalar())
			Finally
				cmd.Connection.Close()
			End Try
			Return numEmployees
		Catch err As Exception
			' Create the detail information
			' an <ExceptionType> element with the type name.
			Dim doc As XmlDocument = New XmlDocument()
			Dim node As XmlNode = doc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace)
			Dim child As XmlNode = doc.CreateNode(XmlNodeType.Element, "ExceptionType", SoapException.DetailElementName.Namespace)
			child.InnerText = err.GetType().ToString()
			node.AppendChild(child)

			' Create the custom SoapException.
			' Use the message from the original exception,
			' and add the detail information.
			Dim soapErr As SoapException = New SoapException(err.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, node)

			' Throw the revised SoapException.
			Throw soapErr
		End Try
	End Function
	Private connectionString As String

	Public Sub New()
		connectionString = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
	End Sub
End Class

