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
Imports Microsoft.Web.Services3.Security.Tokens
Imports Microsoft.Web.Services3
Imports System.Security

''' <summary>
''' Summary description for EmployeesService
''' </summary>
<WebService(Name := "Employees Service", Description := "Retrieve the Northwind Employees", Namespace := "http://www.apress.com/ProASP.NET/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
Public Class EmployeesService : Inherits System.Web.Services.WebService
	<SoapLog(Name := "EmployeesService.GetEmployeesLogged", Level := 3), WebMethod()> _
	Public Function GetEmployeesLogged() As DataSet
		Return GetEmployees()
	End Function

	<WebMethod()> _
	Public Function GetEmployeesSlow() As DataSet
		' Delay.
		System.Threading.Thread.Sleep(4000)

		Return GetEmployees()
	End Function

	<WebMethod()> _
	Public Function GetEmployeesWseSecured() As DataSet
		GetUsernameToken()
		Return GetEmployees()
	End Function

	Private Function GetEmployees() As DataSet
		Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString

		' Create the command and the connection.
		Dim sql As String = "SELECT * FROM Employees"
		Dim con As SqlConnection = New SqlConnection(connectionString)

		Dim cmd As SqlCommand = New SqlCommand("GetAllEmployees", con)
		cmd.CommandType = CommandType.StoredProcedure
		Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
		Dim ds As DataSet = New DataSet()

		' Fill the DataSet.
		da.Fill(ds, "Employees")
		Return ds
	End Function

	Private Function GetUsernameToken() As String

		For Each token As SecurityToken In RequestSoapContext.Current.Security.Tokens
			If TypeOf token Is UsernameToken Then
				Return (CType(token, UsernameToken)).Username
			End If
			If TypeOf token Is IssuedToken Then
				Return ""
			End If

		Next token
		Throw New SecurityException("Missing security token")
	End Function

End Class



