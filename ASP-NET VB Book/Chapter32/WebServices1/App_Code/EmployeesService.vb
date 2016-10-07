Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Web.Configuration

<WebService(Name := "Employees Service", Description := "Retrieve the Northwind Employees", Namespace := "http://www.apress.com/ProASP.NET/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class EmployeesService : Inherits System.Web.Services.WebService
	Private connectionString As String

	Public Sub New()
		connectionString = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString
	End Sub

	<WebMethod(Description := "Returns the total number of employees.")> _
	Public Function GetEmployeesCount() As Integer
		' Create the command and the connection.	
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim sql As String = "SELECT COUNT(*) FROM Employees"
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
	End Function

	<WebMethod(Description := "Returns the full list of employees.")> _
	Public Function GetEmployees() As DataSet
		' Create the command and the connection.
		Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " & "TitleOfCourtesy, HomePhone FROM Employees"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet.
		da.Fill(ds, "Employees")
		Return ds
	End Function

	<WebMethod(Description := "Returns the full list of employees by city.", MessageName := "GetEmployeesByCity")> _
	Public Function GetEmployeesByCity(ByVal city As String) As DataSet
		' Create the command and the connection.
		Dim sql As String = "SELECT EmployeeID, LastName, FirstName, Title, " & "TitleOfCourtesy, HomePhone FROM Employees " & "WHERE City LIKE '%'+ @City + '%'"
		Dim con As SqlConnection = New SqlConnection(connectionString)
		Dim da As SqlDataAdapter = New SqlDataAdapter(sql, con)
		da.SelectCommand.Parameters.Add("@City", city)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet.
		da.Fill(ds, "Employees")
		Return ds
	End Function

	<WebMethod(Description := "Causes an error and returns a SOAP exception.")> _
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
End Class
